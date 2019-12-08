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

        string username = "BuildServer3";
        string password = "medialooks";

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
        const string workingPath = @"\\192.168.0.100\MLFiles\!EmptyEveryNight\";
        string createdFile = "null";
        bool BuildServerIsFree = true;
        string currentLord = "start";

        public Service1()
        {
            InitializeComponent();
            
            this.CanStop = true; // службу можно остановить
            this.CanPauseAndContinue = true;
        }
        
        //private void thread_DoWork(CancellationToken token)
        //{
        //    if (start)
        //    {
        //        manager = new TerminalServicesManager();
        //        aTimer = new System.Timers.Timer(1000);
        //        aTimer.Elapsed += ATimer_Elapsed;
        //        aTimer.AutoReset = true;
        //        aTimer.Enabled = true;
        //        start = !start;
        //    }
        //}

        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Debug("!EnterTheThread");
            try
            {
                File.Create(workingPath + "iTsAlive");
            }
            catch
            {
                Debug("!Can't create in Empty");
            }
            manager = new TerminalServicesManager();
            
            if (manager.CurrentSession.ClientIPAddress != null)
            {
                BuildServerIsFree = false;
                Debug("!EnterThefalse");
            }
            else
            {
                BuildServerIsFree = true;
                Debug("!EnterThetrue");
            }


            if (!BuildServerIsFree)
            {
                Debug("!EnterThefalse1");
                if (!IsTheSameLord())
                {
                    DeleteFreeFlag();
                    File.Delete(createdFile);
                    CreateFile(manager.CurrentSession.ClientIPAddress.ToString());
                }
            }
            else if (BuildServerIsFree)
            {
                Debug("!EnterThetrue1");
                if (!String.IsNullOrEmpty(createdFile) && currentLord != "free")
                {
                    File.Delete(createdFile);
                    ShowThatServerIsFree();
                }
                Debug("!1" + createdFile);
                Debug("!2" + currentLord);
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
            Debug("!EnterTheCreateFile");
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
            Debug("!EnterTheShowThatServerIsFree");
            try
            {
                CreateFile("");
                currentLord = "free";
            }
            catch
            {
                Debug("!EnterTheShowThatServerIsFree_catch");
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
            //cancelSource = new CancellationTokenSource();
            //m_threadWorker = new Thread(() => thread_DoWork(cancelSource.Token));
            //m_threadWorker.Name = "thread_DoWork";
            //m_threadWorker.Start();
                aTimer = new System.Timers.Timer(1000);
                aTimer.Elapsed += ATimer_Elapsed;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
              
        }

        protected override void OnStop()
        {
        }

        string pathD= @"C:\Users\BuildServer3\Desktop\!temp\service\";
        void Debug(string mes)
        {
            File.Create(pathD+mes);
        }
    }
}
