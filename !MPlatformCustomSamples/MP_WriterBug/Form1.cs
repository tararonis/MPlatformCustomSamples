using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_WriterBug
{
    public partial class Form1 : Form
    {
        MWriterClass m_objWriter;
        MPlaylistClass m_objPlaylist;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            m_objPlaylist = new MPlaylistClass();
            m_objWriter = new MWriterClass();

            m_objPlaylist.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objPlaylist.PreviewEnable("", 1, 1);


            //m_objPlaylist.PropsSet("loop", "false");
            //m_objPlaylist.PropsSet("active_frc", "false");
            //m_objPlaylist.PropsSet("preview.drop_frames", "true");
            int index = -1;
            MItem item;
            //m_objPlaylist.PlaylistAdd(null, @"M:\MEDIA_TEST\A QUALCUNO PIACE CALDO.mkv", "external_process=false", ref index, out item);
            m_objPlaylist.PlaylistAdd(null, @"M:\MEDIA_TEST\A QUALCUNO PIACE CALDO.mkv", "", ref index, out item);
        }
        int count = 0;
        private void Repr_btn_Click(object sender, EventArgs e)
        {
            m_objPlaylist.FilePlayStart();
            //m_objWriter.PropsSet("external_process", "false");
            //m_objWriter.PropsSet("rate_control", "true");
            //m_objWriter.PropsSet("pull_mode", "false");

            m_objWriter.WriterNameSet(@"M:\TempVideo\" + count.ToString() + ".mp4", "format='mp4' video::codec='n264' audio::codec='aac' video::b=100M");
            m_objWriter.ObjectStart(m_objPlaylist);

            

            //m_objPlaylist.FilePlayStart();
            //m_objWriter.WriterNameSet(@"M:\TempVideo\2.mp4", "format='mp4' video::codec='n264' audio::codec='aac'");
            //m_objWriter.ObjectStart(m_objPlaylist);


        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(2000);
            m_objWriter.ObjectClose();
            m_objPlaylist.FilePlayStop(0);
            count++;
        }
    }
}
