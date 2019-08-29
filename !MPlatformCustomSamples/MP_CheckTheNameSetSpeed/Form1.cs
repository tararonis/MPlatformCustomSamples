using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPLATFORMLib;

namespace MP_CheckTheNameSetSpeed
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objMPlaylist;
        MFileClass m_objMFile;
        MMixerClass m_objMixer;
        string filePath;
        DateTime startTime;
        DateTime endTime;
        TimeSpan duration;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void OpenFileMFile_btn_Click(object sender, EventArgs e)
        {
            MarshalAll();
            m_objMFile = new MFileClass();
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            {

                filePath = openFileDialog1.FileNames[0].ToString();

                SendMes("StatMFile");
                startTime = DateTime.Now;
                m_objMFile.FileNameSet(filePath, addParams.Text);
                endTime = DateTime.Now;
                CalcTimeSpan();
                SendMes("MFile takes: " + duration.TotalMilliseconds.ToString() + " TotalMilliseconds");
                SendMes("With this Params : " + addParams.Text);

                ReInitPr("MFile");
                m_objMFile.FilePlayStart();
            }

        }

        private void OpenFileMPlaylist_btn_Click(object sender, EventArgs e)
        {
            MarshalAll();
            m_objMPlaylist = new MPlaylistClass();
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            {
                filePath = openFileDialog1.FileNames[0].ToString();
                int index = -1;
                startTime = DateTime.Now;
                m_objMPlaylist.PlaylistAdd(null, filePath, addParams.Text, ref index, out MItem MItem);
                endTime = DateTime.Now;
                CalcTimeSpan();
                SendMes("MPlaylist takes: " + duration.TotalMilliseconds.ToString() + " TotalMilliseconds");
                SendMes("With this Params : " + addParams.Text);
                Marshal.ReleaseComObject(MItem);

                ReInitPr("MPlaylist");
                m_objMPlaylist.FilePlayStart();
            }


        }
        private void OpenFileMMixer_btn_Click(object sender, EventArgs e)
        {
            MarshalAll();
            m_objMixer = new MMixerClass();
            m_objMixer.ObjectStart(null);
            ReInitPr("MMixer");
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            {
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    MItem pItem;

                    startTime = DateTime.Now;
                    m_objMixer.StreamsAdd("", null, openFileDialog1.FileNames[i], addParams.Text, out pItem, 1.00);
                    endTime = DateTime.Now;
                    CalcTimeSpan();
                    SendMes("StreamsAdd takes: " + duration.TotalMilliseconds.ToString() + " TotalMilliseconds");
                    SendMes("With this Params : " + addParams.Text);

                    if (pItem != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
                        GC.Collect();
                    }
                }
                MElement root;
                m_objMixer.ElementsGetByIndex(0, out root);

                MElement pChild;

                startTime = DateTime.Now;
                (root as IMElements).ElementsAdd("", "video", "stream_id=stream-000 h=0.5 w=0.5 show=1", out pChild, 0);
                endTime = DateTime.Now;
                CalcTimeSpan();
                SendMes("ElementsAdd takes: " + duration.TotalMilliseconds.ToString() + " TotalMilliseconds");
                SendMes("With this Params : " + addParams.Text);

                Marshal.ReleaseComObject(pChild);

                m_objMixer.FilePlayStart();
            }

        }

        private void ReInitPr(string objectName)
        {
            if (objectName == "MFile")
            {
                m_objMFile.PreviewWindowSet("", panelpr.Handle.ToInt32());
                m_objMFile.PreviewEnable("", 0, 1);

            }
            else if (objectName == "MPlaylist")
            {
                m_objMPlaylist.PreviewWindowSet("", panelpr.Handle.ToInt32());
                m_objMPlaylist.PreviewEnable("", 0, 1);
            }
            else if (objectName == "MMixer")
            {
                m_objMixer.PreviewWindowSet("", panelpr.Handle.ToInt32());
                m_objMixer.PreviewEnable("", 0, 1);
            }
        }
        void MarshalAll()
        {
            SendMes("ReleaseAll");
            try
            {
                m_objMPlaylist.FilePlayStop(0);
                m_objMPlaylist.ObjectClose();
                Marshal.ReleaseComObject(m_objMPlaylist);
            }
            catch { }

            try
            {
                m_objMFile.FilePlayStop(0);
                m_objMFile.ObjectClose();
                Marshal.ReleaseComObject(m_objMFile);
            }
            catch { }
            try
            {
                m_objMixer.FilePlayStop(0);
                m_objMixer.ObjectClose();
                Marshal.ReleaseComObject(m_objMixer);
            }
            catch { }

            Thread.Sleep(200);
            GC.Collect();
            SendMes("----------------------------");
            SendMes("");
        }
        void SendMes(string mes)
        {
            Stat_lsb.Items.Add(mes);
        }
        void CalcTimeSpan()
        {
            duration = endTime - startTime;
        }
    }
}
