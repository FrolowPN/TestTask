using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAService;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = FileManager.GetWorklistsForUser("Mr. Frolow");
            Console.ReadKey();
        }
    }
}
