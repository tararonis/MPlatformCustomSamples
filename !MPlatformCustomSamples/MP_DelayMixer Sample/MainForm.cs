using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using MCHROMAKEYLib;
using MPLATFORMLib;
using eMVideoFormat = MPLATFORMLib.eMVideoFormat;
using IMProps = MPLATFORMLib.IMProps;
using M_AUD_PROPS = MPLATFORMLib.M_AUD_PROPS;
using M_VID_PROPS = MPLATFORMLib.M_VID_PROPS;

namespace MixerSample
{
    public partial class MainForm : Form
    {
        private MRendererClass m_objRenderer; // Renderer class used for output
        private MMixerClass m_objMixer; //Mixer object intended for mixing of input sources
        MMixerClass m_objMixerInternal;
        MRendererClass m_objrenderIN;
        MLiveClass m_objLive;

        private MItem m_currItem; // Currently selected item
        private int startVideoFormat;
        private int startAudioFormat;

        MElement pEditElement;
        RectangleF rcOriginal;
        PointF ptOriginal;
        bool isResizingHor;
        bool isResizingVert;
        bool isTopBound;
        bool isLeftBound;
        bool isMoving;

        private ArrayList alDefaultParams = new ArrayList(new string[] {  "show", "alpha", "x", "y", "w", "h", "pos", "sx", "sy", "sw", "sh", "spos" });

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        public MainForm()
        {
            InitializeComponent();
            SendMessage(textBoxNDIWebRTCName.Handle, 0x1501, 0, "NDI/WebRTC Name");
        }

        /// <summary>
        /// Initialization of Medialooks objects and form controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += " - MPlatform SDK " + CheckVersionClass.GetVersion();
            }
            catch { }

            try
            {
                //Initialize objects
                m_objMixer = new MMixerClass();
                m_objRenderer = new MRendererClass();
                m_objMixerInternal = new MMixerClass();
                m_objrenderIN = new MRendererClass();
                m_objLive = new MLiveClass();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't create MPlatform objects: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
return;
            }

            //Initialize preview
            m_objMixer.PreviewWindowSet("", panelPreview.Handle.ToInt32());
            m_objMixer.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);

            //Start mixer object
            m_objMixer.ObjectStart(null);
            m_objMixer.FilePlayStart();

            //Look for renderers                      
            int nDevices = 0;
            m_objRenderer.DeviceGetCount(0, "renderer", out nDevices);
            if (nDevices > 0)
            {
                checkBoxOutput.Enabled = true;
                comboBoxRenderer.Enabled = true;
                for (int i = 0; i < nDevices; i++)
                {
                    string strName;
                    string strXML;
                    m_objRenderer.DeviceGetByIndex(0, "renderer", i, out strName, out strXML);
                    comboBoxRenderer.Items.Add(strName);
                }
                comboBoxRenderer.SelectedIndex= 0;
            }
            else
            {
                checkBoxOutput.Enabled = false;
                comboBoxRenderer.Enabled = false;
            }

            //Fill audio and video formats
            FillVideoFormats();
            FillAudioFormats();

            comboBoxVF.SelectedIndex = startVideoFormat;
            comboBoxAF.SelectedIndex = startAudioFormat;
            //Fill scenen tree
            mElementsTree.SetControlledObject(m_objMixer);
            MElement rootNode;
            m_objMixer.ElementsGetByIndex(0, out rootNode);
            if (rootNode != null)
                mElementsTree.SetSelectedElement(rootNode);

            if (rootNode == null) return;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(rootNode);
            GC.Collect();
        }

        /// <summary>
        /// Fill video formats list
        /// </summary>
        private void FillVideoFormats()
        {
            int nCount = 0;
            int nIndex;
            string strFormat;
            M_VID_PROPS vidProps;
            comboBoxVF.Items.Clear();
            //Get video format count
            m_objMixer.FormatVideoGetCount(eMFormatType.eMFT_Convert, out nCount);
            comboBoxVF.Enabled = nCount > 0;
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    //Get format by index
                    m_objMixer.FormatVideoGetByIndex(eMFormatType.eMFT_Convert, i, out vidProps, out strFormat);
					if (vidProps.eVideoFormat == eMVideoFormat.eMVF_HD1080_5994i) startVideoFormat = i;
                    comboBoxVF.Items.Add(strFormat);

                }
                //Check if there is selected format
                m_objMixer.FormatVideoGet(eMFormatType.eMFT_Convert, out vidProps, out nIndex, out strFormat);
                if (nIndex > 0)
                    comboBoxVF.SelectedIndex = nIndex;
                else comboBoxVF.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Update the list of input streams
        /// </summary>
        private void updateStreamList()
        {
            dataGridViewStreams.RowsRemoved -= new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewStreams_RowsRemoved);
            dataGridViewStreams.Rows.Clear();
            dataGridViewStreams.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewStreams_RowsRemoved);
            int nFiles = 0;
            m_objMixer.StreamsGetCount(out nFiles);
            for (int i = 0; i < nFiles; i++)
            {
                MItem pItem;
                string strStreamID;
                m_objMixer.StreamsGetByIndex(i, out strStreamID, out pItem);


                string strFile;
                pItem.FileNameGet(out strFile);
                strFile = strFile.Substring(strFile.LastIndexOf('\\') + 1);


                double dblIn = 0, dblOut = 0, dblFileDuration = 0;
                pItem.FileInOutGet(out dblIn, out dblOut, out dblFileDuration);
                string strIn = String.Format("{0:0.00}", dblIn);
                string strOut = String.Format("{0:0.00}", dblOut);

                eMState eState;
                double dblTime = 0;
                pItem.FileStateGet(out eState, out dblTime);

                dataGridViewStreams.SelectionChanged -= new System.EventHandler(this.dataGridViewStreams_SelectionChanged);
                int nrow = dataGridViewStreams.Rows.Add(strStreamID, strFile, strIn, strOut, eState);
                dataGridViewStreams.Rows[nrow].Tag = pItem;
                dataGridViewStreams.SelectionChanged += new System.EventHandler(this.dataGridViewStreams_SelectionChanged);
                this.dataGridViewStreams_SelectionChanged(this.dataGridViewStreams, new EventArgs());

            }
        }

        private void UpdateAttributesList()
        {
            if (mElementsTree.SelectedElement != null)
            {
                dataGridViewAttributes.Rows.Clear();
                int nCount;
                //Fill default attributes first
                for (int i = 0; i < alDefaultParams.Count; i++)
                {
                    bool nameFound = false;

                    ((IMAttributes)mElementsTree.SelectedElement).AttributesGetCount(out nCount);
                    for (int j = 0; j < nCount; j++)
                    {
                        string strName, strValue;
                        ((IMAttributes)mElementsTree.SelectedElement).AttributesGetByIndex(j, out strName, out strValue);
                        if (strName == alDefaultParams[i].ToString())
                        {
                            dataGridViewAttributes.Rows.Add(alDefaultParams[i], strValue);
                            nameFound = true;
                            break;
                        }
                    }
                    if (!nameFound)
                        dataGridViewAttributes.Rows.Add(alDefaultParams[i], "");
                }

                //Fill other attributes
                ((IMAttributes)mElementsTree.SelectedElement).AttributesGetCount(out nCount);
                for (int i = 0; i < nCount; i++)
                {
                    string strName, strValue;
                    ((IMAttributes)mElementsTree.SelectedElement).AttributesGetByIndex(i, out strName, out strValue);
                    if (!alDefaultParams.Contains(strName))
                    {
                        dataGridViewAttributes.Rows.Add(strName, strValue);
                    }
                }

            }
        }

        /// <summary>
        /// Fill audio formats list
        /// </summary>
        private void FillAudioFormats()
        {
            int nCount = 0;
            int nIndex;
            string strFormat;
            M_AUD_PROPS audProps;
            comboBoxAF.Items.Clear();
            //Get video format count
            m_objMixer.FormatAudioGetCount(eMFormatType.eMFT_Convert, out nCount);
            comboBoxAF.Enabled = nCount > 0;
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    //Get format by index
                    m_objMixer.FormatAudioGetByIndex(eMFormatType.eMFT_Convert, i, out audProps, out strFormat);
                    if (audProps.nBitsPerSample == 16 && audProps.nChannels == 16 && audProps.nSamplesPerSec == 48000) startAudioFormat = i;
                    comboBoxAF.Items.Add(strFormat);

                }
                //Check if there is selected format
                m_objMixer.FormatAudioGet(eMFormatType.eMFT_Convert, out audProps, out nIndex, out strFormat);
                if (nIndex > 0)
                    comboBoxAF.SelectedIndex = nIndex;
                else comboBoxAF.SelectedIndex = 0;
            }
        }

        private void FillAttributesList()
        {

        }

        /// <summary>
        /// Starts selected playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            m_objMixer.FilePlayStart();
        }


        /// <summary>
        /// Enables/desables the video preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objMixer != null)
            m_objMixer.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
        }

        /// <summary>
        /// Enables/desables the audio preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objMixer != null)
            m_objMixer.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
        }

        /// <summary>
        /// Sets audio volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Volume in dB
            // 0 - full volume, -100 silence
            double dblPos = (double)trackBarVolume.Value / trackBarVolume.Maximum;
            m_objMixer.PreviewAudioVolumeSet("", -1, -30 * (1 - dblPos));
        }

        /// <summary>
        /// Pauses playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPause_Click(object sender, EventArgs e)
        {
            eMState mState;
            m_objMixer.ObjectStateGet(out mState);
            if (mState == eMState.eMS_Paused)
            {
                m_objMixer.FilePlayStart();
                buttonPause.Text = "Pause";
            }
            else
            {
                m_objMixer.FilePlayPause(0);
                buttonPause.Text = "Resume";
            }
        }

        /// <summary>
        /// Rewinds to start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRewind_Click(object sender, EventArgs e)
        {
            m_objMixer.FilePosSet(0, 0);
        }

        /// <summary>
        /// Stops playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            m_objMixer.FilePlayStop(0);
        }

        /// <summary>
        /// Statistics routine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerStatus_Tick(object sender, EventArgs e)
        {
            eMState eState;
            double dblTimeRemain;
            if (m_currItem != null)
            {
                m_currItem.FileStateGet(out eState, out dblTimeRemain);
                try
                {
                  
                    string strPath;
                    double dblFilePos;

                    m_currItem.FileNameGet(out strPath);
                    m_currItem.FilePosGet(out dblFilePos);

                    double dblIn, dblOut, dblFileLen = 0;
                    m_currItem.FileInOutGet(out dblIn, out dblOut, out dblFileLen);
                    if (dblOut > dblIn)
                        dblFileLen = dblOut;

                    labelPos.Width = (int)((trackBarSeek.Width) * dblFilePos / dblFileLen);
                    string strFile = strPath.Substring(strPath.LastIndexOf('\\') + 1);

                    labelStatus.Text = Dbl2PosStr(dblFilePos) + "/" + Dbl2PosStr(dblFileLen) + " " +
                        eState.ToString() + " " +
                        "\r\n" + strFile + "\r\n" + strPath;

                }
                catch
                {
                    labelStatus.Text = eState.ToString();
                    labelPos.Width = 0;
                }
            }
        }

        /// <summary>
        /// Seeking routine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            if (m_currItem != null)
            {
                double dblIn = 0;
                double dblOut = 0;
                double dblDuration = 0;
                m_currItem.FileInOutGet(out dblIn, out dblOut, out dblDuration);
                dblDuration = (dblOut > dblIn ? dblOut : dblDuration) - dblIn;
                double dblPos = dblIn + dblDuration * (double)trackBarSeek.Value / (double)trackBarSeek.Maximum;
                m_currItem.FilePosSet(dblPos, 0);
            }
        }

        /// <summary>
        /// Helper method Double -> String
        /// </summary>
        /// <param name="_dblPos"></param>
        /// <returns></returns>
        string Dbl2PosStr(double _dblPos)
        {
            int nHour = (int)_dblPos / 3600;
            int nMinutes = ((int)_dblPos % 3600) / 60;
            int nSec = ((int)_dblPos % 60);
            _dblPos -= (int)_dblPos;
            int nMsec = (int)(_dblPos * 1000 + 0.5);


            string strRes = nHour.ToString("00") + ":" + nMinutes.ToString("00") + ":" + nSec.ToString("00") + "." + nMsec.ToString("000");
            return strRes;
        }

        /// <summary>
        /// Enable/Disable Decklink output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxOutput_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOutput.Checked)
            {
                try
                {
                    m_objRenderer.PropsSet("rate-control", "true");
                    m_objRenderer.DeviceSet("renderer", comboBoxRenderer.SelectedItem.ToString(), "");

                    if (textBoxNDIWebRTCName.Enabled && !String.IsNullOrEmpty(textBoxNDIWebRTCName.Text))
                        m_objRenderer.DeviceSet("renderer::line-out", textBoxNDIWebRTCName.Text, "");

                    m_objRenderer.ObjectStart(m_objMixer);
                }
                catch
                {
                    checkBoxOutput.Checked = false;
                    throw;
                }
            }
            else
            {
                try
                {
                    m_objRenderer.ObjectClose();
                }
                catch
                {
                    checkBoxOutput.Checked = false;
                    throw;
                }
            }
        }


        /// <summary>
        /// Refresh preview after resizing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelPreview_SizeChanged(object sender, EventArgs e)
        {
            if (m_objMixer != null)
            {
                try
                {
                    m_objMixer.PreviewWindowSet("", panelPreview.Handle.ToInt32());
                }
                catch { }
            }
        }


        /// <summary>
        /// Set new video format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            M_VID_PROPS vidProps = new M_VID_PROPS();
            string strFormat;
            m_objMixer.FormatVideoGetByIndex(eMFormatType.eMFT_Convert, comboBoxVF.SelectedIndex, out vidProps, out strFormat);
            //Set new video format
            m_objMixer.FormatVideoSet(eMFormatType.eMFT_Convert, ref vidProps);
        }

        /// <summary>
        /// Set new audio format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            M_AUD_PROPS audProps = new M_AUD_PROPS();
            string strFormat;
            m_objMixer.FormatAudioGetByIndex(eMFormatType.eMFT_Convert, comboBoxAF.SelectedIndex, out audProps, out strFormat);
            //Set new audio format
            m_objMixer.FormatAudioSet(eMFormatType.eMFT_Convert, ref audProps);
        }

        //Create/destroy virtual device
        private void checkBoxVDev_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVDev.Checked)
            {
                // Create virtual device, use default name 
                m_objMixer.ObjectVirtualSourceCreate(1, "", "");
            }
            else
            {
                // Destroy virtual source
                m_objMixer.ObjectVirtualSourceCreate(0, "", "");
            }
        }

        /// <summary>
        /// Add files as input streams
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddFile_Click(object sender, EventArgs e)
        {
            if (openMediaFile.ShowDialog() == DialogResult.OK && openMediaFile.FileNames.Length != 0)
            {
                
                for (int i = 0; i < openMediaFile.FileNames.Length; i++)
                {
                    MItem pItem;
                    m_objMixer.StreamsAdd("", null, openMediaFile.FileNames[i], "", out pItem, 1.00);
                    if (pItem != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
                        GC.Collect();
                    }
                }
                updateStreamList();


            } 
        }

        /// <summary>
        /// Add live source as input stream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddLive_Click(object sender, EventArgs e)
        {
            MLiveClass objLive = new MLiveClass();
            LiveForm formLive = new LiveForm(objLive);
            formLive.ShowDialog();
            eMState eState;
            objLive.ObjectStateGet(out eState);
            if (eState != eMState.eMS_Running)
                return;
            MItem pLive;
            m_objMixer.StreamsAdd("", objLive, "live_src", "", out pLive, 0);
            updateStreamList();

            if (pLive == null) return;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pLive);
            GC.Collect();
        }

        private void dataGridViewStreams_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

        }

        /// <summary>
        /// Remove input stream
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveInputStream_Click(object sender, EventArgs e)
        {
            if (dataGridViewStreams.SelectedRows != null && dataGridViewStreams.SelectedRows.Count > 0)
            {
                m_objMixer.StreamsRemoveByIndex(dataGridViewStreams.SelectedRows[0].Index, 0, 1);
		m_currItem = null;
                updateStreamList();
            }
        }

        private void dataGridViewStreams_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewStreams.SelectedRows != null && dataGridViewStreams.SelectedRows.Count > 0)
            {
                m_currItem = (MItem)dataGridViewStreams.SelectedRows[0].Tag;
                buttonLintWithInputStram.Enabled = true;
            }
            else
                buttonLintWithInputStram.Enabled = false;
        }

        /// <summary>
        /// Connect input stream to scene element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLinkWithInputStram_Click(object sender, EventArgs e)
        {
            if (dataGridViewStreams.SelectedRows != null && dataGridViewStreams.SelectedRows.Count > 0 && mElementsTree.SelectedElement != null)
            {
                // Get selected stream id
                string sStreamID;
                ((IMProps)dataGridViewStreams.SelectedRows[0].Tag).PropsGet("stream_id", out sStreamID);

                MElement pRoot = mElementsTree.SelectedElement;
                if (pRoot != null)
                {
                    MElement pChild;
                    ((IMElements)pRoot).ElementsAdd("", "video", "stream_id=" + sStreamID + " h=0.5 w=0.5 show=1", out pChild, 0);//(double)numericTimeForChange.Value);
                    mElementsTree.UpdateTree(true);
                    mElementsTree.SelectedElement = pChild;

                    if (pChild == null) return;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pChild);
                    GC.Collect();
                }
            }
        }

        /// <summary>
        /// Remove scene element
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveSceneElement_Click(object sender, EventArgs e)
        {
            MElement pRemove = mElementsTree.SelectedElement;
            if (pRemove != null)
            {
                pRemove.ElementDetach((double)numericTimeForChange.Value);
                mElementsTree.UpdateTree(false);
            }
        }

        /// <summary>
        /// Set attribute name/value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewAttributes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (mElementsTree.SelectedNode != null && dataGridViewAttributes.SelectedRows[0].Cells[0].Value != null)
            {
                string sName = dataGridViewAttributes.SelectedRows[0].Cells[0].Value.ToString();
                string sValue = dataGridViewAttributes.SelectedRows[0].Cells[1].Value == null ? "" : dataGridViewAttributes.SelectedRows[0].Cells[1].Value.ToString();
                ((IMElement)mElementsTree.SelectedElement).ElementStringSet(sName, sValue, (double)numericTimeForChange.Value);
            }
            UpdateAttributesList();
        }

        private void panelPreview_MouseDown(object sender, MouseEventArgs e)
        {
            double XMouse;
            double YMouse;
            XMouse = (PointToRelative(e.Location)).X;
            YMouse = (PointToRelative(e.Location)).Y;

            if (checkBoxAR.Checked)
            {
                GetNewXY(ref XMouse, ref YMouse);
            }

            // Select element in element tree
            MElement pElement = null;
            m_objMixer.ScenesElementGetByPos(XMouse, YMouse, 0, out pElement);
            if (pElement != null)
            {
                pEditElement = pElement;
                try
                {
                    // Could be exception - if scene not rendred yet
                    double x, y, w, h;
                    pEditElement.ElementAbsolutePosGet(out x, out y, out w, out h);
                    rcOriginal.X = (float)x;
                    rcOriginal.Y = (float)y;
                    rcOriginal.Width = (float)w;
                    rcOriginal.Height = (float)h;
                    ptOriginal = new PointF((float)XMouse, (float)YMouse); ;

                    double deltax = 0.04;
                    double deltay = 0.04;
                    if (XMouse > x && XMouse < x + deltax)
                    {
                        m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_SIZEWE);
                        isResizingHor = true;
                        isLeftBound = true;
                    }
                    else if (XMouse < x + w && XMouse > x + w - deltax)
                    {
                        m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_SIZEWE);
                        isResizingHor = true;
                    }
                    else if (YMouse > y && YMouse < y + deltay)
                    {
                        m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_SIZENS);
                        isResizingVert = true;
                        isTopBound = true;
                    }
                    else if (YMouse < y + h && YMouse > y + h - deltay)
                    {
                        m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_SIZENS);
                        isResizingVert = true;
                    }
                    else
                    {
                        m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_SIZEALL);
                        isMoving = true;
                    }
                    // Make element topmost
                    pEditElement.ElementReorder(10000);
                }
                catch (System.Exception)
                {
                }

            }
            if (pElement == null) return;
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pElement);
            GC.Collect();
        }

        private void panelPreview_MouseMove(object sender, MouseEventArgs e)
        {
            float XMouse = (PointToRelative(e.Location)).X;
            float YMouse = (PointToRelative(e.Location)).Y;
            if (pEditElement != null)
            {
                RectangleF rcNew = rcOriginal;
                if (isResizingHor)
                {
                    m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_SIZEWE);

                    if (isLeftBound)
                    {
                        rcNew.X += XMouse - ptOriginal.X;
                        rcNew.Width -= XMouse - ptOriginal.X;
                    }
                    else
                        rcNew.Width += XMouse - ptOriginal.X;

                }
                if (isResizingVert)
                {
                    m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_SIZENS);
                    if (isTopBound)
                    {
                        rcNew.Y += YMouse - ptOriginal.Y;
                        rcNew.Height -= YMouse - ptOriginal.Y;
                    }
                    else
                        rcNew.Height += YMouse - ptOriginal.Y;

                }
                else if (isMoving)
                {
                    m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_SIZEALL);
                    rcNew.X += XMouse - ptOriginal.X;
                    rcNew.Y += YMouse - ptOriginal.Y;
                }
                pEditElement.ElementAbsolutePosSet(rcNew.X, rcNew.Y, rcNew.Width, rcNew.Height);
            }

        }

        private void panelPreview_MouseUp(object sender, MouseEventArgs e)
        {
            // End element move/resize
            m_objMixer.PreviewSetCursor("", eMCursorType.eMCT_ARROW);
            pEditElement = null;
            isMoving = false;
            isResizingHor = false;
            isResizingVert = false;
            isLeftBound = false;
            isTopBound = false;            
            mElementsTree.UpdateTree(true);
            UpdateAttributesList();
        }

        private PointF PointToRelative(Point ptPos)
        {
            PointF ptRes = new PointF((float)ptPos.X / panelPreview.Width, (float)ptPos.Y / panelPreview.Height);
            return ptRes;
        }

        private void checkBoxAR_CheckedChanged(object sender, EventArgs e)
        {
            ((IMProps)m_objMixer).PropsSet("maintain_ar", checkBoxAR.Checked ? "letter-box" : "none");
        }

        private void mElementsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (mElementsTree.SelectedElement != null)
            {
                UpdateAttributesList();
            }
        }

        private void GetNewXY(ref double x, ref double y)
        {
            IMFormat pFormat = m_objMixer;
            M_VID_PROPS vProps;
            int nIndex;
            string strNmae;
            pFormat.FormatVideoGet(eMFormatType.eMFT_Output, out vProps, out nIndex, out strNmae);
            double videoAspectRatio = (double)vProps.nAspectX / (double)vProps.nAspectY;
            if (vProps.nAspectX == 0 && vProps.nAspectY == 0)
            {
                videoAspectRatio = (double)vProps.nWidth / (double)vProps.nHeight;
            }

            double previewAspectRatio = (double)panelPreview.Width / (double)panelPreview.Height;
            double kX = 0;
            double kY = 0;

            if (videoAspectRatio < previewAspectRatio)
            {
                kX = (videoAspectRatio * (double)panelPreview.Height) / (double)panelPreview.Width;
                x = (x - 0.5) / kX + 0.5;
            }
            else
            {
                kY = (double)panelPreview.Width / (videoAspectRatio * (double)panelPreview.Height);
                y = (y - 0.5) / kY + 0.5;
            }
        }

        private void mElementsTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UpdateAttributesList();
        }

        string m_strItemID;
        public MLCHARGENLib.CoMLCharGen m_objCharGen;

        private void checkBoxCG_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objCharGen != null)
            {
                m_objMixer.PluginsRemove(m_objCharGen);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objCharGen);
                m_objCharGen = null;
                m_strItemID = "";
                CGProps.Enabled = false;
            }

            if (checkBoxCG.Checked)
            {
                m_objCharGen = new MLCHARGENLib.CoMLCharGen();
                m_objMixer.PluginsAdd(m_objCharGen, 0);

                m_objCharGen.AddNewItem("MediaLooks", 0.1, 0.1, 1, 1, ref m_strItemID);
                m_objCharGen.SetItemProperties(m_strItemID, "movement::speed-x", "1", "", 0);
                m_objCharGen.ShowItem(m_strItemID, 1, 1000);

                CGProps.Enabled = true;
            }

        }

        private void CGProps_Click(object sender, EventArgs e)
        {
            if (m_objCharGen != null)
                m_objCharGen.ShowPropertiesPage(Handle.ToInt32());
        }

        private void chromaEnabler_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridViewStreams.SelectedRows != null && dataGridViewStreams.SelectedRows.Count > 0)
            {
                IMPlugins pPlugins = dataGridViewStreams.SelectedRows[0].Tag as IMPlugins;
                int nCount;
                long nCBCookie;
                object pPlugin = null;
                bool isCK = false;
                pPlugins.PluginsGetCount(out nCount);
                for (int i = 0; i < nCount; i++)
                {
                    pPlugins.PluginsGetByIndex(i, out pPlugin, out nCBCookie);

                    if (pPlugin.GetType() == typeof(MChromaKeyClass))
                    {
                        isCK = true;
                        break;
                    }
                }


                if (chromaEnabler.Checked == true && isCK == false)
                {
					pPlugins.PluginsAdd(new MCHROMAKEYLib.MChromaKey(), 0);
                }
                else if (chromaEnabler.Checked == false && isCK == true)
                {
                    pPlugins.PluginsRemove(pPlugin);
                }
                CKProps.Enabled = chromaEnabler.Checked;     
            }
        }

        private void CKProps_Click(object sender, EventArgs e)
        {
            if (dataGridViewStreams.SelectedRows != null && dataGridViewStreams.SelectedRows.Count > 0)
            {

				MCHROMAKEYLib.MChromaKey objChromaKey = GetChromakeyFilter(dataGridViewStreams.SelectedRows[0].Tag);
				if (objChromaKey != null)
				{
					FormChromaKey formCK = new FormChromaKey(objChromaKey);

					formCK.ShowDialog();
				}
            }
        }

		private MCHROMAKEYLib.MChromaKey GetChromakeyFilter(object source)
		{
			MCHROMAKEYLib.MChromaKey pChromaKey = null;
			try
			{
				int nCount = 0;
				IMPlugins pPlugins = (IMPlugins)source;
				pPlugins.PluginsGetCount(out nCount);
				for (int i = 0; i < nCount; i++)
				{
					object pPlugin;
					long nCBCookie;
					pPlugins.PluginsGetByIndex(i, out pPlugin, out nCBCookie);
					try
					{
						pChromaKey = (MCHROMAKEYLib.MChromaKey)pPlugin;
						break;
					}
					catch { }
				}
			}
			catch { }
			return pChromaKey;
		}

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
		if (m_objMixer != null) 
		m_objMixer.ObjectClose();
		if (m_objRenderer != null)
		m_objRenderer.ObjectClose();           
        }

        private void comboBoxRenderer_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxNDIWebRTCName.Enabled = comboBoxRenderer.SelectedItem.ToString().ToLower().Contains("ndi") ||
                               comboBoxRenderer.SelectedItem.ToString().ToLower().Contains("webrtc");
            textBoxNDIWebRTCName.Text = textBoxNDIWebRTCName.Enabled ? "" : "NDI/WebRTC Name";

            if (checkBoxOutput.Checked)
            {
                m_objRenderer.ObjectClose();

                m_objRenderer.DeviceSet("renderer", comboBoxRenderer.SelectedItem.ToString(), "");
                m_objRenderer.ObjectStart(m_objMixer);
            }
        }

        private void textBoxNDIWebRTCName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxNDIWebRTCName.Text) && e.KeyChar == (char)Keys.Enter && checkBoxOutput.Checked)
                m_objRenderer.DeviceSet("renderer::line-out", textBoxNDIWebRTCName.Text, "");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            m_objMixerInternal.ObjectStart(null);
            MItem pItem;
            if (openMediaFile.ShowDialog() == DialogResult.OK && openMediaFile.FileNames.Length != 0)
            {
                for (int i = 0; i < openMediaFile.FileNames.Length; i++)
                {
                   
                    m_objMixerInternal.StreamsAdd("", null, openMediaFile.FileNames[i], "", out pItem, 1.00);
                    if (pItem != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
                        GC.Collect();
                    }
                }
                updateStreamList();
            }          

            MElement root;
            m_objMixerInternal.ElementsGetByIndex(0, out root);

            MElement child;
            (root as IMElements).ElementsAdd("", "video", "stream_id=stream-000 h=1 w=1 show=1 audio_gain=-100", out child, 0);

            m_objMixerInternal.FilePlayStart();
            
            string InternalMixerName;
            m_objMixerInternal.ObjectNameGet(out InternalMixerName);
            m_objMixer.StreamsAdd("", null, "mp://" + InternalMixerName, "", out pItem, 0);
            
            updateStreamList();
        }

        private void Button2_Click(object sender, EventArgs e)
        {            
            (m_objMixerInternal as IMProps).PropsSet("object::mdelay.enabled", "true");
            (m_objMixerInternal as IMProps).PropsSet("object::mdelay.time", DelayBar.Value.ToString());           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int count;
            m_objLive.DeviceGetCount(0, "ext_audio", out count);
            string[] LiveArr = new string[count];
            for (int i = 0; i < count; i++)
            {
                string name, xml;

                m_objLive.DeviceGetByIndex(0, "ext_audio", i, out name, out xml);
                LiveArr[i] = name;
                externalAudio_list.Items.Add(name);
            }
            m_objLive.DeviceSet("video", "<None>", "");
            m_objLive.DeviceSet("audio", "<None>", "");           

            m_objLive.ObjectStart(null);            
        }

        private void ExternalAudio_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)comboBox.SelectedItem;
            m_objLive.DeviceSet("ext_audio", selected, "");
            MItem item;

            m_objMixer.StreamsBackgroundSet(m_objLive, "", "", out item, 0);
        }
    }
}