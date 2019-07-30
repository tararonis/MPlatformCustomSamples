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

namespace MP_FileEventTest
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objMPlaylist;
        string test_file = @"\\192.168.0.100\MLFiles\Trash\Roman\WorkFiles\FilesFromCostumer\2019.09.05Pablo32816\6_JasonBecker_0bDdrnuWBVIz+n1ScRyNOk.mp4";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMPlaylist = new MPlaylistClass();
            m_objMPlaylist.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objMPlaylist.PreviewEnable("", 1, 1);
        }
        MItem item1;
        private void button1_Click(object sender, EventArgs e)
        {
            //string test_file = @"\\MLDiskStation\MLFiles\MediaTest\MP4\!1080p 60fpsOri and the Will of the Wisps.mp4";
            int index = -1;
            m_objMPlaylist.PlaylistAdd(null, test_file, "", ref index, out item1);
           
            m_objMPlaylist.PlaylistAdd(null, @"M:\TEST_VIDEOS\!1080p 60fpsOri and the Will of the Wisps.mp4", "", ref index, out MItem item2);


            m_objMPlaylist.OnEventSafe += File_OnEventSafe;
            m_objMPlaylist.FilePlayStart();            
        }

        int num = 1;
        private void File_OnEventSafe(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            
            if (bsEventName == "switch")
            {
                ++num;
                MessageBox.Show("Switch is " + num.ToString());                
            }
            if (bsEventName == "EOF")
            {
                ++num;
                MessageBox.Show("EOF is " + num.ToString());                
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            m_objMPlaylist.FilePlayPause(0);
        }

        
        string[] previewTypes = { "dx11", "dx9", "dshow" };
        int n = 0;
        private void ChangePreviewType_btn_Click(object sender, EventArgs e)
        {
            m_objMPlaylist.PropsSet("preview.type", previewTypes[n]);
            ChangePreviewType_btn.Text = "ChangePreviewType Cur- " + previewTypes[n];
            n = ++n == 3 ? 0 : n;
        }

        private void SeekToTheEnd_btn_Click(object sender, EventArgs e)
        {

            item1.FilePosSet(315, 0);
        }
    }
}
