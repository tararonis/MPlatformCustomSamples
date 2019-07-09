using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_mpLinksVideoSize
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objPlaylistPub;
        MPlaylistClass m_objPlaylistRec;

        private static System.Timers.Timer aTimer;

        public delegate void InvokeDelegate();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objPlaylistPub = new MPlaylistClass();
            m_objPlaylistPub.PreviewWindowSet("", panelPub.Handle.ToInt32());
            m_objPlaylistPub.PreviewEnable("", 0, 1);

            m_objPlaylistRec = new MPlaylistClass();
            m_objPlaylistRec.PreviewWindowSet("", panelRec.Handle.ToInt32());
            m_objPlaylistRec.PreviewEnable("", 0, 1);

            int index=-1;
            m_objPlaylistPub.PlaylistAdd(null, @"\\MLDiskStation\MLFiles\MediaTest\MP4\!1080p 60fpsOri and the Will of the Wisps.mp4", "", ref index, out MItem item);
            m_objPlaylistPub.FilePlayStart();


            Thread.Sleep(100);

            MSendersClass senderMP = new MSendersClass();
            int count;
            senderMP.SendersGetCount(out count);

            for (int i = 0; i < count; i++)
            {
                senderMP.SendersGetByIndex(i, out string name, out M_VID_PROPS propsV, out M_AUD_PROPS propsA);
                senders_lsb.Items.Add(name);
            }
        }

        MItem item;
        private void Senders_lsb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox comboBox = (ListBox)sender;
            string selected = (string)comboBox.SelectedItem;

            int index = -1;
            m_objPlaylistRec.PlaylistAdd(null, "mp://" + selected, "", ref index, out item);

            m_objPlaylistRec.FilePlayStart();

            aTimer = new System.Timers.Timer(500);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            BeginInvoke(new InvokeDelegate(GetDATA));
           
        }
        void GetDATA()
        {
            data_lsb.Items.Clear();

            M_VID_PROPS propsV;
            int index;
            string name;
            (item as IMFormat).FormatVideoGet(eMFormatType.eMFT_Convert, out propsV, out index, out name);
            data_lsb.Items.Add("convert: " + propsV.nHeight.ToString() + "--" + propsV.nWidth.ToString());
            (item as IMFormat).FormatVideoGet(eMFormatType.eMFT_Input, out propsV, out index, out name);
            data_lsb.Items.Add("input: " + propsV.nHeight.ToString() + "--" + propsV.nWidth.ToString());
            (item as IMFormat).FormatVideoGet(eMFormatType.eMFT_Output, out propsV, out index, out name);
            data_lsb.Items.Add("output: " + propsV.nHeight.ToString() + "--" + propsV.nWidth.ToString());
            (item as IMFormat).FormatVideoGet(eMFormatType.eMFT_Override, out propsV, out index, out name);
            data_lsb.Items.Add("override: " + propsV.nHeight.ToString() + "--" + propsV.nWidth.ToString());
        }
    }
}
