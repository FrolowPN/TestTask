using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WABase
{
    public class BaseUser
    {
        public int Id { get; set; }
        public string BUserLogin { get; set; }
        public string BUserPassword { get; set; }

        public virtual Clinic Clinic { get; set; }
    }
}
