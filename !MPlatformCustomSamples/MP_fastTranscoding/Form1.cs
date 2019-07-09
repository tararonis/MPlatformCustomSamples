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


namespace MP_fastTranscoding
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objPlaylist;
        MWriterClass m_objWriter;
        MFileClass m_objFile;
        const string destination = @"udp://192.168.0.104:5000";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objPlaylist = new MPlaylistClass();
            m_objWriter = new MWriterClass();
            m_objFile = new MFileClass();
            m_objFile.PreviewWindowSet("", panelPrev.Handle.ToInt32());
            m_objFile.PreviewEnable("", 0, 1);
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {           
            //m_objFile.PropsSet("active_frc", "false");
            //m_objFile.PropsSet("preview.drop_frames", "true");
            m_objFile.FileNameSet(openFile_txb.Text, "external_process=false experimental.mfcodecs=true experimental.out_video_packets=true");   
         
            m_objFile.FilePlayStart();

            m_objWriter.PropsSet("external_process", "false");
            //m_objWriter.PropsSet("rate_control", "true");
            //m_objWriter.PropsSet("pull_mode", "false");

            if(savePath_txb!=null)
                m_objWriter.WriterNameSet(savePath_txb.Text, "format='mp4' video::codec='packets' audio::codec='audio_packets'"); 
            else
                m_objWriter.WriterNameSet(destination, " format='mpegts' protocol='udp://' video::codec='packets' audio::codec='audio_packets'");
            
            m_objWriter.ObjectStart(m_objFile);
        }

        private void maxDuration_btn_Click(object sender, EventArgs e)
        {
            m_objWriter.PropsSet("max_duration", maxDur_txb.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_objFile.FilePlayStop(0);
            m_objWriter.ObjectClose();
        }
    }
}
