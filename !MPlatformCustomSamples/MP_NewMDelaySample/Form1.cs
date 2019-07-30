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

namespace MP_NewMDelaySample
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

            m_objMPlaylist.PreviewWindowSet("", panelPreview.Handle.ToInt64());
            m_objMPlaylist.PreviewEnable("", 1, 1);
        }

        private void OpenFile_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
