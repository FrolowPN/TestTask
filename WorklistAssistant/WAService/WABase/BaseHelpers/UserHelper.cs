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
                    resUser.MasterUser = MUserHelper.GetMUserOnLogin(mUserlogin);
                    ctx.Users.Add(resUser);
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

    }
}
