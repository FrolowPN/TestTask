using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.IdentityModel.Selectors;
using NLog;

namespace WAService
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName != "1" || password != "1")
            {
                throw new SecurityException("Wrong login or password!");
            }

        }
    }
}
