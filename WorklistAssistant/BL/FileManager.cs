using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class FileManager
    { 
        
        private static string Path 
        { 
            get {return new Uri(Directory.GetCurrentDirectory() + "/users.txt", UriKind.RelativeOrAbsolute).LocalPath;} 
        }
      
        
        public static IList<User> GetUsersFromFile()
         {
             Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                using (StreamReader file = new StreamReader(Path))
                {
                    string tempString = file.ReadLine();
                    List<User> users = new List<User>();
                    while (tempString != null)
                    {

                        users.Add(new User(tempString.Split('/')[0], tempString.Split('/')[1]));
                        tempString = file.ReadLine();
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex+"\r\n");
                return new List<User>() { new User() };

            }


        }
        public static bool AddUserInFile(string nameUser, string password)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                using (StreamWriter file = new StreamWriter(Path, true))
                {
                    file.WriteLine(nameUser + "/" + password);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                logger.Trace(ex + "\r\n");
            }


        }
    }
}
