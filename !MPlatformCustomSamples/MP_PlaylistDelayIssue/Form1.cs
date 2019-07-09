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

namespace MP_PlaylistDelayIssue
{
    public partial class Form1 : Form
    {
        MPlaylistClass m_objPlaylist;
        
        MFileClass m_objFile;

        string path = @"\\MLDiskStation\MLFiles\MediaTest\MP4\!1080p 60fpsOri and the Will of the Wisps.mp4";
        public Form1()
        {
            InitializeComponent();
        }

        MItem item;
        private void Form1_Load(object sender, EventArgs e)
        {
            m_objFile = new MFileClass();
            m_objPlaylist = new MPlaylistClass();

            m_objFile.PreviewWindowSet("", panelPrFile.Handle.ToInt32());
            m_objFile.PreviewEnable("", 1, 1);

            m_objPlaylist.PreviewWindowSet("", panelPrPlaylist.Handle.ToInt32());
            m_objPlaylist.PreviewEnable("", 1, 1);



            int index = -1;
           

            m_objPlaylist.PlaylistAdd(null, path, "", ref index, out item);
            m_objPlaylist.FilePlayStart();

            m_objFile.FileNameSet(path, "");
            m_objFile.FilePlayStart();

            
        }

        private void AddURL_btn_Click(object sender, EventArgs e)
        {

        }

        private void AddMDelay_btn_Click(object sender, EventArgs e)
        {
            IMProps pPropsFile = (IMProps)m_objFile;
            pPropsFile.PropsSet("object::mdelay.enabled", "true");
            pPropsFile.PropsSet("object::mdelay.time", "5");
            pPropsFile.PropsSet("object::mdelay.buffer_duration", "5");

            IMProps pPropsPlaylist = (IMProps)m_objFile;
            pPropsPlaylist.PropsSet("object::mdelay.enabled", "true");
            pPropsPlaylist.PropsSet("object::mdelay.time", "5");
            pPropsPlaylist.PropsSet("object::mdelay.buffer_duration", "5");

            (item as IMProps).PropsSet("object::mdelay.enabled", "true");
            (item as IMProps).PropsSet("object::mdelay.time", "5");
            (item as IMProps).PropsSet("object::mdelay.buffer_duration", "5");

        }
    }
}
