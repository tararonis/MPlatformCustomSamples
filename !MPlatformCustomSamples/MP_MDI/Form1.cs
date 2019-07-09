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

namespace MP_MDI
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objPlaylist;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objPlaylist = new MPlaylistClass();

            m_objPlaylist.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objPlaylist.PreviewEnable("", 0, 1);

            int index = -1;
            MItem item;
            m_objPlaylist.PlaylistAdd(null, @"M:\MEDIA_TEST\!LG Jazz 1080-30p.mp4", "", ref index, out item);

            m_objPlaylist.FilePlayStart();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("FU");
        }

        private void Panel1_DragOver(object sender, DragEventArgs e)
        {
            MessageBox.Show("FU");
        }

        private void Panel1_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("FU");
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            MessageBox.Show("Panel1_Paint");
        }

        private void Panel1_MouseEnter(object sender, EventArgs e)
        {
            //MessageBox.Show("Panel1_MouseEnter");
        }
    }
}
