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
        public static Mutex singleMutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {

            bool aIsNewInstance = false;
            singleMutex = new Mutex(true, @"WLAssistant", out aIsNewInstance);
            if (!aIsNewInstance)
            {
                MessageBox.Show("Assistant already running!", "Worklist Assistant", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Current.Shutdown(0);
                return;
            }
            base.OnStartup(e);
            MainWindow mw = new MainWindow();
            mw.Show();
            
        }
    }
}
