using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessTester
{
    class Program
    {
        [DllImport("kernel32")]
        private static extern Int32 GetCurrentProcessId();


        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                if ((process.ProcessName == "GoWIX_Importer2") && (process.Id != GetCurrentProcessId()))
                {
                    Console.ReadLine();
                }
            }
        }
    }
}
