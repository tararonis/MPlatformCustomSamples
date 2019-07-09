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
        MFileClass m_objFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objFile = new MFileClass();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string test_file = @"M:\MEDIA_TEST\!1080p 60fpsOri and the Will of the Wisps.mp4";
            m_objFile.FileNameSet(test_file, "");
            m_objFile.PreviewWindowSet("", panel1.Handle.ToInt64());
            m_objFile.PreviewEnable("", 1, 1);
            m_objFile.OnEventSafe += File_OnEventSafe;
            m_objFile.FilePlayStart();

            m_objFile.PropsSet("preview.type", "dx9");
        }


        private void File_OnEventSafe(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            if (bsEventName == "pause")
            {
                MessageBox.Show("File Paused");
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            m_objFile.FilePlayPause(0);
        }
    }
}
