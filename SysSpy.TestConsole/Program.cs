using SysSpy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SysSpy.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var scn = new Scanner();

            while (true)
            {

                var answer = Console.ReadLine();
                if (answer == "start")
                    scn.StartScan();
                if (answer == "stop")
                    scn.StopScan();
            }
        }
    }
}
