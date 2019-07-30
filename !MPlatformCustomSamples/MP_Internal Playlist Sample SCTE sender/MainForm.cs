using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace InternalPlaylistSample
{
    public partial class MainForm : Form
    {
        private MPlaylistClass m_objPlaylist; //MPlaylist class intended for playlist management
        private MRendererClass m_objRenderer; // Renderer class used for output
        private int startVideoFormat;
        private int startAudioFormat;
        bool insert = false;
        bool writer_start = false;
        MWriterClass writer;


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public MainForm()
        {
            InitializeComponent();
            SendMessage(textBoxNDIWebRTCName.Handle, 0x1501, 0, "NDI/WebRTC Name");
            comboBox1.Items.Add("Working");
            comboBox1.Items.Add("Not Working");
            comboBox1.Items.Add("Custom");
            comboBox1.SelectedIndex = 0;
        }


        string working = @"<SpliceInfoSection protocolVersion = '0' ptsAdjustment='0' tier='4095'>
   <SpliceInsert spliceEventId = '296' spliceEventCancelIndicator='1' outOfNetworkIndicator='0' spliceImmediateFlag='1' uniqueProgramId='1' availNum='0' availsExpected='0'>
       <BreakDuration autoReturn = '0' duration='450450'/>
   </SpliceInsert>
</SpliceInfoSection>";

        string not_working = @"<SpliceInfoSection protocolVersion='0' ptsAdjustment='0' tier='4095'>
   <SpliceInsert spliceEventId='296' spliceEventCancelIndicator='0' outOfNetworkIndicator='1' spliceImmediateFlag='1' uniqueProgramId='1' availNum='0' availsExpected='0'>
       <BreakDuration autoReturn='0' duration='450450'/>
   </SpliceInsert>
</SpliceInfoSection>
";

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
                m_objPlaylist = new MPlaylistClass();
               
                //m_objFile = new MFileClass();
                m_objRenderer = new MRendererClass();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't create MPlatform objects: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            //Loop playlist
            m_objPlaylist.PropsSet("loop", "true");
            m_objPlaylist.PropsSet("object::on_frame.sync", "true");
            m_objPlaylist.OnEvent += new IMEvents_OnEventEventHandler(m_objFile_OnEvent);
            m_objPlaylist.OnFrameSafe += M_objPlaylist_OnFrameSafe;
            //Initialize preview
            m_objPlaylist.PreviewWindowSet("", panelPreview.Handle.ToInt32());
            m_objPlaylist.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);

            //Start mFile object
            m_objPlaylist.ObjectStart(new object());

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
                comboBoxRenderer.SelectedIndex = 0;
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

            //Start playlist
            m_objPlaylist.FilePlayStart();
        }

        private void M_objPlaylist_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            if (insert)
            {
                string strTriggers;
                (pMFrame as IMFFrame).MFStrSet("SCTE-35", richTextBox1.Text);
                if (!checkBox1.Checked)
                {
                    insert = false;
                }

            }
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
            m_objPlaylist.FormatVideoGetCount(eMFormatType.eMFT_Convert, out nCount);
            comboBoxVF.Enabled = nCount > 0;
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    //Get format by index
                    m_objPlaylist.FormatVideoGetByIndex(eMFormatType.eMFT_Convert, i, out vidProps, out strFormat);
                    if (vidProps.eVideoFormat == eMVideoFormat.eMVF_HD1080_5994i) startVideoFormat = i;
                    comboBoxVF.Items.Add(strFormat);

                }
                //Check if there is selected format
                m_objPlaylist.FormatVideoGet(eMFormatType.eMFT_Convert, out vidProps, out nIndex, out strFormat);
                if (nIndex > 0)
                    comboBoxVF.SelectedIndex = nIndex;
                else comboBoxVF.SelectedIndex = 0;
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
            m_objPlaylist.FormatAudioGetCount(eMFormatType.eMFT_Convert, out nCount);
            comboBoxAF.Enabled = nCount > 0;
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    //Get format by index
                    m_objPlaylist.FormatAudioGetByIndex(eMFormatType.eMFT_Convert, i, out audProps, out strFormat);
                    if (audProps.nBitsPerSample == 16 && audProps.nChannels == 16 && audProps.nSamplesPerSec == 48000) startAudioFormat = i;
                    comboBoxAF.Items.Add(strFormat);

                }
                //Check if there is selected format
                m_objPlaylist.FormatAudioGet(eMFormatType.eMFT_Convert, out audProps, out nIndex, out strFormat);
                if (nIndex > 0)
                    comboBoxAF.SelectedIndex = nIndex;
                else comboBoxAF.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Listen for events
        /// </summary>
        /// <param name="bsChannelID"></param>
        /// <param name="bsEventName"></param>
        /// <param name="bsEventParam"></param>
        void m_objFile_OnEvent(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            Marshal.ReleaseComObject(pEventObject);

            

            if (bsEventName == "EOF")
            {
                int nIndex, nNextIndex;
                double dblFileTime, dblListTime;
                m_objPlaylist.PlaylistPosGet(out nIndex, out nNextIndex, out dblFileTime, out dblListTime);
                try
                {
                    dataGridViewFiles.CurrentCell = dataGridViewFiles.Rows[nIndex].Cells[0];
                }
                catch { }
            }
        }

        /// <summary>
        /// Adds new file to playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (openMediaFile.ShowDialog() == DialogResult.OK && openMediaFile.FileNames.Length != 0)
            {
                for (int i = 0; i < openMediaFile.FileNames.Length; i++)
                {
                    int nIndex = -1;
                    MItem pFile;
                    m_objPlaylist.PlaylistAdd(null, openMediaFile.FileNames[i], "", ref nIndex, out pFile);

                    if (pFile == null) continue;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pFile);
                    GC.Collect();
                }
                updateList();
            }
        }

        /// <summary>
        /// Updates values in DataGridView
        /// </summary>
        private void updateList()
        {
            dataGridViewFiles.RowsRemoved -= new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewFiles_RowsRemoved);
            dataGridViewFiles.Rows.Clear();
            dataGridViewFiles.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridViewFiles_RowsRemoved);
            int nFiles = 0;
            double dblDuration = 0;
            m_objPlaylist.PlaylistGetCount(out nFiles, out dblDuration);
            for (int i = 0; i < nFiles; i++)
            {
                string strPathOrCommand;
                MItem pItem;
                double dblPos;
                m_objPlaylist.PlaylistGetByIndex(i, out dblPos, out strPathOrCommand, out pItem);
                strPathOrCommand = strPathOrCommand.Substring(strPathOrCommand.LastIndexOf('\\') + 1);

                double dblIn = 0;
                double dblOut = 0;
                double dblFileDuration = 0;
                pItem.FileInOutGet(out dblIn, out dblOut, out dblFileDuration);

                string strIn = String.Format("{0:0.00}", dblIn);
                string strOut = String.Format("{0:0.00}", dblOut);
                int nrow = dataGridViewFiles.Rows.Add(dataGridViewFiles.Rows.Count + 1, strPathOrCommand, strIn, strOut);
                dataGridViewFiles.Rows[nrow].Tag = pItem;
            }
        }

        private void reindexList()
        {
            for (int i = 0; i < dataGridViewFiles.Rows.Count; i++)
            {
                dataGridViewFiles.Rows[i].Cells[0].Value = i + 1;
            }
        }

        /// <summary>
        /// Starts playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, EventArgs e)
        {
            int nCurrent, nNext;
            double dblFileTime, dblListTime;
            m_objPlaylist.PlaylistPosGet(out nCurrent, out nNext, out dblFileTime, out dblListTime);

            //Switch to another file if it was selected
            if (getCurrentFile() != nCurrent)
                m_objPlaylist.PlaylistPosSet(getCurrentFile(), 0, 0);

            //Play current file
            m_objPlaylist.FilePlayStart();
        }

        private int getCurrentFile()
        {
            if (dataGridViewFiles.SelectedRows.Count > 0)
            {
                DataGridViewRow dCurrentRow = dataGridViewFiles.SelectedRows[0];
                return dCurrentRow.Index;
            }
            else if (dataGridViewFiles.Rows.Count > 0)
                return 0;
            else return -1;

        }

        /// <summary>
        /// Quick start new playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get selected file
            int curFile = getCurrentFile();
            //Play current file
            m_objPlaylist.PlaylistPosSet(curFile, 0, 0);
            m_objPlaylist.FilePlayStart();
        }

        /// <summary>
        /// Enables/desables the video preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objPlaylist != null)
                m_objPlaylist.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
        }

        /// <summary>
        /// Enables/desables the audio preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objPlaylist != null)
                m_objPlaylist.PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
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
            m_objPlaylist.PreviewAudioVolumeSet("", -1, -30 * (1 - dblPos));
        }

        /// <summary>
        /// Pauses playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPause_Click(object sender, EventArgs e)
        {
            m_objPlaylist.FilePlayPause(0);
        }

        /// <summary>
        /// Rewinds to start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRewind_Click(object sender, EventArgs e)
        {
            m_objPlaylist.FilePosSet(0, 0);
        }

        /// <summary>
        /// Stops playback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click(object sender, EventArgs e)
        {
            m_objPlaylist.FilePlayStop(0);
        }

        /// <summary>
        /// Statistics routine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerStatus_Tick(object sender, EventArgs e)
        {
            eMState eState;
            if (m_objPlaylist != null)
            {
                m_objPlaylist.ObjectStateGet(out eState);
                try
                {
                    int nCount;
                    double dblListLen;
                    m_objPlaylist.PlaylistGetCount(out nCount, out dblListLen);

                    if (nCount > 0)
                    {
                        int nCurFile, nNextFile = 0;
                        double dblFilePos, dblListPos = 0;
                        m_objPlaylist.PlaylistPosGet(out nCurFile, out nNextFile, out dblFilePos, out dblListPos);

                        string strPath;
                        MItem pItem;
                        double dblListOffset;
                        m_objPlaylist.PlaylistGetByIndex(nCurFile, out dblListOffset, out strPath, out pItem);

                        double dblIn, dblOut, dblFileLen = 0;
                        pItem.FileInOutGet(out dblIn, out dblOut, out dblFileLen);
                        if (dblOut > dblIn)
                            dblFileLen = dblOut;

                        labelPos.Width = (int)((trackBarSeek.Width - 16) * dblListPos / dblListLen);
                        string strFile = strPath.Substring(strPath.LastIndexOf('\\') + 1);

                        labelStatus.Text = Dbl2PosStr(dblFilePos) + "/" + Dbl2PosStr(dblFileLen) + " " +
                            eState.ToString() + " (" + (nCurFile + 1) + "/" + nCount + ") " +
                            Dbl2PosStr(dblListPos) + "/" + Dbl2PosStr(dblListLen) + " " +
                            "\r\n" + strFile + "\r\n" + strPath;

                        System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
                    }
                    GC.Collect();
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
            int nCount;
            double dblListLen;
            m_objPlaylist.PlaylistGetCount(out nCount, out dblListLen);
            if (nCount > 0)
            {
                double dblIn = 0;
                double dblOut = 0;
                double dblDuration = 0;
                m_objPlaylist.FileInOutGet(out dblIn, out dblOut, out dblDuration);
                dblDuration = (dblOut > dblIn ? dblOut : dblDuration) - dblIn;
                double dblPos = dblIn + dblDuration * (double)trackBarSeek.Value / (double)trackBarSeek.Maximum;
                m_objPlaylist.FilePosSet(dblPos, 0);

                int nIndex, nNextIndex;
                double dblFileTime, dblListTime;
                m_objPlaylist.PlaylistPosGet(out nIndex, out nNextIndex, out dblFileTime, out dblListTime);
                dataGridViewFiles.CurrentCell = dataGridViewFiles.Rows[nIndex].Cells[0];
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

                    m_objRenderer.ObjectStart(m_objPlaylist);
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
        /// Synchronize MPlaylist with DataGridView when files are removed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewFiles_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            m_objPlaylist.PlaylistRemoveByIndex(e.RowIndex, 0);
            updateList();
        }

        /// <summary>
        /// Refresh preview after resizing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelPreview_SizeChanged(object sender, EventArgs e)
        {
            if (m_objPlaylist != null)
            {
                try
                {
                    m_objPlaylist.PreviewWindowSet("", panelPreview.Handle.ToInt32());
                }
                catch { }
            }
        }

        /// <summary>
        /// Remove selected item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewFiles.SelectedRows != null && dataGridViewFiles.SelectedRows.Count > 0)
            {
                m_objPlaylist.PlaylistRemoveByIndex(dataGridViewFiles.SelectedRows[0].Index, 0);
                updateList();
            }
        }

        private void dataGridViewFiles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFiles.SelectedRows != null && dataGridViewFiles.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridViewFiles.SelectedRows[0].Cells.Count; i++)
                {
                    if (dataGridViewFiles.SelectedRows[0].Cells[i].Value == null)
                        dataGridViewFiles.SelectedRows[0].Cells[i].Value = string.Empty;

                }
                if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                {
                    IMItem pItem = dataGridViewFiles.SelectedRows[0].Tag as IMItem;
                    double dblIn = 0;
                    double dblOut = 0;
                    bool bValidIn = double.TryParse(dataGridViewFiles.SelectedRows[0].Cells[2].Value.ToString(), out  dblIn);
                    bool bValidOut = double.TryParse(dataGridViewFiles.SelectedRows[0].Cells[3].Value.ToString(), out  dblOut);

                    // Set new in-out
                    if (bValidIn && bValidOut)
                        pItem.FileInOutSet(dblIn, dblOut);
                    updateList();

                    if (pItem == null) return;
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
                    GC.Collect();
                }
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
            m_objPlaylist.FormatVideoGetByIndex(eMFormatType.eMFT_Convert, comboBoxVF.SelectedIndex, out vidProps, out strFormat);
            //Set new video format
            m_objPlaylist.FormatVideoSet(eMFormatType.eMFT_Convert, ref vidProps);
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
            m_objPlaylist.FormatAudioGetByIndex(eMFormatType.eMFT_Convert, comboBoxAF.SelectedIndex, out audProps, out strFormat);
            //Set new audio format
            m_objPlaylist.FormatAudioSet(eMFormatType.eMFT_Convert, ref audProps);
        }

        //Create/destroy virtual device
        private void checkBoxVDev_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVDev.Checked)
            {
                // Create virtual device, use default name 
                m_objPlaylist.ObjectVirtualSourceCreate(1, "", "");
            }
            else
            {
                // Destroy virtual source
                m_objPlaylist.ObjectVirtualSourceCreate(0, "", "");
            }
        }

        string m_strItemID;
        public MLCHARGENLib.CoMLCharGen m_objCharGen;

        private void checkBoxCG_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objCharGen != null)
            {
                m_objPlaylist.PluginsRemove(m_objCharGen);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objCharGen);
                m_objCharGen = null;
                m_strItemID = "";
                CGProps.Enabled = false;
            }

            if (checkBoxCG.Checked)
            {
                m_objCharGen = new MLCHARGENLib.CoMLCharGen();
                m_objPlaylist.PluginsAdd(m_objCharGen, 0);

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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_objPlaylist != null)
                m_objPlaylist.ObjectClose();
            if (m_objRenderer != null)
                m_objRenderer.ObjectClose();
        }

        private void dataGridViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void dataGridViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] arrStrFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            MItem pFile = null;
            try
            {
                for (int i = 0; i < arrStrFiles.Length; i++)
                {
                    int nIndex = -1;
                    m_objPlaylist.PlaylistAdd(null, arrStrFiles[i], "", ref nIndex, out pFile);
                }
            }
            catch (Exception) { }

            if (pFile != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFile);
                GC.Collect();
            }
            updateList();
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
                m_objRenderer.ObjectStart(m_objPlaylist);
            }
        }

        private void textBoxNDIWebRTCName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxNDIWebRTCName.Text) && e.KeyChar == (char)Keys.Enter && checkBoxOutput.Checked)
                m_objRenderer.DeviceSet("renderer::line-out", textBoxNDIWebRTCName.Text, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double offset = 0;
            string path;
            MItem item;
            m_objPlaylist.PlaylistGetByIndex(0, out offset, out path, out item);

            M_TIMECODE end;
            M_TIMECODE start;

            int type;
            item.FileInOutGetTC(out start, out end, out type);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Text = checkBox1.Checked ? "Start on each frame" : "Insert";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    richTextBox1.Clear();
                    richTextBox1.AppendText(working);
                    break;
                case 1:
                    richTextBox1.Clear();
                    richTextBox1.AppendText(not_working);
                    break;
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            insert = true;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            if (writer_start)
            {
                button2.Text = "Start writer";
                writer.ObjectClose();
            }
            else
            {
                button2.Text = "Stop writer";
                if (writer == null)
                    writer = new MWriterClass();
                writer.WriterNameSet(textBox1.Text, " format='dvb' protocol='udp://' embed_scte35='true' video::codec='mpeg2video' video::b='5M' audio::codec='aac'");
                writer.ObjectStart(m_objPlaylist);
            }
        }
    }
}