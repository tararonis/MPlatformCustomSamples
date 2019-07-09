using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_EtereTrancodingProblem
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        public delegate void InvokeDelegate();

        MPlaylistClass MPlaylist;
        MWriterClass MWriter;
        int count=1;
        bool restart = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitObj();
            aTimer = new System.Timers.Timer(100);
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void MPlaylist_OnEventSafe(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            if (bsEventName == "EOF")
            {
                count++;
                MWriter.ObjectClose();
                MPlaylist.ObjectClose();
                restart = true;

            }
        }
        private void ATimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (restart == true)
            {                
                BeginInvoke(new InvokeDelegate(Release));
                BeginInvoke(new InvokeDelegate(InitObj));
                BeginInvoke(new InvokeDelegate(StartBug));
                
                restart = false;
            }
        }
        void Release()
        {            
            if (MPlaylist != null)
                Marshal.ReleaseComObject(MPlaylist);
            if (MWriter != null)
                Marshal.ReleaseComObject(MWriter);
            GC.Collect();
        }
        
        void InitObj()
        {
            MPlaylist = new MPlaylistClass();
            MWriter = new MWriterClass();

            MPlaylist.OnEventSafe += MPlaylist_OnEventSafe;
            MPlaylist.PreviewWindowSet("", panel1.Handle.ToInt32());
            MPlaylist.PreviewEnable("", 0, 1);
        }        
        

        void StartBug()
        {
            // playlist initialization

            M_VID_PROPS vidProps = new M_VID_PROPS();
            vidProps.eVideoFormat = eMVideoFormat.eMVF_Custom;
            MPlaylist.FormatVideoSet(eMFormatType.eMFT_Convert, ref vidProps);
            M_AUD_PROPS audioProp = new M_AUD_PROPS();
            audioProp.nChannels = 0;   //because some writer codecs (such as mp3) do not support 16 audio channels.
            MPlaylist.FormatAudioSet(eMFormatType.eMFT_Convert, audioProp);

            // playlist cue
            //set empty background. In this case playlist doesn't output anything until playback isn't started.
            MItem myBack;
            MPlaylist.PlaylistBackgroundSet(null, "", "", out myBack);
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
            MPlaylist.FormatVideoGet(eMFormatType.eMFT_Output, out mvid, out fmtind, out fmtname);
            MPlaylist.FormatAudioGet(eMFormatType.eMFT_Output, out maud, out fmtind, out fmtname);
            MPlaylist.FormatVideoSet(eMFormatType.eMFT_Convert, ref mvid);
            MPlaylist.FormatAudioSet(eMFormatType.eMFT_Convert, ref maud);
            // set properties
            MPlaylist.PropsSet("loop", "false");
            MPlaylist.PropsSet("active_frc", "false");
            MPlaylist.PropsSet("preview.drop_frames", "true");
            vidProps.eVideoFormat = eMVideoFormat.eMVF_Custom;
            MPlaylist.FormatVideoSet(eMFormatType.eMFT_Convert, ref vidProps);

            int index = -1;
            MItem item;
            MPlaylist.PlaylistAdd(null, @"\\192.168.0.100\MLFiles\Trash\Roman\WorkFiles\FilesFromCostumer\2019.05.27 Etere31929\kom_mult_kosmik_007sh_s.mpg", "", ref index, out item);
            
            // writer properties	
            MWriter.PropsSet("rate_control", "true");
            MWriter.PropsSet("pull_mode", "false");
            MWriter.PropsSet("external_process", "false");

            //set audio mapping on first 2 channels only
            string desc;
            IMAudioTrack audioTrack;
            MPlaylist.AudioTrackGetByIndex(0, out desc, out audioTrack);

            int nChIn;
            int nChOutIdx;
            int nChOut;
            audioTrack.TrackChannelsGet(out nChIn, out nChOutIdx, out nChOut);
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

            string encodeConfig = @"format='mp4' start_timecode='00:00:00:00' video::codec='q264sw' video::size='640x360' video::b='1M' video::minrate='1M' video::maxrate='1M' video::ar='' video::ref_frames='3' video::profile='Baseline' video::level='4.1' video::rc_type='cbr' audio::codec='aac' audio::ar='48000'";
            MWriter.WriterNameSet(@"\\192.168.0.100\MLFiles\Trash\Roman\WorkFiles\FilesFromCostumer\2019.05.27 Etere31929\test\"+ count.ToString() +".mp4", encodeConfig);
            MWriter.ObjectStart(MPlaylist);
            MPlaylist.FilePlayStart();

            Marshal.ReleaseComObject(item);
            //Marshal.ReleaseComObject(myBack);
            GC.Collect();


        }
        private void Button1_Click(object sender, EventArgs e)
        {
            StartBug();
        }
    }
}