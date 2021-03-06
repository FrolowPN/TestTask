﻿using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WABase;
using WABase.BaseHelpers;

namespace WAService
{
    public static class FileManager
    {

        private static string Path
        {
            //get { return new Uri(Directory.GetCurrentDirectory() + "/Resources/users.txt", UriKind.RelativeOrAbsolute).LocalPath; }
            get { return ConfigurationManager.AppSettings["UsersFile"]; }
        }
        private static string PathWorklists
        {
            //get { return new Uri(Directory.GetCurrentDirectory() + "/Resources/usersWorklists.txt", UriKind.RelativeOrAbsolute).LocalPath; }
            get { return ConfigurationManager.AppSettings["UsersWorklistsFile"]; }

        }
        private static string PathWorklistsBase
        {
            //get { return new Uri(Directory.GetCurrentDirectory() + "/Resources/usersWorklistsBase.txt", UriKind.RelativeOrAbsolute).LocalPath; }
            get { return ConfigurationManager.AppSettings["UsersWorklistsBase"]; }
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

                        //users.Add(new User(tempString.Split('/')[0], tempString.Split('/')[1]));
                        tempString = file.ReadLine();
                    }
                    return users;
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return new List<User>() { new User() };

            }
        }
        public static IList<Worklist> GetWorklistsFromFile()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                using (StreamReader file = new StreamReader(PathWorklists))
                {
                    string tempString = file.ReadLine();
                    List<Worklist> workls = new List<Worklist>();
                    while (tempString != null)
                    {

                        //workls.Add(new Worklist(tempString.Split('/')[0], tempString.Split('/')[1], tempString.Split('/')[2]));
                        tempString = file.ReadLine();
                    }
                    return workls;
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return new List<Worklist>() { new Worklist() };

            }
        }
        public static IList<Worklist> GetWorklistsForUser(string userLogin)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            #region
            //try
            //{
            //    using (StreamReader file = new StreamReader(PathWorklists))
            //    {
            //        string tempString = file.ReadLine();
            //        List<Worklist> workls = new List<Worklist>();
            //        while (tempString != null)
            //        {
            //            if (tempString.Split('/')[0] == user.Login)
            //            {
            //                workls.Add(new Worklist(tempString.Split('/')[0], tempString.Split('/')[1], tempString.Split('/')[2]));

            //            }

            //            tempString = file.ReadLine();
            //        }
            //        return workls;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.Trace(ex + "\r\n");
            //    return new List<Worklist>() { new Worklist() };
            //}
            #endregion
            try
            {
                ICollection<User> users = MUserHelper.GetAllUsersOnMUser(userLogin);
                    List<Worklist> workls = new List<Worklist>();
                    foreach (var user in users)
                    {
                        workls.Add(new Worklist(user));
                    }
                    return workls;                            
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
               return new List<Worklist>() { new Worklist() };
            }
        }
        public static void WriteUsersInFile(IList<User> users)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                using (StreamWriter file = new StreamWriter(Path, false))
                {
                    foreach (var item in users)
                    {
                        //file.WriteLine(item.Login + "/" + item.Password);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
            }
        }
        public static void WriteWorklistsInFile(IList<Worklist> workls)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                using (StreamWriter file = new StreamWriter(PathWorklists, false))
                {
                    foreach (var item in workls)
                    {
                        //if (VerificateWorklist(item.MasterUserLogin, item.LoginUser, item.PasswordUser))
                        {
                            //file.WriteLine(item.MasterUserLogin + "/" + item.LoginUser + "/" + item.PasswordUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
            }
        }
        public static bool AddUserInFile(string nameUser, string password)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            //try
            //{
            //    using (StreamWriter file = new StreamWriter(Path, true))
            //    {
            //        file.WriteLine(nameUser + "/" + password);
            //        return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    logger.Trace(ex + "\r\n");
            //    return false;

            //}
            try
            {
              return  MUserHelper.AddMUser(nameUser, password);
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }
        }
        public static bool AddWorklistInFile(string masterUserLogin, string loginUser, string passwordUser)
        {
            #region
            //Logger logger = LogManager.GetCurrentClassLogger();
            //try
            //{
            //    if (VerificateWorklist(masterUserLogin, loginUser, passwordUser))
            //    {
            //        using (StreamWriter file = new StreamWriter(PathWorklists, true))
            //        {
            //            file.WriteLine(masterUserLogin + "/" + loginUser + "/" + passwordUser);
            //            return true;
            //        }
            //    }
            //    else if (loginUser == "-" && passwordUser == "-")
            //    {
            //        using (StreamWriter file = new StreamWriter(PathWorklists, true))
            //        {
            //            file.WriteLine(masterUserLogin + "/-/-");
            //            return true;
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    logger.Trace(ex + "\r\n");
            //    return false;
            //}
            #endregion
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                return UserHelper.AddUser(masterUserLogin, loginUser, passwordUser);
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }

        }
        public static bool VerificateWorklist(string masterUserLogin, string loginUser, string passwordUser)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                using (StreamReader file = new StreamReader(PathWorklistsBase))
                {
                    string tempString = file.ReadLine();
                    List<Worklist> workls = new List<Worklist>();
                    while (tempString != null)
                    {
                        if (tempString.Split('/')[0] == masterUserLogin)
                        {
                            //workls.Add(new Worklist(tempString.Split('/')[0], tempString.Split('/')[1], tempString.Split('/')[2]));
                        }
                        tempString = file.ReadLine();
                    }
                    
                    if (workls.Where(x => x.LoginUser == loginUser && x.PasswordUser == passwordUser).ToList().Count()>0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }
        }
        public static bool DeleteUserFromFile(string nameUser)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            //try
            //{
            //    List<User> tempList = (List<User>)GetUsersFromFile();
            //    User tempUser = UserManager.GetUserOnLogin(nameUser);
            //    List<User> result = new List<User>();
            //    foreach (var item in tempList)
            //    {
            //        if (item.Login != tempUser.Login)
            //        {
            //            result.Add(item);
            //        }

            //    }
            //    WriteUsersInFile(result);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    logger.Trace(ex + "\r\n");
            //    return false;
            //}
            try
            {
              return MUserHelper.DeleteMUser(nameUser);
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }
        }
        public static bool DeleteWorklistFromFile(string masterUserLogin, string loginUser)
        {
            #region
            //Logger logger = LogManager.GetCurrentClassLogger();
            //try
            //{
            //    List<Worklist> tempList = (List<Worklist>)GetWorklistsFromFile();

            //    List<Worklist> result = new List<Worklist>();
            //    foreach (var item in tempList)
            //    {
            //        if (item.MasterUserLogin == masterUserLogin && item.LoginUser == loginUser)
            //        {

            //        }
            //        else
            //        {
            //            result.Add(item);
            //        }

            //    }
            //    WriteWorklistsInFile(result);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    logger.Trace(ex + "\r\n");
            //    return false;
            //}
            #endregion
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                return UserHelper.DeleteUser(masterUserLogin, loginUser);
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }
        }

        public static bool DeleteAllWorklistForUser(string masterUserLogin)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            try
            {
                List<Worklist> tempList = (List<Worklist>)GetWorklistsFromFile();

                List<Worklist> result = new List<Worklist>();
                foreach (var item in tempList)
                {
                    //if (item.MasterUserLogin != masterUserLogin)
                    {
                        result.Add(item);
                    }
                }
                WriteWorklistsInFile(result);
                return true;
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }
        }
    }

}
