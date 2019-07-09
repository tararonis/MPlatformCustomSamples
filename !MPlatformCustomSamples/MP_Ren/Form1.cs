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

namespace MPRen
{
    public partial class Form1 : Form
    {
        MFileClass m_objFile;
        MRendererClass m_objRenderer;
       

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objFile = new MFileClass();
            
            m_objRenderer = new MRendererClass();

            m_objFile.PreviewWindowSet("", panelFile.Handle.ToInt32());
            m_objFile.PreviewEnable("", 0, 1);

           

            FileRenList();
            FileFormats();
        }

        private void openFile_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog a = new OpenFileDialog();
            if (a.ShowDialog() == DialogResult.OK)
            {
                m_objFile.FileNameSet(a.FileName, "");
                m_objFile.FilePlayStart();
            }
        }      

        void FileRenList()
        {
            renList_lsb.Items.Clear();

            int count;
            m_objRenderer.DeviceGetCount(0, "video", out count);

            string name;
            string xml;
            for (int i = 0; i < count; i++)
            {
                
                m_objRenderer.DeviceGetByIndex(0, "video", i, out name, out xml);
                renList_lsb.Items.Add(name);
            }
        }
        void FileFormats()
        {    

            formats_lsb.Items.Clear();
            formats_lsb.Items.Add("<Auto>");
            formats_lsb.Items.Add(eMVideoFormat.eMVF_NTSC);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_NTSC_16x9);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_PAL);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_PAL_16x9);

            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD720_50p);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD720_5994p);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD720_60p);

            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_24p);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_25p);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_2997p);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_30p);

            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_50i);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_50p);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_5994i);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_5994p);

            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_60i);
            formats_lsb.Items.Add(eMVideoFormat.eMVF_HD1080_60p);

        }

        private void renList_lsb_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_objRenderer.DeviceSet("video", renList_lsb.SelectedItem.ToString(), "");
            m_objRenderer.ObjectStart(m_objFile);
        }

       

        private void updateVideoFormats_btn_Click(object sender, EventArgs e)
        {
            FileFormats();
        }

        M_VID_PROPS props;
        private void formats_lsb_SelectedIndexChanged(object sender, EventArgs e)
        {            
            string name;
            int index;
            //m_objRenderer.FormatVideoGet(eMFormatType.eMFT_Output, out props, out index, out name);            
            props.eVideoFormat = (eMVideoFormat)formats_lsb.SelectedItem;            
        }

        private void changeRenFormat_btn_Click(object sender, EventArgs e)
        {
            m_objRenderer.FormatVideoSet(eMFormatType.eMFT_Convert, ref props);
        }
    }
}

