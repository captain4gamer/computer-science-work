﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSH_OS
{
    class Program
    {
        static void Main(string[] args)
        {
            OS main = new OS();
            while (main.IsRunning())
            {
                main.Run();
            }
        }
    }
}
