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

namespace MP_GetBytes
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objPlaylist;
        MFFactoryClass m_objMFFactory;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void OpenFile_btn_Click(object sender, EventArgs e)
        {
            m_objPlaylist = new MPlaylistClass();

            m_objPlaylist.OnFrameSafe += M_objPlaylist_OnFrameSafe;

            m_objPlaylist.PreviewWindowSet("", panelPrev.Handle.ToInt32());
            m_objPlaylist.PreviewEnable("", 0, 1);

            
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            {
                int index = -1;
                MItem item;

                string name = openFileDialog1.FileNames[0].ToString();
                m_objPlaylist.PlaylistAdd(null, name, "", ref index, out item);
            }
            m_objPlaylist.FilePlayStart();
            
        }
        int size;
        long video;
        int count = 0;
        private void M_objPlaylist_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            if (count % 20 == 0)
            {
                MFrame frame;
                m_objPlaylist.SourceFrameGet(-1, out frame, 0);

                frame.FrameVideoGetBytes(out size, out video);

                label1.Text = size.ToString();
                label2.Text = video.ToString();

                (pMFrame as IMFrame).FrameVideoGetBytes(out size, out video);

                label3.Text = size.ToString();
                label4.Text = video.ToString();
                
            }
            count++;
        }

        private void Reproduce_btn_Click(object sender, EventArgs e)
        {
            try
            {
                m_objPlaylist.FilePlayStop(0);
                Marshal.ReleaseComObject(m_objPlaylist);
            }
            catch
            { }
            m_objMFFactory = new MFFactoryClass();
            m_objMFFactory.PropsSet("gpu_pipeline", "true");

            OpenFile_btn_Click(null, null);
        }
    }
}
