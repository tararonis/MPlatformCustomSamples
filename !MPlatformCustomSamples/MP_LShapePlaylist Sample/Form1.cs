using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;
using MControls;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;

namespace PlaylistSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MCCDisplayClass m_CCDisplay;
        MPlaylistClass m_objPlaylist;
        MFOverlayHTMLClass m_objOverlayHTML;

        private FormStat m_FormStat;

        string m_strDemoFile = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Medialooks\MPlatform", "resources.path", null) + "\\CEF\\demo.html";
        string m_strDemoURL = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text += " - MPlatform SDK " + CheckVersionClass.GetVersion();
            }
            catch { }

            try
            {
                m_objPlaylist = new MPlaylistClass();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Can't create a MPlatform's object: " + exception.ToString(), "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            try
            {
                m_objOverlayHTML = new MFOverlayHTMLClass();
            }
            catch (Exception exception)
            {
                checkBoxHTML.Enabled = false;
                buttonHTMLProps.Enabled = false;
                textBoxHTMLURL.Enabled = false;
            }

            if (File.Exists(m_strDemoFile))
            {
                m_strDemoURL = Path.GetFullPath(m_strDemoFile);
                textBoxHTMLURL.Text = "demo";
            }

            m_objPlaylist.OnFrame += new IMEvents_OnFrameEventHandler(m_objPlaylist_OnFrame);
            m_objPlaylist.OnEvent += new IMEvents_OnEventEventHandler(m_objPlaylist_OnEvent);
            m_objPlaylist.ObjectStart(null);
            m_formCG = new FormCG();
            m_formCG.m_pParentForm = this;
            mPersistControl1.SetControlledObject(m_objPlaylist);
            mPlaylistControl1.SetControlledObject(m_objPlaylist);
            mPreviewControl1.SetControlledObject(m_objPlaylist);
            mFormatControl1.SetControlledObject(m_objPlaylist);
            mFileStateControl1.SetControlledObject(m_objPlaylist);
            mRateControl1.SetControlledObject(m_objPlaylist);
            mPlaylistStatus1.SetControlledObject(m_objPlaylist);

            mRendererCheckList1.SetSourceObject(m_objPlaylist);

            mSeekControl1.SetControlledObject(m_objPlaylist);

            mPlaylistTimeline1.SetControlledObject(m_objPlaylist);

            mAudioMeter1.SetControlledObject(m_objPlaylist);
            mAudioMeter1.SizeChanged += new EventHandler(mAudioMeter1_SizeChanged);


            mPlaylistBackground1.SetControlledObject(m_objPlaylist);

            mPlaylistControl1.OnPlaylistSelChanged += new EventHandler(mPlaylistControl1_OnPlaylistSelChanged);
            mPlaylistControl1.OnPlaylistChanged += new EventHandler(mPlaylistControl1_OnPlaylistChanged);

            mRendererCheckList1.OnRenderingChange += new EventHandler(mRendererCheckList1_OnRenderingChange);

            mBreaksControl1.OnBreaksChanged += new EventHandler(mBreaksControl1_OnBreaksChanged);

            mPersistControl1.OnLoad += new EventHandler(mPersistControl1_OnLoad);

            mAudioMeter1_SizeChanged(null, null);
        }

        // WARNING! Need for release all OnEvent/OnFrame objects!
        private void timerReleaseEvents_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }

        void mPersistControl1_OnLoad(object sender, EventArgs e)
        {
            mPlaylistControl1.UpdateList(true);
            mPlaylistTimeline1.ItemChanged(null);
        }

        void mAudioMeter1_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > 180)
            {
                mPreviewControl1.Width = this.Width - 28 - mAudioMeter1.Bounds.Right;
                mPreviewControl1.Height = mAudioMeter1.Height;
                mPreviewControl1.Location = new Point(mAudioMeter1.Bounds.Right + 6, mPreviewControl1.Location.Y);
            }

            Trace.WriteLine(mPreviewControl1.Bounds);
        }

        void mPlaylistControl1_OnPlaylistChanged(object sender, EventArgs e)
        {
            if (sender != null)
                mPlaylistTimeline1.ItemChanged((MItem)sender);
        }

        void mBreaksControl1_OnBreaksChanged(object sender, EventArgs e)
        {
            // Update playlist
            mPlaylistControl1.UpdateList(true);
            mPlaylistTimeline1.ItemChanged((MItem)sender);
        }

        void mRendererCheckList1_OnRenderingChange(object sender, EventArgs e)
        {
            MRenderersList.MRenderer_EventArgs pArg = (MRenderersList.MRenderer_EventArgs)e;
            mPlaylistStatus1.OnAir = pArg.bHaveStarted;
        }

        void mPlaylistControl1_OnPlaylistSelChanged(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count > 0)
            {
                mBreaksControl1.Enabled = true;
                mBreaksControl1.SetControlledObject(listView.SelectedItems[0].Tag);
            }
            else
            {
                mBreaksControl1.Enabled = false;
                mBreaksControl1.SetControlledObject(null);
            }
        }

        void m_objPlaylist_OnEvent(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            Marshal.ReleaseComObject(pEventObject);

            mFileStateControl1.UpdateState();
            UpdateSeekControl();
        }

        void m_objPlaylist_OnFrame(string bsChannelID, object pMFrame)
        {
            Marshal.ReleaseComObject(pMFrame);
            mSeekControl1.UpdatePos();
        }

        void UpdateSeekControl()
        {
            // Update seek control
            if (!checkBoxListSeek.Checked)
            {
                double dblPos;
                MItem pCurrent;
                string strPath;
                try
                {
                    m_objPlaylist.PlaylistGetByIndex(-1, out dblPos, out strPath, out pCurrent);
                    mSeekControl1.SetControlledObject(pCurrent);
                }
                catch
                {
                    MessageBox.Show("Please choose a file.");
                    checkBoxListSeek.Checked = true;
                }
            }
            else
            {
                mSeekControl1.Enabled = true;
                mSeekControl1.SetControlledObject(m_objPlaylist);
            }
        }

        private void checkBoxListSeek_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSeekControl();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_FormStat != null)
                m_FormStat.Close();
        }


        //////////////////////////////////////////////////////////////////////////
        // CG

        //string m_strItemID;
        public MLCHARGENLib.CoMLCharGen m_objCharGen;
        private void checkBoxCG_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objCharGen != null)
            {
                m_objPlaylist.PluginsRemove(m_objCharGen);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objCharGen);
                m_objCharGen = null;
                //m_strItemID = "";
                buttonCG_Props.Enabled = false;
                //CGParams.Enabled = false;
                CgEditorButton.Enabled = false;

            }

            if (checkBoxCG.Checked)
            {
                m_objCharGen = new MLCHARGENLib.CoMLCharGen();
                m_objPlaylist.PluginsAdd(m_objCharGen, 0);

                //m_objCharGen.AddNewItem("MediaLooks", 0.1, 0.1, 1, 1, ref m_strItemID);
                //m_objCharGen.SetItemProperties(m_strItemID, "movement::speed-x", "1", "", 0);
                //m_objCharGen.ShowItem(m_strItemID, 1, 1000);
                //CGParams.Enabled = true;
                buttonCG_Props.Enabled = true;
                CgEditorButton.Enabled = true;
            }
        }
        int LShape = 1;
        private void Lshape_chb_CheckedChanged(object sender, EventArgs e)
        {
            string graphicsItemId = "myImage";
            if (LShape == 1)
            {

                string pathToImageFile = LShapePath_txb.Text;//@"E:\!temp\etere pte ltd_1024x576_L Shape-12.png";
                double relativeX = 0.00;
                double relativeY = 0.00;
                int isRelative = 1;
                int isShow = 0;
                m_objCharGen.AddNewItem(pathToImageFile, relativeX, relativeY, isRelative, isShow, ref graphicsItemId);
                m_objCharGen.SetItemSize(graphicsItemId, 1920, 1080, 0, 0);
                m_objCharGen.ShowItem(graphicsItemId, 1, 1000);

                MLCHARGENLib.tagRECT trSource = new MLCHARGENLib.tagRECT();
                trSource.top = 0;
                trSource.left = 0;
                trSource.bottom =0;
                trSource.right = 0;
                MLCHARGENLib.tagRECT trTarget = new MLCHARGENLib.tagRECT();
                trTarget.top = 0;
                trTarget.left = 270;
                trTarget.bottom = 740;
                trTarget.right = 1920;

                m_objCharGen.SetVideoOutputRectWithDelay(trSource, trTarget, 0, 1, 0, 1000);
                //m_objCharGen.SetVideoOutputRect(trSource, trTarget, 0, 1);

                // I specify the destination rectangle assuming that my video resolution is 1920x1080
            }
            else if (LShape == 0)
            {
                // Tatget and source rectangles
                MLCHARGENLib.tagRECT trSource = new MLCHARGENLib.tagRECT();
                MLCHARGENLib.tagRECT trTarget = new MLCHARGENLib.tagRECT();
                // Transform a video into the original state within 1 second
                m_objCharGen.SetVideoOutputRectWithDelay(trSource, trTarget, 0, 1, 0, 1000);
                m_objCharGen.RemoveItem(graphicsItemId, 1000);
            }

            LShape = LShape == 0 ? 1 : 0;
        }

        private void buttonCG_Props_Click(object sender, EventArgs e)
        {
            if (m_objCharGen != null)
                m_objCharGen.ShowPropertiesPage(Handle.ToInt32());
        }

        private void checkBoxVSource_CheckedChanged(object sender, EventArgs e)
        {
            m_objPlaylist.ObjectVirtualSourceCreate(checkBoxVSource.Checked ? 1 : 0, "", "");
        }

        private FormCG m_formCG;
        private void CGParams_Click(object sender, EventArgs e)
        {
            if (m_objCharGen != null)
            {
                m_formCG.m_pMLCharGen = m_objCharGen;
                m_formCG.Hide();
                m_formCG.Show(this);
                m_formCG.UpdateList();
                m_formCG.UpdateCompositionsList();
            }
        }


        private void buttonStatistic_Click(object sender, EventArgs e)
        {
            try
            {
                List<object> listObjects = new List<object>();
                listObjects.Add(m_objPlaylist);

                m_FormStat = new FormStat();
                if (m_FormStat.SetControlledObject(listObjects) > -1)
                    m_FormStat.Show();
            }
            catch
            {
            }
        }

        private void CgEditorButton_Click(object sender, EventArgs e)
        {
            CGEditor_WinForms.MainWindow cgEditor = new CGEditor_WinForms.MainWindow();
            cgEditor.SetSourceObject(m_objPlaylist, m_objCharGen);
            cgEditor.ShowDialog(this);
        }


        private void checkBoxCC_CheckedChanged(object sender, EventArgs e)
        {
            if (m_CCDisplay != null)
            {
                m_objPlaylist.PluginsRemove(m_CCDisplay);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_CCDisplay);
                m_CCDisplay = null;
            }

            if (checkBoxCC.Checked)
            {
                m_CCDisplay = new MCCDisplayClass();
                m_objPlaylist.PluginsAdd(m_CCDisplay, 0);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_objPlaylist != null)
            {
                mRendererCheckList1.SetSourceObject(null);
                mPreviewControl1.SetControlledObject(null);
                m_objPlaylist.ObjectClose();
            }
        }

        private void checkBoxHTML_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHTML.Checked)
            {
                if (m_objOverlayHTML == null)
                {
                    m_objOverlayHTML = new MFOverlayHTMLClass();
                }

                m_objPlaylist.PluginsAdd(m_objOverlayHTML, 0);

                buttonHTMLProps.Enabled = true;

                if (!String.IsNullOrEmpty(textBoxHTMLURL.Text))
                {
                    string strURL = textBoxHTMLURL.Text;

                    if (String.Equals(textBoxHTMLURL.Text, "demo") &&
                        File.Exists(m_strDemoFile))
                    {
                        strURL = m_strDemoURL;
                    }

                    m_objOverlayHTML.BrowserPageLoad(strURL);
                }
            }
            else
            {
                m_objPlaylist.PluginsRemove(m_objOverlayHTML);
				m_objOverlayHTML.BrowserClose();
                Marshal.ReleaseComObject(m_objOverlayHTML);
                m_objOverlayHTML = null;
                buttonHTMLProps.Enabled = false;
            }
        }

        private void buttonHTMLProps_Click(object sender, EventArgs e)
        {
            M_VID_PROPS vProps = new M_VID_PROPS();
            int idx;
            string strName;
            m_objPlaylist.FormatVideoGet(eMFormatType.eMFT_Convert, out vProps, out idx, out strName);
            OverlayHTMLWindow overlayHTMLWind = new OverlayHTMLWindow(m_objOverlayHTML, m_objPlaylist, vProps);

            if (overlayHTMLWind.m_bStateOk)
            {
                overlayHTMLWind.ShowDialog();
            }

            string strCurrURL;
            m_objOverlayHTML.PropsGet("current_url", out strCurrURL);
            
            if (strCurrURL != null)
                textBoxHTMLURL.Text = strCurrURL.Contains("demo.html") ? "demo" : strCurrURL;
        }

        private void textBoxHTMLURL_KeyDown(object sender, KeyEventArgs e)
        {

            if (checkBoxHTML.Checked && e.KeyCode == Keys.Enter && !String.IsNullOrEmpty(textBoxHTMLURL.Text))
            {
                string strURL = textBoxHTMLURL.Text;

                if (String.Equals(textBoxHTMLURL.Text, "demo") &&
                    File.Exists(m_strDemoFile))
                {
                    strURL = m_strDemoURL;
                }

                m_objOverlayHTML.BrowserPageLoad(strURL);
            }
        }
               
    }
}