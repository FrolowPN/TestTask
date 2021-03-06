﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WABase;
using WABase.BaseHelpers;

namespace WAService
{
    public class Worklist
    {
        public string MasterUserLogin { get; set; }
        public string LoginUser { get; set; }
        public string PasswordUser { get; set; }
        public string CountS { get; set; }
        public string CountU { get; set; }
        public string CountR { get; set; }
        public string Status { get; set; }
        public string StatusImg { get; set; }
        //private static Random rnd = new Random();
        public Worklist()
        {

        }
        #region
        //public Worklist(string masterUserLogin, string userLogin, string userPassword)
        //{

        //    MasterUserLogin = masterUserLogin;
        //    LoginUser = userLogin;
        //    PasswordUser = userPassword;
        //    if (LoginUser == "-" && PasswordUser=="-")
        //    {
        //        CountS = "null";
        //        CountU = "null";
        //        CountR = "null";
        //        Status = "Error";
        //    }
        //    else
        //    {
        //        CountS = rnd.Next(100).ToString();
        //        CountU = rnd.Next(100).ToString();
        //        CountR = rnd.Next(100).ToString();
        //        Status = "Connected";
        //        rnd = new Random();
        //    }
        //}
        #endregion

        public Worklist(User user)
        {


            LoginUser = user.UserLogin;
            PasswordUser = user.UserPassword;
            //if ((LoginUser == "-" && PasswordUser == "-" )||user.ConnectStatus== "error")
            if (user.ConnectStatus == "error")
            {
                CountS = "null";
                CountU = "null";
                CountR = "null";
                Status = "Error";
            }
            else
            {
                var clinic = BUserHelper.GetClinicOnUserLogin(user.UserLogin);
                CountS = clinic.CountS.ToString();
                CountU = clinic.CountU.ToString();
                CountR = clinic.CountR.ToString();
                Status = "Connected";
            }
        }
    }

}
