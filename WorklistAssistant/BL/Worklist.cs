using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
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
        public Worklist()
        {

        }

        public Worklist(string masterUserLogin, string userLogin, string userPassword)
        {
            Random rnd = new Random();
            MasterUserLogin = masterUserLogin;
            LoginUser = userLogin;
            PasswordUser = userPassword;
            CountS = rnd.Next(1, 100).ToString();
            CountU = rnd.Next(1, 100).ToString();
            CountR = rnd.Next(1, 100).ToString();
            if (rnd.Next(0, 2) != 0)
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
