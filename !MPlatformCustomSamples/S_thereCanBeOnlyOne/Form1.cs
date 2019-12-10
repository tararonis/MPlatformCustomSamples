using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S_thereCanBeOnlyOne
{
    public partial class Form1 : Form
    {
        StreamWriter sw;
        //string workingPath = @"\\MLDiskStation\MLFiles\Releases\Nightly\Not_tested\";
        //string moveFolder = @"\\MLDiskStation\MLFiles\Releases\Nightly\Archive\";
        string workingPath = @"\\MLDiskStation\MLFiles\Trash\Roman\!MyTemp\tcboo\";
        string moveFolder = @"\\MLDiskStation\MLFiles\Trash\Roman\!MyTemp\tcboo\MoveFolder\";

        string writePath = @"\\MLDiskStation\MLFiles\Trash\Roman\AppLogs\Script_MoveOlderVersionsToArchive\" + DateTime.Now.ToString("MM/dd/yyyy HH/mm/ss") + ".txt";
        public Form1()
        {
            InitializeComponent();          
            
        }

        
        List<string> MFormats = new List<string>();
        List<string> MPlatform = new List<string>();
        private void GetAllFiles()
        {
            foreach (var filePath in Directory.EnumerateFiles(workingPath))
            {
                if (filePath.Contains("MP"))
                    MPlatform.Add(filePath);
                else if (filePath.Contains("MF"))
                    MFormats.Add(filePath);
            }          
        }

        private void MoveFilesThatInclude(string SDK, List<string> list)
        {
            try
            {
                int curI = 0;
                DateTime dt0 = File.GetLastWriteTime(list[0]);
                for (int i = 1; i < list.Count; i++)
                {
                    DateTime dt = File.GetLastWriteTime(list[i]);

                    if (dt0 > dt)
                    {
                        File.Move(list[i], moveFolder + Path.GetFileName(list[i]));
                        sw.WriteLine(moveFolder + Path.GetFileName(list[i]));
                        Debug.WriteLine("dt0>dt");
                        Debug.WriteLine("WE moved " + moveFolder + Path.GetFileName(list[i]));
                        Debug.WriteLine(dt0);
                        Debug.WriteLine(dt);
                    }
                    else if (dt0 < dt)
                    {
                        File.Move(list[curI], moveFolder + Path.GetFileName(list[curI]));
                        sw.WriteLine(moveFolder + Path.GetFileName(list[curI]));
                        Debug.WriteLine("dt0<dt");
                        Debug.WriteLine("WE moved " + moveFolder + Path.GetFileName(list[curI]));

                        dt0 = dt;
                        curI = i;
                    }
                    else
                    {
                        File.Move(list[i], moveFolder + Path.GetFileName(list[i]));
                        sw.WriteLine(moveFolder + Path.GetFileName(list[i]));
                        Debug.WriteLine("WE moved " + moveFolder + Path.GetFileName(list[i]));
                        Debug.WriteLine(0 + " and " + i + " are equal");
                    }
                }
            }
            catch
            {
                sw.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                sw.WriteLine(moveFolder);
                sw.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sw = new StreamWriter(writePath, false, System.Text.Encoding.Default);
            GetAllFiles();
            MoveFilesThatInclude("MP", MPlatform);
            MoveFilesThatInclude("MF", MFormats);

            sw.Close();
        }
    }
}
