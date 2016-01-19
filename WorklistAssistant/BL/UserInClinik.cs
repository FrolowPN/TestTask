using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class UserInClinik
    {
       
        public string Login { get; set; }
        public string Password { get; set; }
        public string CountS { get; set; }
        public string CountU { get; set; }
        public string CountR { get; set; }
        public string Status { get; set; }
        public string StatusImg { get; set; }

        public UserInClinik(string login, string pass, int s, int u, int r, int status)
        {
            Login = login;
            Password = pass;
            CountS =  s.ToString();
            CountU = u.ToString();
            CountR = r.ToString();
            if (status != 0)
            {
                Status = "Connected";
                StatusImg = new Uri(Directory.GetCurrentDirectory() + "/Resources/greenOk.png", UriKind.RelativeOrAbsolute).LocalPath;
            }
            else
            {
                Status = "Error";
                StatusImg = new Uri(Directory.GetCurrentDirectory() + "/Resources/redCancel.png", UriKind.RelativeOrAbsolute).LocalPath;
            }

        }
    }
}
