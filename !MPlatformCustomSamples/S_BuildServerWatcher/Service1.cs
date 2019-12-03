using Cassia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace S_BuildServerWatcher
{
    public partial class Service1 : ServiceBase
    {
        private CancellationTokenSource cancelSource;
        Thread m_threadWorker;
        private System.Timers.Timer aTimer;

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

        public Service1()
        {
            InitializeComponent();
            this.ServiceName = "BuildServerWatcher";
            this.CanStop = true; // службу можно остановить
            this.CanPauseAndContinue = true;
        }

        private void thread_DoWork(CancellationToken token)
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

        }

        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
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

            }
            catch
            {
                throw new Exception("Can't create a file");                
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
                throw new Exception("Can't delete the source:" + createdFile);                
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



        protected override void OnStart(string[] args)
        {
            cancelSource = new CancellationTokenSource();
            m_threadWorker = new Thread(() => thread_DoWork(cancelSource.Token));
            m_threadWorker.Name = "thread_DoWork";
            m_threadWorker.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
