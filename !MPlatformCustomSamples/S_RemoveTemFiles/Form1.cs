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

namespace S_RemoveTemFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       
        SortedSet<string> keyWords = new SortedSet<string>(StringComparer.OrdinalIgnoreCase) {
                 ".vs", "_UpgradeReport_Files", "Backup", "UpgradeLog.XML"
            };

        List<string> allDir = new List<string>();

        string rootFolder;
        StreamWriter sw;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var k in keyWords)
            {
                listOfKeyWords.Items.Add(k);
            }

            string writePath = @"\\MLDiskStation\MLFiles\Trash\Roman\AppLogs\" + DateTime.Now.ToString("MM/dd/yyyy HH/mm/ss") + ".txt";

            sw = new StreamWriter(writePath, false, System.Text.Encoding.Default);


        }

        private void RemoveFiles_btn_Click(object sender, EventArgs e)
        {
            allDir.Clear();
            if (path_txb.Text == String.Empty)
            {              
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && openFileDialog1.FileNames.Length != 0)
                {
                    rootFolder = folderBrowserDialog1.SelectedPath.ToString();
                    path_txb.Text = rootFolder;
                }
            }          

            foreach (var file in Directory.EnumerateDirectories(rootFolder, "*", SearchOption.AllDirectories))
            {
                RemoveFilesAndFolders(file);
            }

           
        }

        void RemoveFilesAndFolders(string path)
        {

            foreach (var filePath in Directory.EnumerateFiles(path))
            {
                string fileName = Path.GetFileName(filePath);
                if (keyWords.Contains(fileName))
                {
                    File.Delete(filePath);
                    Log_lsb.Items.Add(filePath);
                    sw.WriteLine(filePath);
                }
            }

            foreach (var dirPath in Directory.EnumerateDirectories(path))
            {
                string DirName = Path.GetFileName(dirPath);
                if (keyWords.Contains(DirName))
                {
                    Directory.Delete(@dirPath, true);
                    Log_lsb.Items.Add(@dirPath);
                    sw.WriteLine(@dirPath);
                }
            }

        }

        private void AddKey_btn_Click(object sender, EventArgs e)
        {
            if (AddKey_txb.Text != String.Empty)
            { 
                
            }
        }
    }
}
