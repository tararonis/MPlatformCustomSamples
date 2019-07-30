using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPLATFORMLib;


namespace MP_EtereDPX_32828
{
    public partial class Form1 : Form
    {
        string path = @"M:\TempVideo\IS_Adele\ISadele\*.dpx";
        MFileClass m_objMFile;
        MPlaylistClass m_objMPlaylist;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMFile = new MFileClass();
            m_objMPlaylist = new MPlaylistClass();

            m_objMPlaylist.PreviewWindowSet("", panelPr.Handle.ToInt32());
            m_objMPlaylist.PreviewEnable("", 0, 1);
        }

        private void Play_btn_Click(object sender, EventArgs e)
        {
            
            //m_objMFile.FileNameSet(path, "loop=true");
            int index = -1;
            m_objMPlaylist.PlaylistAdd(null, path, "", ref index, out MItem item);
            m_objMPlaylist.FilePlayStart();
            //m_objMFile.FilePlayStart();

        }

        private void RelocateAllHidenFiles_btn_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(@"M:\TempVideo\IS_Adele\ISadele");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.dpx"); //Getting DPX files
            string str = "";
            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
            }
            //string[] filePaths = Directory.GetFiles(@"M:\TempVideo\IS_Adele\ISadele", "*.dpx",
            //                             SearchOption.TopDirectoryOnly);
            for (int i = 0; i < Files.Length; i++)
            {
                //System.IO.Directory.CreateDirectory(@"M:\TempVideo\IS_Adele\ISadele\replace");
                System.IO.Directory.CreateDirectory(@"M:\TempVideo\IS_Adele\ISadele\move");
                if (Files[i].Attributes.HasFlag(FileAttributes.Hidden))
                {
                    File.Move(Files[i].FullName, @"M:\TempVideo\IS_Adele\ISadele\move\" + Files[i].Name);
                }
            }
           
        }
    }
}
