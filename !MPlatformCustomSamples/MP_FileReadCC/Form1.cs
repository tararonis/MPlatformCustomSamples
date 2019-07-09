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

namespace MP_FileReadCC
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objPlaylist;
        MCCDisplay mcc;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mcc = new MCCDisplay();

            m_objPlaylist = new MPlaylistClass();
            m_objPlaylist.PreviewWindowSet("", panelPrev.Handle.ToInt32());
            m_objPlaylist.PreviewEnable("", 0, 1);

            m_objPlaylist.PropsSet("object::on_frame.sync", "true");
            m_objPlaylist.PropsSet("object::on_frame.data", "true");

            m_objPlaylist.OnEventSafe += M_objPlaylist_OnEventSafe;
            m_objPlaylist.OnFrameSafe += M_objPlaylist_OnFrameSafe;

            m_objPlaylist.PluginsAdd(mcc, 0);

            

        }

        private void M_objPlaylist_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            // (pMFrame as IMFrame).

            string CC;
            (pMFrame as IMFFrame).MFStrGet("C708", out CC);

            string CC2;
            (pMFrame as IMFFrame).MFStrGet("GA94", out CC2);

            string CC3;
            (pMFrame as IMFFrame).MFStrGet("C608", out CC3);

            if (CC != null)
                CC_lsb.Items.Add(CC);
            if (CC2 != null)
                CC_lsb.Items.Add(CC2);
            if (CC3 != null)
                CC_lsb.Items.Add(CC3);

            Marshal.ReleaseComObject(pMFrame);
        }

        private void M_objPlaylist_OnEventSafe(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            if(bsEventName== "SCTE-35")
            {
                MessageBox.Show("Event");
            }
        }

        int flagStart=0;
        private void Play_btn_Click(object sender, EventArgs e)
        {
            if (flagStart == 0)
            {
                m_objPlaylist.FilePlayStart();
                Play_btn.Text = "Pause";
                flagStart = 1;
                Play_btn.BackColor = Color.Red;
            }
            else if (flagStart == 1)
            {
                m_objPlaylist.FilePlayPause(0);
                Play_btn.Text = "Play";
                flagStart = 0;
                Play_btn.BackColor = Color.Green;
            }
        }
        MItem item;
        private void Open_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            {
                int index = -1;
               
                string name = openFileDialog1.FileNames[0].ToString();
                m_objPlaylist.PlaylistAdd(null, name, "", ref index, out item);
               
                Play_btn.BackColor = Color.Green;              
                
            }
        }

        

        private void Rate_Scroll(object sender, EventArgs e)
        {
            try
            {
                TrackBar comboBox = (TrackBar)sender;
                int selected = comboBox.Value;
                m_objPlaylist.FileRateSet(selected);

                double rate;
                m_objPlaylist.FileRateGet(out rate);
                label2.Text = rate.ToString();

            }
            catch(Exception ex)
            { MessageBox.Show(ex.ToString() + " --Method Rete_scroll"); }
        }

        string cc = "true";
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            (mcc as IMProps).PropsSet("show_subtitles", cc);

            cc = cc == "false" ? "true" : "false";
        }
    }
}
