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

namespace MP_ExTrueObjectsPid
{
    public partial class Form1 : Form
    {
        MLiveClass m_objLive1;
        MLiveClass m_objLive2;
        MLiveClass m_objLive3;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objLive1 = new MLiveClass();
            m_objLive2 = new MLiveClass();
            m_objLive3 = new MLiveClass();


            m_objLive1.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objLive1.PreviewEnable("", 0, 1);

            m_objLive2.PreviewWindowSet("", panel2.Handle.ToInt32());
            m_objLive2.PreviewEnable("", 0, 1);

            m_objLive3.PreviewWindowSet("", panel3.Handle.ToInt32());
            m_objLive3.PreviewEnable("", 0, 1);

            GetLive();

        }
        void GetLive()
        {
            int count;
            m_objLive1.DeviceGetCount(0, "video", out count);

            for (int i = 0; i < count; i++)
            {
                string name;
                string xml;
                m_objLive1.DeviceGetByIndex(0, "video", i, out name, out xml);

                listBox1.Items.Add(name);
            }

        }

        int count = 0;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox comboBox = (ListBox)sender;
            string selected = (string)comboBox.SelectedItem;
            if (count == 0)
            {
                m_objLive1.DeviceSet("video", selected, "");
                m_objLive1.ObjectStart(null);
            }
            else if (count == 1)
            { m_objLive2.DeviceSet("video", selected, "");
                m_objLive2.ObjectStart(null);
            }
            else if (count == 2)
            { m_objLive3.DeviceSet("video", selected, "");
                m_objLive3.ObjectStart(null);
            }
            count = count+1 == 3 ? 0: ++count;
        }

        private void GepPid_btn_Click(object sender, EventArgs e)
        {
            string pid1;
            string pid2;
            string pid3;
            m_objLive1.PropsGet("object::mserver_pid", out pid1);
            m_objLive2.PropsGet("object::mserver_pid", out pid2);
            m_objLive3.PropsGet("object::mserver_pid", out pid3);

            label1.Text = pid1;
            label2.Text = pid2;
            label3.Text = pid3;

        }
    }
}
