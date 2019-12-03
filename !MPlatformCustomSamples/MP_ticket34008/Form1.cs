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

namespace MP_ticket34008
{
    public partial class Form1 : Form
    {

        MFileClass m_objMFile1;
        MFileClass m_objMFile2;
        MFileClass m_objMFile3;
        MFileClass m_objMFile4;

        MPreviewClass m_objPreview1;
        MPreviewClass m_objPreview2;
        MPreviewClass m_objPreview3;
        MPreviewClass m_objPreview4;

        List<string> sources = new List<string> { @"udp://239.0.0.1:1111", @"udp://239.0.0.1:2222", @"udp://239.0.0.1:3333", @"udp://239.0.0.1:4444",
        @"M:\TEST_VIDEOS\!1080p 60fpsOri and the Will of the Wisps.mp4",
@"M:\TEST_VIDEOS\!audi_a7_borussia_vfl.mp4",
@"M:\TEST_VIDEOS\!Corey Taylor - Live in London (Full Show).mp4",
@"M:\TEST_VIDEOS\!LG Jazz 1080-30p.mp4",
@"M:\TEST_VIDEOS\!NoAudio1080p 60fpsOri and the Will of the Wisps.mp4",
@"M:\TEST_VIDEOS\!PATAGONIA 1080p.mp4",
@"M:\TEST_VIDEOS\!TestRecord.mp4"};
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMFile1 = new MFileClass();


            m_objPreview1 = new MPreviewClass();
            m_objPreview1.PreviewWindowSet("", panel1.Handle.ToInt32());
            m_objPreview1.PreviewEnable("", 0, 1);

            m_objPreview1.ObjectStart(null);

            m_objMFile2 = new MFileClass();
            m_objPreview2 = new MPreviewClass();
            m_objPreview2.PreviewWindowSet("", panel2.Handle.ToInt32());
            m_objPreview2.PreviewEnable("", 0, 1);

            m_objMFile3 = new MFileClass();
            m_objPreview3 = new MPreviewClass();
            m_objPreview3.PreviewWindowSet("", panel3.Handle.ToInt32());
            m_objPreview3.PreviewEnable("", 0, 1);

            m_objMFile4 = new MFileClass();
            m_objPreview4 = new MPreviewClass();
            m_objPreview4.PreviewWindowSet("", panel4.Handle.ToInt32());
            m_objPreview4.PreviewEnable("", 0, 1);

            m_objMFile1.OnFrameSafe += M_objMFile1_OnFrameSafe;

            m_objMFile2.OnFrameSafe += M_objMFile2_OnFrameSafe;

            m_objMFile3.OnFrameSafe += M_objMFile3_OnFrameSafe;

            m_objMFile4.OnFrameSafe += M_objMFile4_OnFrameSafe;

            foreach (var s in sources)
            {
                listBox1.Items.Add(s);
                listBox2.Items.Add(s);
                listBox3.Items.Add(s);
                listBox4.Items.Add(s);
            }
        }

        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;

        int interval = 40;
        private void M_objMFile1_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            if (count1 % interval == 0)
            {

                m_objPreview1.ReceiverPutFrame("", pMFrame as MFrame);
            }

            Marshal.ReleaseComObject(pMFrame);
            count1++;
        }

        private void M_objMFile2_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            if (count2 % interval == 0)
            {
                m_objPreview2.ReceiverPutFrame("", pMFrame as MFrame);
            }
            Marshal.ReleaseComObject(pMFrame);
            count2++;
        }

        private void M_objMFile4_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            if (count3 % interval == 0)
            {
                MFrame frame = pMFrame as MFrame;
                m_objPreview3.ReceiverPutFrame("", pMFrame as MFrame);
            }
            Marshal.ReleaseComObject(pMFrame);
            count3++;
        }

        private void M_objMFile3_OnFrameSafe(string bsChannelID, object pMFrame)
        {
            if (count4 % interval == 0)
            {

                m_objPreview4.ReceiverPutFrame("", pMFrame as MFrame);
            }
            Marshal.ReleaseComObject(pMFrame);
            count4++;
        }



        private void start_btn_Click(object sender, EventArgs e)
        {
            InitSource(turn);
            timer1.Enabled = true;
        }

        int turn = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            InitSource(turn);


        }

        private void InitSource(int index)
        {
            listBox1.SelectedIndex = index % sources.Count;
            
            m_objMFile1.FileNameSet(sources[index % sources.Count], "network.open_async=true open_url.max_wait=0");
            m_objMFile1.FilePlayStart();

            listBox2.SelectedIndex = (index + 1) % sources.Count;
            
            m_objMFile2.FileNameSet(sources[(index + 1) % sources.Count], "network.open_async=true open_url.max_wait=0");
            m_objMFile2.FilePlayStart();

            listBox3.SelectedIndex = (index + 2) % sources.Count;
           
            m_objMFile3.FileNameSet(sources[(index + 2) % sources.Count], "network.open_async=true open_url.max_wait=0");
            m_objMFile3.FilePlayStart();

            listBox4.SelectedIndex = (index + 3) % sources.Count;
            
            m_objMFile4.FileNameSet(sources[(index + 3) % sources.Count], "network.open_async=true open_url.max_wait=0");
            m_objMFile4.FilePlayStart();

            turn++;
        }
    }
}
