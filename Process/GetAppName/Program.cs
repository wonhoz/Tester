using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetAppName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            Console.ReadLine();
        }
    }
}
