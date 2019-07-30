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
using System.Threading;

//using MLPROXYLib;

namespace MP_LicenseCheck
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objMPLaylistSource;
        MPlaylistClass m_objMPLaylistRecordFile;

        MWriterClass m_objWriter;

        const string pathOpen = @"M:\TEST_VIDEOS\!1080p 60fpsOri and the Will of the Wisps.mp4";
        const string pathSave = @"M:\TempVideo\saveFile.mp4";


        public Form1()
        {
            //MPlatformSDKLic.IntializeProtection();
            //EncoderlibLic.IntializeProtection();
            //DecoderlibLic.IntializeProtection();

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMPLaylistSource = new MPlaylistClass();
            m_objMPLaylistRecordFile = new MPlaylistClass();

            m_objMPLaylistSource.PreviewWindowSet("", panelPrSource.Handle.ToInt32());
            m_objMPLaylistSource.PreviewEnable("", 0, 1);

            m_objMPLaylistRecordFile.PreviewWindowSet("", panelPrRecordFile.Handle.ToInt32());
            m_objMPLaylistRecordFile.PreviewEnable("", 0, 1);

            m_objWriter = new MWriterClass();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int index = -1;
            m_objMPLaylistSource.PlaylistAdd(null, pathOpen, "", ref index, out MItem item);

            m_objMPLaylistSource.FilePlayStart();

            m_objWriter.WriterNameSet(pathSave, "format='mp4' video::codec='n264' audio::codec='aac'");

            m_objWriter.ObjectStart(m_objMPLaylistSource);

            Thread.Sleep(1000);

            int index2 = -1;
            m_objMPLaylistRecordFile.PlaylistAdd(null, pathSave, "", ref index, out MItem item2);

            m_objMPLaylistRecordFile.FilePlayStart();

        }

        private void Stop_btn_Click(object sender, EventArgs e)
        {
            m_objMPLaylistSource.FilePlayStop(0);
            m_objMPLaylistRecordFile.FilePlayStop(0);
            m_objWriter.ObjectClose();
        }
    }
}
