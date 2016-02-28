using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WABase.BaseHelpers
{
    public static class MUserHelper
    {
        private static Logger logger
        {
     
            get { return LogManager.GetCurrentClassLogger(); }
        }

        public static MasterUser GetMUserOnLogin(string login)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    MasterUser resUser = ctx.MasterUsers.Where(x => x.MUserLogin == login).FirstOrDefault();
                    if (resUser!=null)
                    {
                        return resUser;
                    }
                    else
                    {
                        return new MasterUser();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return new MasterUser();
            }
        }
        public static bool AddMUser(string login, string password)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    MasterUser mUser = new MasterUser() { MUserLogin = login, MUserPassword = password };
                    ctx.MasterUsers.Add(mUser);
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
        public static bool DeleteMUser(string login)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    MasterUser mUser = ctx.MasterUsers.Where(x => x.MUserLogin == login).FirstOrDefault();
                    if (mUser==null)
                    {
                        return true;
                    }
                    else
                    {
                        ctx.MasterUsers.Remove(mUser);
                        ctx.SaveChanges();
                        return true;
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
