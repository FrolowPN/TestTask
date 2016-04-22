using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Reflection;
using NLog;
using ConfigUtility.PatchConfigUtility;
using ConfigUtility.CustomConfigUtility;
using ConfigUtility.ConfigurationHelper;


namespace WorklistAssistant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        const string name = "WAAssistant";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static bool SetAutorunValue(bool autorun)
        {

            //string ExePath = new Uri(Assembly.GetExecutingAssembly().Location.Replace("WorklistAssistant.exe", "test.bat"), UriKind.RelativeOrAbsolute).LocalPath;
            string ExePath = Assembly.GetExecutingAssembly().Location.ToString();
            try
                {
                        RegistryKey reg;
                        reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
                    if (autorun)
                    {
                        reg.SetValue(name, ExePath); 
                    }
                    else
                    {
                        reg.DeleteValue(name);
                    }

                    reg.Close();
                }
                catch (Exception ex)
                {
                    logger.Trace(ex + "\r\n");
                    return false;
                }
            return true;
        }

        [STAThread]
        public static void Main(string[] args)
        {
            new PatchHelper().PatchConfigs();
           SetAutorunValue(true);
            

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
        private static Logger logger = LogManager.GetCurrentClassLogger();
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);
            IConfigHelper configHelper = new ConfigManagerHelper();
            string path = Common.PathExpand(configHelper.GetConfigurationSections()["WLAssistant"]["UserCfgPath"]);
            // Create and show the application's main window
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader file = new StreamReader(path))
                    {
                        MainWindow window = new MainWindow(file.ReadLine());
                    }
                }
                catch (Exception ex)
                {
                    logger.Trace(ex + "\r\n");
                }
            }
            else
            {
                MainWindow window = new MainWindow();
                window.Show();
            }

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
