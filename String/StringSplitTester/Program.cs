using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSplitTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "anony!&&!테스트9999!&&!테스트!&&!!&&!uid";

            string[] changes = fileName.Split(new string[] { "!&&!" }, StringSplitOptions.None);

            Console.ReadLine();
        }
    }
}
