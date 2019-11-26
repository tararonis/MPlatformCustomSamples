using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Reflection;
using System.Windows.Threading;

namespace MFormatsOnboarding
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
            : base()
        {
            DispatcherUnhandledException += Application_OnDispatcherUnhandledException;
        }
        


        private void Application_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            StringBuilder exceptionTrace = new StringBuilder();
            Exception ex = e.Exception;
            while (ex != null)
            {
                exceptionTrace.Append(ex.Message + "\n");
                ex = ex.InnerException;
            }
            MessageBox.Show("An unhandled exception just occured in Redistribution Maker app: " + exceptionTrace, "App Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            Shutdown();
        }
    }
}