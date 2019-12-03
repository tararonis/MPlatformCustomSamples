using Cassia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S_DetectTheRDC
{
    public partial class Form1 : Form
    {
        ITerminalServicesManager manager;
        Dictionary<string, string> nerds = new Dictionary<string, string>
        {
            {"192.168.0.121", "Roman" },
            {"1", "Pavel" },
            {"2", "Anton" },
            {"3", "Victor" },
            {"4", "Olga" },
            {"Censored", "Unknown" }
        };
        const string workingPath = @"\\MLDiskStation\MLFiles\!EmptyEveryNight\";
        string createdFile = "null";
        bool BuildServerIsFree = true;
        string currentLord = "free";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            manager = new TerminalServicesManager();
        }

        private void Timer_btn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;

            if (timer1.Enabled)
            {
                Timer_btn.BackColor = Color.Green;
                Timer_btn.Text = "Timer ON";
            }
            else
            {
                Timer_btn.BackColor = Color.Red;
                Timer_btn.Text = "Timer OFF";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (manager.CurrentSession.ClientIPAddress != null)
                BuildServerIsFree = false;
            else
                BuildServerIsFree = true;


            if (!BuildServerIsFree)
            {
                if (!IsTheSameLord())
                {
                    DeleteFreeFlag();
                    File.Delete(createdFile);
                    CreateFile(manager.CurrentSession.ClientIPAddress.ToString());
                }
            }
            else if (BuildServerIsFree)
            {
                if (!String.IsNullOrEmpty(createdFile) && createdFile != String.Empty && currentLord != "free")
                {
                    File.Delete(createdFile);
                    ShowThatServerIsFree();
                }
            }

            GC.Collect();
        }

        bool IsTheSameLord()
        {
            foreach (var n in nerds)
            {
                if (n.Value == currentLord)
                {
                    return true;
                }
            }
            return false;
        }

        void CreateFile(string ip)
        {
            try
            {
                if (!BuildServerIsFree)
                {
                    foreach (var n in nerds)
                    {
                        if (n.Key == ip)
                        {
                            createdFile = workingPath + "!" + n.Value + " took the build server";
                            currentLord = n.Value;
                            break;
                        }
                        else
                        {
                            createdFile = workingPath + "!Unknown hacker(" + ip + ") took the build server";
                            currentLord = "Unknown";
                        }
                    }
                }
                else if (BuildServerIsFree)
                {
                    createdFile = workingPath + "!BuidServerIsFree";

                }
                File.Create(createdFile);
                log_lsb.Items.Add(createdFile);

            }
            catch
            {
                MessageBox.Show("Can't create a file");
            }
        }

        private void ShowThatServerIsFree()
        {
            try
            {
                CreateFile("");
                currentLord = "free";
            }
            catch
            {
                MessageBox.Show(("Can't delete the source:{0}"), createdFile);
            }
        }

        private void DeleteFreeFlag()
        {
            try
            {
                File.Delete(workingPath + "!BuildServerIsFree");
            }

            catch { }
        }
    }
}
