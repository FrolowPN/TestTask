using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL
{
    public static class UserManager
    {
        public static List<string> GetListLogin()
        {
            List<string> result = new List<string>();
            foreach (var item in FileManager.GetUsersFromFile())
            {
                result.Add(item.Login.ToString());
            }
            result.Add("Add new User");
            return result;
        }
        public static void EditUser(string userLogin, string newUserLogin, string newUserPassword)
        {
            IList<User> users = FileManager.GetUsersFromFile();
            IList<User> usersResult = new List<User>();
            foreach (var item in users)
            {
                if (item.Login == userLogin)
                {
                    User tempUser = new User(newUserLogin, newUserPassword);
                    usersResult.Add(tempUser); 
                }
                else
                {
                    usersResult.Add(item); 
                }
            }

            FileManager.WriteUsersInFile(usersResult);
        }

        
        public static User GetUserOnLogin(string userName)
        {
            User result = new User();
            foreach (var item in FileManager.GetUsersFromFile())
            {
                if (item.Login == userName)
                {
                    result = item;
                }
            }
            return result;
        }
        public static bool VerifyingPassword(string userName, string password)
        {
            User tempUser = GetUserOnLogin(userName);
            if (tempUser.Password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
      
        public static ObservableCollection<UsersListView> ConvertToBind(IList<string> users)
        {
            ObservableCollection<UsersListView> result = new ObservableCollection<UsersListView>();
            foreach (var item in users)
            {
                if (item == users[users.Count()-1])
                {
                   string imageLogo = new Uri(Directory.GetCurrentDirectory() + "/Resources/add.png", UriKind.RelativeOrAbsolute).LocalPath;
                   string imageDel = new Uri(Directory.GetCurrentDirectory() + "/Resources/adds.png", UriKind.RelativeOrAbsolute).LocalPath;
                    result.Add(new UsersListView(imageLogo,item, imageDel));
                }
                else
                {
                    result.Add(new UsersListView(item));
                }

            }


            return result;
        }
        public static void EditWorklist(string masterUserLogin, string oldUserLogin,  string newUserLogin, string newUserPassword)
        {
           
                List<Worklist> tempList = (List<Worklist>)FileManager.GetWorklistsFromFile();

                List<Worklist> result = new List<Worklist>();
                foreach (var item in tempList)
                {
                    if (item.MasterUserLogin == masterUserLogin && item.LoginUser == oldUserLogin)
                    {
                        Worklist tempWorklist = new Worklist(masterUserLogin, newUserLogin, newUserPassword);
                        result.Add(tempWorklist);
                    }
                    else
                    {
                        result.Add(item);
                    }

                }
                FileManager.WriteWorklistsInFile(result);
           
        }
    }
}
