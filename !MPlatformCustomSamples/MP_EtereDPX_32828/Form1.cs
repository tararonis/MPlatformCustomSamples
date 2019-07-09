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


namespace MP_EtereDPX_32828
{
    public partial class Form1 : Form
    {
        string path = @"M:\TempVideo\IS_Adele\ISadele\*.dpx";
        MFileClass m_objMFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMFile = new MFileClass();

            m_objMFile.PreviewWindowSet("", panelPr.Handle.ToInt32());
            m_objMFile.PreviewEnable("", 0, 1);
        }

        private void Play_btn_Click(object sender, EventArgs e)
        {
            MFile myFile = new MFile();
            m_objMFile.FileNameSet(path, "loop=true");

            m_objMFile.FilePlayStart();

        }
    }
}
