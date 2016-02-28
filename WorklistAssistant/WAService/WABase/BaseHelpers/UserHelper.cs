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
        //public static MasterUser GetUsersForMUser(string login)
        //{
        //    try
        //    {
        //        using (WABaseContext ctx = new WABaseContext())
        //        {
        //            MasterUser resUser = ctx.MasterUsers.Where(x => x.MUserLogin == login).FirstOrDefault();
        //            if (resUser != null)
        //            {
        //                return resUser;
        //            }
        //            else
        //            {
        //                return new MasterUser();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Trace(ex + "\r\n");
        //        return new MasterUser();
        //    }
        //}

    }
}
