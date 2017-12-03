using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Parser : IParser
    {
        /// <summary>
        /// This displays the "time" string (assuming its the UK time) and gets the timezoneinfo object for Timezone and displays
        /// the time for that zone
        /// </summary>
        /// <param name="time"></param>
        /// <param name="timezone"></param>
        public void DisplayTime(string time, string timezone)
        {
         
            //do a lookup of available timezones
            var timeZoneList = TimeZoneInfo.GetSystemTimeZones();

            //get the zone that best fits the timezone passed in
            var timeZoneToCompare = timeZoneList.Where(i => i.DisplayName.Contains(timezone)).SingleOrDefault();

           //british time zone
            var ukZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

            //if we do not have a time zone to compare with, then dont proceed
            if (timeZoneToCompare != null)
            {
                TimeSpan ukTime;

                //as the text file contains invalid times, we should attempt to parse it first before we process
                if (TimeSpan.TryParse(time, out ukTime))
                {
                    //create new date time object
                    DateTime ukDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, ukTime.Hours, ukTime.Minutes, ukTime.Seconds, ukTime.Milliseconds, DateTimeKind.Utc);
                  
                    //get the difference of hours of time zone that we are comparing with
                    var hoursDifference = timeZoneToCompare.BaseUtcOffset.Hours;
                    
                    var otherCountryTime = ukDate.AddHours(hoursDifference);

                    //format times so that they are more presentable in the console
                    string ukTimeFormatted = String.Format("{0}, {1}:{2}", ukDate.Date.ToLongDateString(), ukDate.TimeOfDay.Hours.ToString("D2") , ukDate.TimeOfDay.Minutes.ToString("D2"));
                    string otherCountryTimeFormatted = String.Format("{0}, {1}:{2}", otherCountryTime.Date.ToLongDateString() ,otherCountryTime.TimeOfDay.Hours.ToString("D2"), otherCountryTime.TimeOfDay.Minutes.ToString("D2"));
 
                    //output times
                    Console.WriteLine(String.Format("The time in the UK is {0} and the time in {1} is {2}", ukTimeFormatted, timezone, otherCountryTimeFormatted));
                }
            }

        }
    }
}
