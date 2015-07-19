using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebjobTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new JobHost();

            host.Call(typeof(Functions).GetMethod("ManualTrigger"));
        }
    }
}
