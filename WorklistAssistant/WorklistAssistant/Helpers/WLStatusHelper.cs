using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorklistAssistant.WAService;

namespace WorklistAssistant.Helpers
{
    public static class WLStatusHelper
    {
        public static IList<Worklist>  UpdateStatusImg(IList<Worklist> listWL)
        {
            foreach (var wl in listWL)
            {
                if ( wl.Status== "Connected")
                {
                    //wl.StatusImg = new Uri(Directory.GetCurrentDirectory() + "/Resources/greenOk.png", UriKind.RelativeOrAbsolute).LocalPath;
                    wl.StatusImg = new Uri(Assembly.GetExecutingAssembly().Location.Replace("WorklistAssistant.exe", "Resources/greenOk.png"), UriKind.RelativeOrAbsolute).LocalPath;
                }
                else
                {
                    wl.StatusImg = new Uri(Assembly.GetExecutingAssembly().Location.Replace("WorklistAssistant.exe", "Resources/redCancel.png"), UriKind.RelativeOrAbsolute).LocalPath;
                    wl.Status = "Error";
                    wl.CountR = "?";
                    wl.CountS = "?";
                    wl.CountU = "?";
                }
            }
            return listWL;
        }
    }
}
