using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WABase;
using WABase.BaseHelpers;

namespace WAService
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
        public static bool EditUser(string userLogin, string newUserLogin, string newUserPassword)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
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
                return true;
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }
            
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
            //User tempUser = GetUserOnLogin(userName);
            //if (tempUser.Password == password)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            MasterUser tempUser = MUserHelper.GetMUserOnLogin(userName);
            if (tempUser.MUserPassword == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void EditWorklist(string masterUserLogin, string oldUserLogin, string newUserLogin, string newUserPassword)
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
        public static void ChangeMasterUserForWorklists(string oldMasterUser, string newMasterUser)
        {

            List<Worklist> tempList = (List<Worklist>)FileManager.GetWorklistsFromFile();
            List<Worklist> result = new List<Worklist>();
            foreach (var item in tempList)
            {
                if (item.MasterUserLogin == oldMasterUser)
                {
                    Worklist tempWorklist = new Worklist(newMasterUser, item.LoginUser, item.PasswordUser);
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
