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


namespace MP_GetAllDevices
{
    public partial class Form1 : Form
    {
        MLiveClass m_objLive;
        public Form1()
        {
            InitializeComponent();
        }      

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objLive = new MLiveClass();

            m_objLive.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objLive.PreviewEnable("", 0, 1);

            m_objLive.DeviceGetCount(0, "video", out int count);

            for (int i = 0; i < count; i++)
            {
                string strName;
                string strDesc;
                //Get deveice / input line
                m_objLive.DeviceGetByIndex(0, "video", i, out strName, out strDesc);
                deviceList.Items.Add(strName);
            }
        }

        private void DeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbxChanged = (ComboBox)sender;           
            try
            {
                //Set device
                m_objLive.DeviceSet("video", (string)cbxChanged.SelectedItem, "");

                FillComboformat();

                m_objLive.ObjectStart(null);
            }
            catch
            {
                MessageBox.Show("Can't set this device, it isn't supported", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FillComboformat()
        {

            int nCount = 0;
            int nIndex;
            string strFormat;
            M_VID_PROPS vidProps;
            formats.Text = "";
            //Get video format count
            m_objLive.FormatVideoGetCount(eMFormatType.eMFT_Input, out nCount);
            formats.Enabled = nCount > 0;
            if (nCount > 0)
            {
                for (int i = 0; i < nCount; i++)
                {
                    //Get format by index
                    m_objLive.FormatVideoGetByIndex(eMFormatType.eMFT_Input, i, out vidProps, out strFormat);
                    //                        cbxTarget.Items.Add(vidProps.eVideoFormat);
                   
                    formats.Text = formats.Text + " " + strFormat;

                }
                //Check if there is selected format
                m_objLive.FormatVideoGet(eMFormatType.eMFT_Input, out vidProps, out nIndex, out strFormat);
               
            }
        }
    }
}
