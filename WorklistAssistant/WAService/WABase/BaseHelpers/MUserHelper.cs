﻿using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public static ICollection<User> GetAllUsersOnMUser(string login)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    MasterUser resUser = ctx.MasterUsers.Where(x => x.MUserLogin == login).FirstOrDefault();
                    if (resUser != null)
                    {
                        return resUser.Users;
                    }
                    else
                    {
                        return new List<User>();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Trace(ex + "\r\n");
                return new List<User>();
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
                        ctx.Users.RemoveRange(mUser.Users);
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
        public static bool EditMUser(string userLogin, string newUserLogin, string newUserPassword)
        {
            try
            {
                using (WABaseContext ctx = new WABaseContext())
                {
                    MasterUser mUser = ctx.MasterUsers.Where(x => x.MUserLogin == userLogin).FirstOrDefault();
                    if (mUser == null)
                    {
                        return false;
                    }
                    else
                    {
                        mUser.MUserLogin = newUserLogin;
                        mUser.MUserPassword = newUserPassword;
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
