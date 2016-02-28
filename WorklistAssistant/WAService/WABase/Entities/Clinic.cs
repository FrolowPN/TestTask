using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WABase
{
    public class Clinic
    {
        public int Id { get; set; }
        public int CountS { get; set; }
        public int CountU { get; set; }
        public int CountR { get; set; }

        public virtual ICollection<BaseUser> BaseUsers { get; set; }
    }
}
