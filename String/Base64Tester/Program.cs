using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base64Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            string korean = "Smartcareworks";

            Console.WriteLine(Convert.ToBase64String(Encoding.UTF8.GetBytes(korean)));

            Console.ReadLine();
        }
    }
}
