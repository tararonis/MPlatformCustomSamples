using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_WriterLongTest_31929
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objMPLaylist;
        MWriterClass m_objMWriter;
        string filePath = @"\\192.168.0.100\MLFiles\Trash\Roman\WorkFiles\FilesFromCostumer\2019.07.09Etere_31929\kom_mult_kosmik_007sh_s.mpg";
        //string writerEncodConfig = @"format='mp4' video::codec='q264sw' audio::codec='aac'";
        string writerEncodConfig = @"format='mp4' start_timecode='00:00:00:00' video::codec='q264sw' video::size='640x360' video::b='1M' video::minrate='1M' video::maxrate='1M' video::ar='' video::ref_frames='3' video::profile='Baseline' video::level='4.1' video::rc_type='cbr' audio::codec='aac' audio::ar='48000'";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMPLaylist = new MPlaylistClass();
            m_objMPLaylist.PreviewWindowSet("", panelPR.Handle.ToInt32());
            m_objMPLaylist.PreviewEnable("", 0, 1);

            m_objMWriter = new MWriterClass();

            ConfigPlaylist();
            ConfigWriter();
        }

        private void ConfigPlaylist()
        {
            MItem myBack;
            m_objMPLaylist.PlaylistBackgroundSet(null, "", "", out myBack);
            if (myBack != null)
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(myBack);
                GC.Collect();
            }
            // set convert format
            M_VID_PROPS mvid;
            M_AUD_PROPS maud;
            int fmtind;
            string fmtname;
            m_objMPLaylist.FormatVideoGet(eMFormatType.eMFT_Output, out mvid, out fmtind, out fmtname);
            m_objMPLaylist.FormatAudioGet(eMFormatType.eMFT_Output, out maud, out fmtind, out fmtname);
            m_objMPLaylist.FormatVideoSet(eMFormatType.eMFT_Convert, ref mvid);
            m_objMPLaylist.FormatAudioSet(eMFormatType.eMFT_Convert, ref maud);

            // set properties
            m_objMPLaylist.PropsSet("loop", "false");
            m_objMPLaylist.PropsSet("active_frc", "false");
            m_objMPLaylist.PropsSet("preview.drop_frames", "true");

            M_VID_PROPS vidProps = new M_VID_PROPS();
            vidProps.eVideoFormat = eMVideoFormat.eMVF_Custom;
            m_objMPLaylist.FormatVideoSet(eMFormatType.eMFT_Convert, ref vidProps);
        }
        void ConfigWriter()
        {
            m_objMWriter.PropsSet("rate_control", "true");
            m_objMWriter.PropsSet("pull_mode", "false");
            m_objMWriter.PropsSet("external_process", "false");
        }
        private void SetAudioChannels()
        {
            m_objMPLaylist.AudioTrackGetByIndex(0, out string desc, out IMAudioTrack audioTrack);
            audioTrack.TrackChannelsGet(out int nChIn, out int nChOutIdx, out int nChOut);
            for (int i = 0; i < nChOut; i++)
            {
                int mute;
                if (i < 2)
                    // switch on the required audio channels
                    mute = 0;
                else
                    // set mute all other audio channels
                    mute = 1;
                audioTrack.TrackMuteSet(i, mute, 0.0);
            }
        }

        private void StartTest_btn_Click(object sender, EventArgs e)
        {
            int index = -1;
            m_objMPLaylist.PlaylistAdd(null, filePath, "loop=true", ref index, out MItem item);
            SetAudioChannels();
            m_objMPLaylist.FilePlayStart();

            m_objMWriter.WriterNameSet(@"M:\TempVideo\EncTest.mp4", writerEncodConfig);
            m_objMWriter.ObjectStart(m_objMPLaylist);
        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            m_objMPLaylist.FilePlayStop(0);
            m_objMWriter.ObjectClose();
        }
    }
}
