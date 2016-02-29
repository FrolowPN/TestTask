using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WABase.BaseHelpers
{
    public static class UserHelper
    {
        private static Logger logger
        {

            get { return LogManager.GetCurrentClassLogger(); }
        }
        public static bool AddUser(string mUserlogin, string userLogin, string userPassword)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    User resUser = new User();
                    resUser.UserLogin = userLogin;
                    resUser.UserPassword = userPassword;
                    if (BUserHelper.UserVerificate(userLogin, userPassword))
                    {
                        resUser.ConnectStatus = "connect";
                    }
                    else
                    {
                        resUser.ConnectStatus = "error";
                    }
                    ctx.MasterUsers.Where(x => x.MUserLogin == mUserlogin).FirstOrDefault().Users.Add(resUser);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return false;
            }
        }
        public static bool DeleteUser(string mUserlogin, string userLogin)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    var targetUser = MUserHelper.GetMUserOnLogin(mUserlogin).Users.Where(x => x.UserLogin == userLogin).FirstOrDefault();
                    if (targetUser!=null)
                    {
                        ctx.Users.Remove(targetUser);
                        ctx.SaveChanges();
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
        public static void EditUser(string masterUserLogin, string oldUserLogin, string newUserLogin, string newUserPassword)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    var targetUser = MUserHelper.GetMUserOnLogin(masterUserLogin).Users.Where(x => x.UserLogin == oldUserLogin).FirstOrDefault();
                    if (targetUser != null)
                    {
                        targetUser.UserLogin = newUserLogin;
                        targetUser.UserPassword = newUserPassword;
                        if (BUserHelper.UserVerificate(targetUser.UserLogin, targetUser.UserPassword))
                        {
                            targetUser.ConnectStatus = "connect";
                        }
                        else
                        {
                            targetUser.ConnectStatus = "error";
                        }
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");  
            }
        }
    }
}
