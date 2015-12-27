using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static  User GetUserOnLogin(string userName)
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
        public static IList<WorklistViewModel> ConvertToView(List<UserInClinik> users)
        {
           List<WorklistViewModel> result = new List<WorklistViewModel>();
           foreach (var item in users)
           {
               result.Add( new WorklistViewModel() 
                                               {
                                                   Login =  item.Login,
                                                   CountS = item.CountS,
                                                   CountU = item.CountU,
                                                   CountR = item.CountR,
                                                   Status = item.Status
                                               });
           }
            
           
            return result;
        }

        public static IList<SettingView> ConvertToSettingView(List<UserInClinik> users)
        {
            List<SettingView> result = new List<SettingView>();
            foreach (var item in users)
            {
                result.Add(new SettingView()
                                            {
                                                Login = item.Login,
                                                Password = item.Password,
                                                Status = item.Status
                                            });
            }
            return result;
        }
    }
}
