using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsersListView
    {
        public List<string> UsersLogin { get; set; }
        public UsersListView()
        { 
            
UsersLogin = UserManager.GetListLogin();
            
            
        }
    }
}
