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

namespace MP_SimpleMixer
{
    public partial class Form1 : Form
    {
        MMixerClass m_objMixer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMixer = new MMixerClass();

            m_objMixer.PreviewWindowSet("", panelPrev.Handle.ToInt32());
            m_objMixer.PreviewEnable("", 1, 1);

            m_objMixer.ObjectStart(null);           

            //AddAndSetScene();
        }

        private void openFile_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
            {

                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    MItem pItem;
                    m_objMixer.StreamsAdd("", null, openFileDialog1.FileNames[i], "", out pItem, 1.00);
                    if (pItem != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(pItem);
                        GC.Collect();
                    }
                }
            }
            UpdateListOfStreams();
        }
        
        void UpdateListOfStreams()
        {
            listOfStreams_ltb.Items.Clear();
            int nFiles = 0;
            m_objMixer.StreamsGetCount(out nFiles);
            for (int i = 0; i < nFiles; i++)
            {
                MItem pItem;
                string strStreamID;
                string strFile;
                m_objMixer.StreamsGetByIndex(i, out strStreamID, out pItem);
                
                pItem.FileNameGet(out strFile);

                listOfStreams_ltb.Items.Add(string.Format("{0}/{1}", strStreamID, strFile));
            }
        }

        private void listOfStreams_ltb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ListBox comboBox = (ListBox)sender;
            string selected = (string)comboBox.SelectedItem;

            string strStreamID;
            Parse(selected, out strStreamID);

            string sceneID;
            int sceneIndex;

            MElement root;
            m_objMixer.ElementsGetByIndex(0, out root);
            
            MElement pChild;
            (root as IMElements).ElementsAdd("", "video", "stream_id=" + strStreamID + " h=0.5 w=0.5 show=1", out pChild, 0);

            m_objMixer.FilePlayStart();

        }
        void Parse(string inValue, out string streamID)
        {
            string[] split = inValue.Split('/');
            streamID = split[0];
        }

        //void AddAndSetScene()
        //{
        //    IMElements pNewScene;
        //    string strName = "mixer_scene";
        //    m_objMixer.ScenesAdd("", ref strName, out pNewScene);

        //    m_objMixer.ScenesActiveSet(strName, "");

        //}
    }
}

