using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WABase.BaseHelpers
{
    public static class BUserHelper
    {
        private static Logger logger
        {

            get { return LogManager.GetCurrentClassLogger(); }
        }
        public static BaseUser GetBUserOnLogin(string login)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    BaseUser resUser = ctx.BaseUsers.Where(x => x.BUserLogin == login).FirstOrDefault();
                    if (resUser != null)
                    {
                        return resUser;
                    }
                    else
                    {
                        return new BaseUser();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return new BaseUser();
            }
        }
        public static Clinic GetClinicOnUserLogin(string login)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    BaseUser resUser = ctx.BaseUsers.Where(x => x.BUserLogin == login).FirstOrDefault();
                    if (resUser != null)
                    {
                        return resUser.Clinic;
                    }
                    else
                    {
                        return new Clinic();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return new Clinic();
            }
        }
        public static bool UserVerificate(string login, string password)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    BaseUser resUser = ctx.BaseUsers.Where(x => x.BUserLogin == login).FirstOrDefault();
                    if (resUser != null && resUser.BUserPassword == password)
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
    }
}
