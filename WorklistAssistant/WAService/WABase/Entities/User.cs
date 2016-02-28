using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WABase
{
   public class User
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string ConnectStatus { get; set; }

        public virtual MasterUser MasterUser { get; set; }
    }
}
