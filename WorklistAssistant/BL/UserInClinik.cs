using System;
using System.Collections.Generic;
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
        public UserInClinik(string login, string pass, int s, int u, int r, int status)
        {
            Login = login;
            Password = pass;
            CountS = "S - " + s;
            CountU = "U - " + u;
            CountR = "R - " + u;
            if (status != 0)
            {
                Status = "Connected";
            }
            else
            {
                Status = "Error";
            }

        }
    }
}
