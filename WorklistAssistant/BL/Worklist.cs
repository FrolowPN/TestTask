using System;
using System.Collections.Generic;
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
        public Worklist()
        {

        }

        public Worklist(string masterUserLogin, string userLogin, string userPassword)
        {
            MasterUserLogin = masterUserLogin;
            LoginUser = userLogin;
            PasswordUser = userPassword;
        }
    }
}
