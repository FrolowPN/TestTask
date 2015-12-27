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
        public static IList<User> GetUsersFromFile()
        {
            var path = ConfigurationManager.AppSettings["UsersFile"];
            using (StreamReader file = new StreamReader(path))
            {
                string tempString = file.ReadLine();
                List<User> users = new List<User>();
                while (tempString != null)
                {

                    users.Add(new User(tempString.Split(' ')[0], tempString.Split(' ')[1]));
                    tempString = file.ReadLine();
                }
                return users;
            }

        }
        public static bool AddUserInFile(string nameUser, string password)
        {
            var path = ConfigurationManager.AppSettings["UsersFile"];
            using (StreamWriter file = new StreamWriter(path, true))
            {
                try
                {
                    file.WriteLine(nameUser + " " + password);
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }

            }

        }
    }
}
