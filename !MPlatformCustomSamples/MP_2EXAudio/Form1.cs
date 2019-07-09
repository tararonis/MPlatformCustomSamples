using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_2EXAudio
{
    public partial class Form1 : Form
    {
        MLiveClass m_objLive;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objLive = new MLiveClass();

            m_objLive.OnFrameSafe += M_objLive_OnFrameSafe;

            m_objLive.PropsSet("preview::overlay_rms", "true");
            m_objLive.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objLive.PreviewEnable("", 1, 1);

            GetVideoList();
            GetAudioList();
        }        

        void GetVideoList()
        {
            ListOfVideo.Items.Clear();
            int count;
            m_objLive.DeviceGetCount(0, "video", out count);

            string name;
            string xml;
            for (int i = 0; i < count; i++)
            {
                m_objLive.DeviceGetByIndex(0, "video", i, out name, out xml);
                ListOfVideo.Items.Add(name);
            }
            
        }
        void GetAudioList()
        {
            ListOfExAudio.Items.Clear();
            int count;
            m_objLive.DeviceGetCount(0, "ext_audio", out count);

            string name;
            string xml;
            for (int i = 0; i < count; i++)
            {
                m_objLive.DeviceGetByIndex(0, "ext_audio", i, out name, out xml);
                ListOfExAudio.Items.Add(name);
            }
        }

        private void ListOfVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox comboBox = (ListBox)sender;
            string selected = (string)comboBox.SelectedItem;
            m_objLive.PropsSet("audio_channels", "");
            m_objLive.DeviceSet("video", selected, "");
            m_objLive.DeviceSet("audio", "<No Audio>", "");
            m_objLive.ObjectStart(null);



        }

        int exCase = 0;
        private void ListOfExAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox comboBox = (ListBox)sender;
            string selected = (string)comboBox.SelectedItem;

            if (exCase == 0)
            {
                m_objLive.DeviceSet("ext_audio", selected, "");
                //m_objLive.PropsSet("object::ext_audio.insert_to_channels", "12,13");
            }

            else if (exCase == 1)
            {
                m_objLive.DeviceSet("ext_audio.2", selected, "");
                //m_objLive.PropsSet("object::ext_audio.2.insert_to_channels", "1");
            
            }

            exCase = ++exCase == 2 ? 0 : exCase;

        }

        void GetVU()
        {
            if (GetVU_btn.Checked)
            {
                MFrame frame;
                m_objLive.SourceFrameGet(-1, out frame, 0);

                //m_objLive.PropsSet("file::audio_track", "all");
                
                M_AV_PROPS props;
                frame.FrameAVPropsGet(out props);

                float[] audio = props.ancData.audOutput.arrVUMeter;

                CountOfTracks_lbl.Text = props.ancData.audOutput.nValidTracks.ToString();
               
                ListVU_lst.Items.Clear();
                for (int i = 0; i < audio.Length; i++)
                {
                    if (audio[i] != 0) //audio[i] > -120 && 
                    {
                        ListVU_lst.Items.Add(i +"--"+ audio[i]);
                    }
                }

                int countTr;
                m_objLive.AudioTracksGetCount(out countTr);

                Gain_lst.Items.Clear();
                for (int i = 0; i < countTr; i++)
                {
                    string desc;
                    IMAudioTrack track;
                    m_objLive.AudioTrackGetByIndex(i, out desc, out track);

                    int inChan;
                    int outChanDX;
                    int outChan;

                    track.TrackChannelsGet(out inChan, out outChanDX, out outChan);

                    M_AUDIO_TRACK_LOUDNESS loudOrg;
                    M_AUDIO_TRACK_LOUDNESS loudOut;
                    track.TrackLoudnessGet(out loudOrg, out loudOut);

                    for (int x = 0; x < outChan; x++)
                    {
                        double gain = 0;
                        track.TrackGainGet(x, out gain);                        

                        Gain_lst.Items.Add(i + " - " + x + " - " + gain + " - " + loudOut.arrVUMeter[x]);
                    }

                }

                Marshal.ReleaseComObject(frame);
            }
        }

        int count = 0;
        private void M_objLive_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            if (count % 10 == 0)
            {
                GetVU();
            }
            count++;
            Marshal.ReleaseComObject(pMFrame);
        }
    }
}
