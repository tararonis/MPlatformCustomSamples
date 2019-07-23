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

namespace MP_CororConvertinWithMatrixTransformation
{
    public partial class Form1 : Form
    {         
        MPlaylistClass m_objMPLaylist;
        string filePath = String.Empty;
        MFFactoryClass m_objMFFactory;
        string[] predifinedMatrixes = { "BT2020_BT709", "BT709_BT2020", "RGB_YUV_601", "RGB_YUV_709", "RGB_YUV_2020", "YUV_RGB_601", "YUV_RGB_709", "YUV_RGB_2020", "Full_To_16_235", "Full_From_16_235" };
        bool gpu_p = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var s in predifinedMatrixes)
            {
                PredifinedMatrix_txb.Items.Add(s);
            }
            m_objMPLaylist = new MPlaylistClass();
        }

        private void GpuPipilineOn_btn_Click(object sender, EventArgs e)
        {
            if (!gpu_p)
            {
                m_objMFFactory = new MFFactoryClass();
                m_objMFFactory.PropsSet("gpu_pipeline", "true");

                gpu_p = true;
                GpuPipilineOn_btn.Text = "GPU PIPELINE = ON";
                GpuPipilineOn_btn.BackColor = Color.Green;

                PredifinedMatrix_txb.Enabled = true;
                ColorLevel_cmb.Enabled = true;
                R_trb.Enabled = true;
                G_trb.Enabled = true;
                B_trb.Enabled = true;
                Level_trb.Enabled = true;

                m_objMPLaylist.FilePosGet(out double position);
                m_objMPLaylist.FilePlayStop(0);
                Marshal.ReleaseComObject(m_objMPLaylist);

                m_objMPLaylist = new MPlaylistClass();

                m_objMPLaylist.PreviewWindowSet("", panelPr.Handle.ToInt32());
                m_objMPLaylist.PreviewEnable("", 1, 1);

                if (filePath != null)
                {
                    index = -1;

                    m_objMPLaylist.PlaylistAdd(null, filePath, "", ref index, out item);
                    m_objMPLaylist.FilePosSet(position, 0);
                    m_objMPLaylist.FilePlayStart();
                }
            }


        }

        int index = -1;
        MItem item;
        private void OpenFile_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            { 
                filePath = openFileDialog1.FileNames[0].ToString();
                m_objMPLaylist.PlaylistAdd(null, filePath, "", ref index, out item);
            }
            m_objMPLaylist.PreviewWindowSet("", panelPr.Handle.ToInt32());
            m_objMPLaylist.PreviewEnable("", 1,1);
            m_objMPLaylist.FilePlayStart();        
    }

        private void SetColorConvertion_btn_Click(object sender, EventArgs e)
        {

        }

        
    }
}
