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
            //WABaseContext ctx = new WABaseContext();
            //Clinic clinic = new Clinic();
            //clinic.CountR = 12;
            //clinic.CountS = 13;
            //clinic.CountU = 11;
            //clinic.BaseUsers = new List<BaseUser>() {
            //                                            new BaseUser() { BUserLogin = "login", BUserPassword = "pass" }
            //                                        };
            //ctx.Clinics.Add(clinic);
            //ctx.SaveChanges();
            //Console.WriteLine(ctx.BaseUsers.FirstOrDefault().BUserLogin);
            //Console.ReadKey();
        }
    }
}
