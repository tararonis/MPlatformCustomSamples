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
        MFileClass m_objMFile;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMFile = new MFileClass();
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

            (m_objMFile as IMPreview).PreviewWindowSet("", panelPr.Handle.ToInt32());
            (m_objMFile as IMPreview).PreviewEnable("", 1, 1);

            
            Thread.Sleep(period);
            int index = -1;
            for (int i = 0; i < list.Length; i++)
            {
                m_objMFile.PreviewFullScreen("", 0, 0);
                //m_objMFile.PlaylistAdd(null, list[i], "", ref index, out MItem item);
                //m_objMFile.PlaylistPosSet(0, 0, 0);
                //m_objMPlaylist.PlaylistGetCount(out int nFiles, out double dblDuration);
                //m_objMPlaylist.PlaylistGetByIndex(nFiles, out double dblPos, out string strPathOrCommand, out MItem pItem);
                m_objMFile.FileNameSet(list[i], "");
                m_objMFile.FilePlayStart();
                Thread.Sleep(period*2);
                m_objMFile.PreviewFullScreen("", 1, 0);
                Thread.Sleep(period);              
                
            }
            m_objMFile.PreviewFullScreen("", 0, 0);
        }

        
    }
}
