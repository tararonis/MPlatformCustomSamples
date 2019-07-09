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

namespace MP_WrongTimeCode_Etere31735
{
    public partial class Form1 : Form
    {
        MFileClass m_objMFile;
        MPlaylistClass m_objPlaylist;

        public Form1()
        {
            InitializeComponent();
        }
        MItem item;
        private void Form1_Load(object sender, EventArgs e)
        {
            m_objMFile = new MFileClass();
            m_objPlaylist = new MPlaylistClass();

            m_objMFile.PreviewWindowSet("", panelPr.Handle.ToInt32());
            m_objMFile.PreviewEnable("", 0, 1);

            m_objMFile.FileNameSet(@"\\192.168.0.100\MLFiles\Trash\Roman\WorkFiles\FilesFromCostumer\2019.03.06Etere31735\MEM001M-20190306Z143546.mp4", "loop=true");

            m_objMFile.FilePlayStart();

            m_objPlaylist.PreviewWindowSet("", panelPrPl.Handle.ToInt32());
            m_objPlaylist.PreviewEnable("", 0, 1);

            int index = -1;            
            m_objPlaylist.PlaylistAdd(null, @"\\192.168.0.100\MLFiles\Trash\Roman\WorkFiles\FilesFromCostumer\2019.03.06Etere31735\MEM001M-20190306Z143546.mp4", "loop=true", index, out item);
            m_objPlaylist.FilePlayStart();

        }
        
        private void GetTC_btn_Click(object sender, EventArgs e)
        {
            M_TIMECODE timeCodeIn;
            M_TIMECODE timeCodeOut;
            int outSpec;
            m_objMFile.FileInOutGetTC(out timeCodeIn, out timeCodeOut, out outSpec);
            timeCode_lbl.Text = string.Format("{0:D2}: {1:D2}: {2:D2}. {3:D3}", timeCodeIn.nHours, timeCodeIn.nMinutes, timeCodeIn.nSeconds, timeCodeIn.nFrames);

            
            item.FileInOutGetTC(out timeCodeIn, out timeCodeOut, out outSpec);
            TimeCodePl_lbl.Text = string.Format("{0:D2}: {1:D2}: {2:D2}. {3:D3}", timeCodeIn.nHours, timeCodeIn.nMinutes, timeCodeIn.nSeconds, timeCodeIn.nFrames);
        }

        private void ChangeTC_btn_Click(object sender, EventArgs e)
        {
            string TCvalue;
            m_objMFile.PropsGet("file::start_timecode", out TCvalue);
            m_objMFile.PropsSet("file::start_timecode", ParseAndChange(TCvalue));

            M_TIMECODE timeCodeIn;
            M_TIMECODE timeCodeOut;
            int outSpec;
            m_objMFile.FileInOutGetTC(out timeCodeIn, out timeCodeOut, out outSpec);
            newTC_lbl.Text = string.Format("{0:D2}: {1:D2}: {2:D2}. {3:D3}", timeCodeIn.nHours, timeCodeIn.nMinutes, timeCodeIn.nSeconds, timeCodeIn.nFrames);           

        }
       
        string ParseAndChange(string property)
        {
            char[] sep = { ':', ';' };
            string[] arr = property.Split(sep);
            string answer = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i < arr.Length - 1)
                    answer += arr[i] + ':';
                else if (i == arr.Length - 1)
                    answer += arr[i];
            }
            return answer;
        }
    }
}
