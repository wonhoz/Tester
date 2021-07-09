using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = "1984-09-09 11:15";

            Console.WriteLine(Convert.ToDateTime(date));
            Console.ReadLine();
        }
    }
}
