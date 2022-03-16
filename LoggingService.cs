using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
   public static class LoggingService
    {
        public static void WriteToFile( List<ILoggable> ItemsToLog)
        {
            foreach(var item in ItemsToLog)
            {
                Console.WriteLine(item.Log());
            }
        }
    }
}
