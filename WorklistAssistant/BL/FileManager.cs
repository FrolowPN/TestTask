using System;
using System.Collections.Generic;
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
            using (StreamReader file = new StreamReader(@"D:\VS\Тестовое задание\WorklistAssistant\BL\Resources\users.txt"))
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
            using (StreamWriter file = new StreamWriter(@"D:\VS\Тестовое задание\WorklistAssistant\BL\Resources\users.txt", true))
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
