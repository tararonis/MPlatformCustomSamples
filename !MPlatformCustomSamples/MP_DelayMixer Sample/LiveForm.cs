using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MixerSample
{
    public partial class LiveForm : Form
    {
        private IMDevice m_objLive;  //Live source class. Intednded for receiving data from capture cards, cams and other devices
        
        public LiveForm()
        {
            InitializeComponent();
        }

        public LiveForm(IMDevice pDevice)
        {
            try
            {
                InitializeComponent();
                m_objLive = (IMDevice)pDevice;

                //Fill Video Device List
                FillCombo("video", comboBoxVideo);
                
                FillCombo("ext_audio", comboBoxExtAudio);

                //Initialize preview
                ((IMPreview)m_objLive).PreviewEnable("", 0, 0);
                ((IMPreview)m_objLive).PreviewWindowSet("", panelPreview.Handle.ToInt32());
                ((IMPreview)m_objLive).PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);

                //Fill output formats
                FillOutputVideoFormats();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Live source object isn't valid: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        /// <summary>
        /// Initialization of Medialooks objects and form controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLive_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Fill video output formats list
        /// </summary>
        private void FillOutputVideoFormats()
        {
            comboBoxVFOut.Items.Clear();
            comboBoxVFOut.Items.Add("<Auto>");
            comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_NTSC);
            comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_PAL);
            comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_HD720_50p);
            comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_HD1080_50p);
            comboBoxVFOut.Items.Add(eMVideoFormat.eMVF_HD1080_50i);
            comboBoxVFOut.SelectedIndex = 0;
        }

        /// <summary>
        /// Fill combo boxes (Audio/Video device and Audio/Video input line (if avilable))
        /// </summary>
        /// <param name="pDevice"></param>
        /// <param name="strType"></param>
        /// <param name="cbxType"></param>
        private void FillCombo(string strType, ComboBox cbxType)
        {
            cbxType.Items.Clear();
            cbxType.Tag = strType;
            int nCount = 0;
            //Get device count / input line count
            m_objLive.DeviceGetCount(0, strType, out nCount);
            cbxType.Enabled = nCount > 0;
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    string strName;
                    string strDesc;
                    //Get deveice / input line
                    m_objLive.DeviceGetByIndex(0, strType, i, out strName, out strDesc);
                    cbxType.Items.Add(strName);
                }
                string strCur = "";
                string strParam = "";
                int nIndex = 0;
                try
                {
                    //Check if there is already selected device / input line
                    m_objLive.DeviceGet(strType, out strCur, out strParam, out nIndex);
                    cbxType.SelectedIndex = !string.IsNullOrEmpty(strCur) ? cbxType.FindStringExact(strCur) : 0;
                }
                catch
                {
                    cbxType.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Fill combo boxes (Audio / Video format)
        /// </summary>
        /// <param name="pDevice"></param>
        /// <param name="strType"></param>
        /// <param name="cbxTarget"></param>
        private void FillComboFomat(IMDevice pDevice, string strType, ComboBox cbxTarget)
        {
            if (strType == "video")
            {
                int nCount = 0;
                int nIndex;
                string strFormat;
                M_VID_PROPS vidProps;
                cbxTarget.Items.Clear();
                //Get video format count
                ((IMFormat)m_objLive).FormatVideoGetCount(eMFormatType.eMFT_Input, out nCount);
                cbxTarget.Enabled = nCount > 0;
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {
                        //Get format by index
                        ((IMFormat)m_objLive).FormatVideoGetByIndex(eMFormatType.eMFT_Input, i, out vidProps, out strFormat);
//                        cbxTarget.Items.Add(vidProps.eVideoFormat);
                        cbxTarget.Items.Add(strFormat);
                        
                    }
                    //Check if there is selected format
                    ((IMFormat)m_objLive).FormatVideoGet(eMFormatType.eMFT_Input, out vidProps, out nIndex, out strFormat);
                    if (nIndex > 0)
                        cbxTarget.SelectedIndex = nIndex;
                    else cbxTarget.SelectedIndex = 0;
                }
                
            }
            else if (strType == "ext_audio")
            {
                int nCount = 0;
                int nIndex;
                string strFormat;
                M_AUD_PROPS audProps;
                cbxTarget.Items.Clear();               
                //Get video format count
                ((IMFormat)m_objLive).FormatAudioGetCount(eMFormatType.eMFT_Input, out nCount);
                cbxTarget.Enabled = nCount > 0;
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {
                        //Get audio format
                        ((IMFormat)m_objLive).FormatAudioGetByIndex(eMFormatType.eMFT_Input, i, out audProps, out strFormat);
                        cbxTarget.Items.Add(strFormat);
                    }
                    //Check if there is selected format
                    ((IMFormat)m_objLive).FormatAudioGet(eMFormatType.eMFT_Input, out audProps, out nIndex, out strFormat);
                    if (nIndex > 0)
                        cbxTarget.SelectedIndex = nIndex;
                    else cbxTarget.SelectedIndex = 0;
                }
            }
            cbxTarget.Tag = strType;
        }

        /// <summary>
        /// Device / input line changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAV_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbxChanged = (ComboBox)sender;
            string strType = (string)cbxChanged.Tag;
            //Set device
            m_objLive.DeviceSet(strType, (string)cbxChanged.SelectedItem, "");
            if (strType == "video")
            {
                buttonNDIRefresh.Enabled = cbxChanged.SelectedItem.ToString().Contains("NDI");
                
                // Update audio
                FillCombo("ext_audio", comboBoxAudio);
                // Update input lines
                FillCombo(strType + "::line-in", comboBoxVL);
                //Update Formats
                FillComboFomat(m_objLive, strType, comboBoxVF);
            }
            else if (strType == "ext_audio")
            {
                //Update Formats
                FillComboFomat(m_objLive, strType, comboBoxAF);
            }
        }

        /// <summary>
        /// Format changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAVF_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbxChanged = (ComboBox)sender;
            string strType = (string)cbxChanged.Tag;

            if (strType == "video")
            {
                M_VID_PROPS vidProps = new M_VID_PROPS();
                string strFormat;
                ((IMFormat)m_objLive).FormatVideoGetByIndex(eMFormatType.eMFT_Input, cbxChanged.SelectedIndex, out vidProps, out strFormat);
                //Set new video format
                ((IMFormat)m_objLive).FormatVideoSet(0, ref vidProps);
            }
            else if (strType == "ext_audio")
            {
                M_AUD_PROPS audProps = new M_AUD_PROPS();
                string strFormat;
                ((IMFormat)m_objLive).FormatAudioGetByIndex(eMFormatType.eMFT_Input, cbxChanged.SelectedIndex, out audProps, out strFormat);
                //Set new audio format
                ((IMFormat)m_objLive).FormatAudioSet(0, ref audProps);
            }
        }

        /// <summary>
        /// Close current live source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            ((IMObject)m_objLive).ObjectClose();
        }

        /// <summary>
        /// Show video device properties (if available)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonV_Click(object sender, EventArgs e)
        {
            try
            {
                m_objLive.DeviceShowProps("video", "device", this.Handle.ToInt32());
            }
            catch { }
        }

        /// <summary>
        /// Show audio device properties (if available)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonA_Click(object sender, EventArgs e)
        {
            try
            {
                m_objLive.DeviceShowProps("ext_audio", "device", this.Handle.ToInt32());
            }
            catch {}
        }

        /// <summary>
        /// Show video format properties (if available)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonVF_Click(object sender, EventArgs e)
        {
            try
            {
                m_objLive.DeviceShowProps("video", "stream", this.Handle.ToInt32());
            }
            catch { }
        }

        /// <summary>
        /// Show audio format properties(if available)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAF_Click(object sender, EventArgs e)
        {
            try
            {
                m_objLive.DeviceShowProps("ext_audio", "stream", this.Handle.ToInt32());
            }
            catch { }
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            ((IMObject)m_objLive).ObjectStart(null);
        }

        /// <summary>
        /// Enable/desable the video preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxVideo_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objLive != null)
            ((IMPreview)m_objLive).PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
        }

        /// <summary>
        /// Enable/desable the audio preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (m_objLive != null)
            ((IMPreview)m_objLive).PreviewEnable("", checkBoxAudio.Checked ? 1 : 0, checkBoxVideo.Checked ? 1 : 0);
        }

        /// <summary>
        /// Set audio volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            // Volume in dB
            // 0 - full volume, -100 silence
            double dblPos = (double)trackBarVolume.Value / trackBarVolume.Maximum;
            ((IMPreview)m_objLive).PreviewAudioVolumeSet("", -1, -30 * (1 - dblPos));
        }

        /// <summary>
        /// Statistics routine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerStatus_Tick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Refresh preview after resizing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelPreview_Resize(object sender, EventArgs e)
        {
            if (m_objLive != null)
            {
                try
                {
                    ((IMPreview)m_objLive).PreviewWindowSet("", panelPreview.Handle.ToInt32());
                }
                catch { }
            }
        }

        /// <summary>
        /// Set video format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxVFOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxVFOut.SelectedIndex != 0)
                {
                    // Set video format
                    M_VID_PROPS vidProps = new M_VID_PROPS();
                    vidProps.eVideoFormat = (eMVideoFormat)comboBoxVFOut.SelectedItem;
                    ((IMFormat)m_objLive).FormatVideoSet(eMFormatType.eMFT_Convert, ref vidProps);
                }
            }
            catch
            {
                throw;
            }
        }

        private void buttonNDIRefresh_Click(object sender, EventArgs e)
        {
            FillCombo("video::line-in", comboBoxVL);
        }
    }
}