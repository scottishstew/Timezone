using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Program
    {        
        /// <summary>
        /// Starting point of program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Reader myReader = new Reader();

            Parser timeZoneParser = new Parser();
            List<Tuple<string, string>> lTimes;

            //read contents from text file
            using (Reader fileReader = new Reader())
            {
               lTimes = fileReader.Read();
            }

            //loop through times and display them on screen
            foreach (var time in lTimes)
            {
                timeZoneParser.DisplayTime(time.Item1, time.Item2);
            }

            //once finished, let user read and press any key to close program
            Console.WriteLine("Press any key...");
            Console.ReadKey();

        }
    }
}
