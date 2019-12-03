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

namespace MP_1563
{
    public partial class Form1 : Form
    {
        MFileClass m_objMFile;
        MPreviewClass m_objPreview;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMFile = new MFileClass();

            m_objMFile.OnFrameSafe += M_objMFile_OnFrameSafe;

            m_objPreview = new MPreviewClass();

            m_objPreview.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objPreview.PreviewEnable("", 1, 1);
        }

        private void M_objMFile_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            m_objPreview.ReceiverPutFrame("", pMFrame as MFrame);
        }
    }
}
