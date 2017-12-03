using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Reader : IReader, IDisposable
    {
        public void Dispose()
        {
        }

        /// <summary>
        /// Get all times and timezones from the timezone.txt file
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, string>> Read()
        {
            List<Tuple<string, string>> lReturn = new List<Tuple<string, string>>();
            try
            {
                //read file
                string[] fileParts = File.ReadAllText("Timezone.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                //loop through file parts from the file
                foreach (string part in fileParts)
                {
                    try
                    {
                        //split time and timezone elements and add them to tuple
                        string[] sLineParts = part.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        Tuple<string, string> timeZone = new Tuple<string, string>(sLineParts.First(), sLineParts.Last());

                        lReturn.Add(timeZone);

                    }
                    catch
                    {
                        //error occured so let user know
                        Console.WriteLine("An error occured while reading a line from the file, proceeding to next");
                    }

                }
            }
            catch
            {
                //error occured so let user know
                Console.WriteLine("Error reading timezone.txt file.");
            }

            //return tuple
            return lReturn;
        }

      

    }
}
