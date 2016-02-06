using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WAServiceHost
{
    class Program
    {
        static void Main()
        {
            using (var host = new ServiceHost(typeof(WAService.WAService)))
            {
                host.Open();
                Console.WriteLine("Host open...");
                Console.ReadKey();
            }
        }
    }
}
