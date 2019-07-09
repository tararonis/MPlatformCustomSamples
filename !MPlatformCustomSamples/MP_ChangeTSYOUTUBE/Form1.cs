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

namespace MP_ChangeTSYOUTUBE
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

            m_objFile.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objFile.PreviewEnable("", 1, 1);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            m_objFile.FileNameSet("https://www.youtube.com/watch?v=RVeVtBxoImI", "");
            m_objFile.FilePlayStart();
        }

        private void Button2_Click(object sender, EventArgs e)
        {        
        // call the method
            GetFileInfo("");

            string count1;
            m_objFile.PropsGet("file::info::ts_programs", out count1);            

            //listBox1.Items.Add(count);
            m_objFile.PropsSet("file::ts_program", "4");            
        }

        private string fileInfo = string.Empty;
        private void GetFileInfo(string propertyNode)
        {
            int nCount = 0;
            try
            {
            // get a number of properties
            m_objFile.PropsGetCount(propertyNode, out nCount);
            }
            catch (Exception) { }
            for (int i = 0; i < nCount; i++)
            {
                string sName;
                string sValue;
                int bNode = 0;
            m_objFile.PropsGetByIndex(propertyNode, i, out sName, out sValue, out bNode);
                // bNode flag indicates whether there are internal properties
                // to collect a full node name we should separated it with "::", e.g. "info::video.0"
                string sRelName = propertyNode.Length > 0 ? propertyNode + "::" + sName : sName;
                if (bNode != 0)
                {
                    GetFileInfo(sRelName); // call the method recursively in case of sub-nodes
                }
                else
                {
                    fileInfo += sRelName + " = " + sValue + Environment.NewLine;
                }
            }
        }


    }
}
