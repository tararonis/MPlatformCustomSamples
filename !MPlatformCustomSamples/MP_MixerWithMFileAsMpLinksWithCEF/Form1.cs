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
namespace MP_MixerWithMFileAsMpLinksWithCEF
{
    
    public partial class Form1 : Form
    {
        MFileClass m_objFile1;
        MFileClass m_objFile2;

        MFOverlayHTMLClass HTML5Plugin1;
        MFOverlayHTMLClass HTML5Plugin2;

        MMixerClass m_objMixer;

        MPlaylistClass m_objPlaylist;

        const string pathMFile1 = @"M:\MEDIA_TEST\!1080p 60fpsOri and the Will of the Wisps.mp4";
        const string pathMFile2 = @"M:\MEDIA_TEST\!LG Jazz 1080-30p.mp4";
        const string FilePlugin = "colorbars-hd";

        const string Html1 = "Html_Layer_1_Green.html";
        const string Html2 = "Html_Layer_2_Gray.html";

        public Form1()
        {
            InitializeComponent();

            MFFactoryClass m_objMFFactory = new MFFactoryClass();
            m_objMFFactory.PropsSet("hpu_pipeline", "false");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objFile1 = new MFileClass();
            m_objFile2 = new MFileClass();

            HTML5Plugin1 = new MFOverlayHTMLClass();
            HTML5Plugin2 = new MFOverlayHTMLClass();

            m_objPlaylist = new MPlaylistClass();

            m_objPlaylist.PreviewWindowSet("", panelPr.Handle.ToInt32());
            m_objPlaylist.PreviewEnable("", 1, 1);

            SetMFile();


        }

        private void SetMFile()
        {
            m_objFile1.FileNameSet(pathMFile1, "");

            m_objFile2.FileNameSet(pathMFile2, "");
        }
    }
}
