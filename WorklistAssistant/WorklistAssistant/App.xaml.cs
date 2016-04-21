using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace WorklistAssistant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static Mutex singleMutex = null;

        //protected override void OnStartup(StartupEventArgs e)
        //{

        //    bool aIsNewInstance = false;
        //    singleMutex = new Mutex(true, @"WLAssistant", out aIsNewInstance);
        //    if (!aIsNewInstance)
        //    {
        //        MessageBox.Show("Assistant already running!", "Worklist Assistant", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //        Current.Shutdown(0);
        //        return;
        //    }
        //    base.OnStartup(e);
        //    MainWindow mw = new MainWindow();
        //    mw.Show();

        //}
        [STAThread]
        public static void Main(string[] args)
        {
            SingleInstanceManager manager = new SingleInstanceManager();
            manager.Run(args);
        }
    }

    public class SingleInstanceManager : WindowsFormsApplicationBase
        {
            SingleInstanceApplication app;

            public SingleInstanceManager()
            {
                this.IsSingleInstance = true;
            }

            protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
            {
                // First time app is launched
                app = new SingleInstanceApplication();
                app.Run();
                return false;
            }

            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
            {
                // Subsequent launches
                base.OnStartupNextInstance(eventArgs);
                app.Activate();
            }
        }

        public class SingleInstanceApplication : Application
        {
            protected override void OnStartup(System.Windows.StartupEventArgs e)
            {
                base.OnStartup(e);

                // Create and show the application's main window
                MainWindow window = new MainWindow();
                window.Show();
            }

            public void Activate()
            {
                if (App.Current.Windows.OfType<WorklistAssistantWindow>().SingleOrDefault() != null)
                {
                  App.Current.Windows.OfType<WorklistAssistantWindow>().SingleOrDefault().Show();  
                }           
            }     
        }  
}
