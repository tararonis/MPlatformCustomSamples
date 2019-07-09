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

namespace MP_liveExternal
{
    public partial class Form1 : Form
    {
        MLiveClass m_objLive;
        //MFileClass m_
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objLive = new MLiveClass();

            m_objLive.PreviewWindowSet("", panelPrev.Handle.ToInt32());
            m_objLive.PreviewEnable("", 1, 1);

            int count;
            m_objLive.DeviceGetCount(0, "video", out count);

            for (int i = 0; i < count; i++)
            {

                string name;
                string xml;
                m_objLive.DeviceGetByIndex(0, "video", i, out name,out xml);

                deviceList_lsb.Items.Add(name);

            }
            
            m_objLive.DeviceGetCount(0, "ext_audio", out count);

            for (int i = 0; i < count; i++)
            {

                string name;
                string xml;
                m_objLive.DeviceGetByIndex(0, "ext_audio", i, out name, out xml);

                EXdeviceList_lsb.Items.Add(name);

            }


        }

        private void deviceList_lsb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox comboBox = (ListBox)sender;
            string selected = (string)comboBox.SelectedItem;
            m_objLive.DeviceSet("video", selected, "");
            m_objLive.ObjectStart(null);
           
        }

        private void test_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
