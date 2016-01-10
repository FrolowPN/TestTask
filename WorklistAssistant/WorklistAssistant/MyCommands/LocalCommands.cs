using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WorklistAssistant.MyCommands
{
    public class LocalCommands
    {
        private static RoutedUICommand login;
        private static RoutedUICommand setting;
        private static RoutedUICommand logOut;
        private static RoutedUICommand refresh;
        public static RoutedUICommand Refresh
        {
            get { return refresh; }
        }
        public static RoutedUICommand LogOut
        {
            get { return logOut; }
        }
        public static RoutedUICommand Setting
        {
            get { return setting; }
        }
        public static RoutedUICommand Login
        { 
            get {return login;}
        }
        static LocalCommands()
        {
            login = new RoutedUICommand("Login", "Login", typeof(LocalCommands));
            setting = new RoutedUICommand("Setting", "Setting", typeof(LocalCommands));
            logOut = new RoutedUICommand("LogOut", "Log Out", typeof(LocalCommands));
            refresh = new RoutedUICommand("Refresh", "Refresh", typeof(LocalCommands));
        }
    }
}
