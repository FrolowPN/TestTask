using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorklistAssistant
{
    public static class ClientFileHelper
    {
       static Logger logger = LogManager.GetCurrentClassLogger();
        private static string Path
        {
            get { return new Uri(Directory.GetCurrentDirectory() + "/Resources/MasterUserLogins.txt", UriKind.RelativeOrAbsolute).LocalPath; }
        }

        public static IList<Login> GetAllLogins()
        {
            try
            {
                using (StreamReader file = new StreamReader(Path))
                {
                    string tempString = file.ReadLine();
                    List<Login> logins = new List<Login>();
                    while (tempString != null)
                    {

                        logins.Add(new Login(tempString));
                        tempString = file.ReadLine();
                    }
                    string imageLogo = new Uri(Directory.GetCurrentDirectory() + "/Resources/add.png", UriKind.RelativeOrAbsolute).LocalPath;
                    string imageDel = new Uri(Directory.GetCurrentDirectory() + "/Resources/adds.png", UriKind.RelativeOrAbsolute).LocalPath;
                    logins.Add(new Login(imageLogo, "Add new user"));
                    return logins;
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return new List<Login>() { new Login() };
            }
        }

        public static bool AddUser(string masterUserLogin)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(Path, true))
                {
                    file.WriteLine(masterUserLogin);
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }
        }

        public static void RemoveUser(string masterUserLogin)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                IList<Login> logins = GetAllLogins();
                using (StreamWriter file = new StreamWriter(Path, false))
                {
                    foreach (var item in logins)
                    {
                        if (item.MasterUserLogin != masterUserLogin)
                        {
                            if (item.MasterUserLogin!= "Add new user")
                            {
                                file.WriteLine(item.MasterUserLogin);
                            }
                            
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
            }
        }
        public static void UpdateUser(string oldMasterUserLogin, string newMasterUserLogin)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                IList<Login> logins = GetAllLogins();
                using (StreamWriter file = new StreamWriter(Path, false))
                {
                    foreach (var item in logins)
                    {
                        if (item.MasterUserLogin != oldMasterUserLogin)
                        {
                            if (item.MasterUserLogin != "Add new user")
                            {
                                file.WriteLine(item.MasterUserLogin);
                            }
                        }
                        else
                        {
                            file.WriteLine(newMasterUserLogin);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
            }
        }
    }

   public class Login
    {
        public string MasterUserLogin { get; set; }
        public string ImageLogo { get; set; }
        public string ImageDel { get; set; }
        public Login(string login)
        {
            MasterUserLogin = login;
            ImageLogo = new Uri(Directory.GetCurrentDirectory() + "/Resources/userface.png", UriKind.RelativeOrAbsolute).LocalPath;
            ImageDel = new Uri(Directory.GetCurrentDirectory() + "/Resources/busket.png", UriKind.RelativeOrAbsolute).LocalPath;
        }
        
        public Login()
        {
            ImageLogo = new Uri(Directory.GetCurrentDirectory() + "/Resources/userface.png", UriKind.RelativeOrAbsolute).LocalPath;
            ImageDel = new Uri(Directory.GetCurrentDirectory() + "/Resources/busket.png", UriKind.RelativeOrAbsolute).LocalPath;
        }
        public Login(string pathImageAdd, string login)
        {
            MasterUserLogin = login;
            ImageLogo = pathImageAdd;
        }

    }
}
