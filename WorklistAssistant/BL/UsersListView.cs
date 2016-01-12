using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BL
{
    public class UsersListView
    {
       
            public string ImageLogo { get; set; }
            public string Text { get; set; }
            public string ImageDel { get; set; }
            public UsersListView(string login)
            {
                Text = login;
                ImageLogo = new Uri(Directory.GetCurrentDirectory() + "/Resources/userface.png", UriKind.RelativeOrAbsolute).LocalPath;
                ImageDel = new Uri(Directory.GetCurrentDirectory() + "/Resources/busket.png", UriKind.RelativeOrAbsolute).LocalPath;
            }
            public UsersListView(string imageLogo, string login, string imageDel)
            {
                Text = login;
                ImageLogo = imageLogo;
                ImageDel = imageDel;
            }
    }
}
