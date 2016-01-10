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
        private static RoutedUICommand add;
        private static RoutedUICommand edit;
        private static RoutedUICommand editRow;
        public static RoutedUICommand Add
        {
            get { return add;}
        }
        public static RoutedUICommand EditRow
        {
            get { return editRow;}
        }
        public static RoutedUICommand Edit
        {
            get { return edit;}
        }
        public static RoutedUICommand Refresh
        {
            get { return refresh;}
        }
        public static RoutedUICommand LogOut
        {
            get { return logOut;}
        }
        public static RoutedUICommand Setting
        {
            get { return setting;}
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
            add = new RoutedUICommand("Add", "Add", typeof(LocalCommands));
            edit = new RoutedUICommand("Edit", "Edit", typeof(LocalCommands));
            editRow = new RoutedUICommand("EditRow", "Edit Row", typeof(LocalCommands));
        }
    }
}
