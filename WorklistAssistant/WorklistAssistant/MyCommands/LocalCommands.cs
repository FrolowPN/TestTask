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
        public static RoutedUICommand Login
        { 
            get {return login;}
        }
        static LocalCommands()
        {
            login = new RoutedUICommand("Login", "Login", typeof(LocalCommands));
        }
    }
}
