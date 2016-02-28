using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WABase
{
    public class WABaseContext:DbContext
    {
        public WABaseContext():base("WABaseContext")
        {
        }

        public DbSet<MasterUser> MasterUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<BaseUser> BaseUsers { get; set; }

    }
}
