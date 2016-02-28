using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WABase
{
    public class MasterUser
    {
        public int Id { get; set; }
        public string MUserLogin{ get; set; }
        public string MUserPassword{ get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
