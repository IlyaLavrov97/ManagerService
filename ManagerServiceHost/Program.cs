﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ManagerServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ManagerService.ServiceModule)))
            {
                host.Open();
                Console.WriteLine("Host started :" + DateTime.Now.ToString());
                Console.ReadKey();
            }
        }
    }
}
