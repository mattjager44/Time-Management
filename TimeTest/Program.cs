using System;
using System.Globalization;

namespace TimeTest
{
    class Program
    {
        private void DisplayDateWithTimeZoneName(DateTime date1, TimeZoneInfo timeZone)
        {
            Console.WriteLine("The time is {0:t} on {0:d} {1}", date1, timeZone.IsDaylightSavingTime(date1) ? 
                timeZone.DaylightName : timeZone.StandardName);
        }
        private DateTime GetCurrentDate()
        {
            DateTime localDate = DateTime.Now;
            DateTime utcDate = DateTime.UtcNow;
            String[] cultureNames = { "en-US", "en-GB", "fr-FR", "de-DE", "ru-RU" };
            foreach (var cultureName in cultureNames)
            {
                var culture = new CultureInfo(cultureName);
                Console.WriteLine("{0}:", culture.NativeName);
                Console.WriteLine("   Local date and time: {0}, {1:G}", localDate.ToString(culture), localDate.Kind);
                Console.WriteLine("   UTC date and time: {0}, {1:G}\n", utcDate.ToString(culture), utcDate.Kind);
            }
            return localDate;
        }
        private TimeZoneInfo DisplayTimeZone()
        {
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            Console.WriteLine("Local Time Zone ID: {0}", localZone.Id);
            Console.WriteLine("   Display Name is: {0}.", localZone.DisplayName);
            Console.WriteLine("   Standard name is: {0}.", localZone.StandardName);
            Console.WriteLine("   Daylight saving name is: {0}.", localZone.DaylightName);
            return localZone;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            TimeZoneInfo currentTimeZone;
            DateTime currentDate;
            currentTimeZone = p.DisplayTimeZone();
            currentDate = p.GetCurrentDate();
            p.DisplayDateWithTimeZoneName(currentDate, currentTimeZone);
        }
    }
}
