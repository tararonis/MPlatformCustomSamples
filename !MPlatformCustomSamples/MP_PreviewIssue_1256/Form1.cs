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

namespace MP_PreviewIssue
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objMPlaylist;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMPlaylist = new MPlaylistClass();
        }
        private void Start_btn_Click(object sender, EventArgs e)
        {
            string[] list = {
            @"M:\TEST_VIDEOS\!1080p 60fpsOri and the Will of the Wisps.mp4", @"M:\TEST_VIDEOS\!audi_a7_borussia_vfl.mp4",
            @"M:\TEST_VIDEOS\!LG Jazz 1080-30p.mp4",
            @"M:\TEST_VIDEOS\!NoAudio1080p 60fpsOri and the Will of the Wisps.mp4",
            @"M:\TEST_VIDEOS\!PATAGONIA 1080p.mp4",
            @"M:\TEST_VIDEOS\Adele.mp4",
            @"M:\TEST_VIDEOS\Avengers_2_1080p_6Ch_48kHz-HDTN.mp4" };
            int period = 1000;

            (m_objMPlaylist as IMPreview).PreviewWindowSet("", panelPr.Handle.ToInt32());
            (m_objMPlaylist as IMPreview).PreviewEnable("", 1, 1);

            m_objMPlaylist.FilePlayStart();

            for (int i = 0; i < list.Length; i++)
            {
                m_objMPlaylist.PreviewFullScreen("", 0, 0);
                m_objMPlaylist.FileNameSet(list[i], "");
                m_objMPlaylist.FilePlayStart();
                Thread.Sleep(period*2);
                m_objMPlaylist.PreviewFullScreen("", 1, 0);
                Thread.Sleep(period);              
                
            }
            m_objMPlaylist.PreviewFullScreen("", 0, 0);
        }

        
    }
}
