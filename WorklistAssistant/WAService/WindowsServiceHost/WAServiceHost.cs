using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceHost
{
    public partial class WAServiceHost : ServiceBase
    {
        private ServiceHost host;
        public WAServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(WAService.WAService));
            host.Open();
        }

        protected override void OnStop()
        {
            if (host!= null)
            {
                host.Close();
            }
        }
    }
}
