using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace WebjobTest
{
    public static class Functions
    {
        [NoAutomaticTrigger]
        public static void ManualTrigger(TextWriter log)
        {
            log.WriteLine("testing 123");
        }
    }
}
