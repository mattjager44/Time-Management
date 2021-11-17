using System;
using System.Globalization;
using: asdADasdASDawd
namespace TimeTest
{
    class Program
    {
        private void WeekDay()
        {
            // Assume the current is en-US.
            // Create a DateTime for the first of May, 2003.
            DateTime dt = new DateTime(2003, 5, 1);
            Console.WriteLine("Is Thursday the day of the week for {0:d}?: {1}", dt, dt.DayOfWeek == DayOfWeek.Thursday);
            Console.WriteLine("The day of the week for {0:d} is {1}.", dt, dt.DayOfWeek);
        }
        private void fullYearsDays()
        {
            int[] years = { 2012, 2014, 2022 };
            DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
            Console.WriteLine("Days in the Month for the {0} culture " + "using the {1} calendar\n", CultureInfo.CurrentCulture.Name,
                dtfi.Calendar.GetType().Name.Replace("Calendar", ""));
            Console.WriteLine("{0, -10}{1, -15}{2,4}\n", "Year", "Month", "Days");

            foreach (var year in years)
            {
                for (int ctr = 0; ctr <= dtfi.MonthNames.Length - 1; ctr++)
                {
                    if (String.IsNullOrEmpty(dtfi.MonthNames[ctr]))
                    {
                        continue;
                    }
                    Console.WriteLine("{0, -10}{1,-15}{2, 4}", year, dtfi.MonthNames[ctr], DateTime.DaysInMonth(year, ctr + 1));
                }
                Console.WriteLine();
            }
        }
        private int DaysInMonth()
        {
            int July = 7;
            int Feb = 2;

            int daysInJuly = DateTime.DaysInMonth(2001, July);
            Console.WriteLine($"The number of days in July of 2001 was {daysInJuly}.");

            // daysInFeb gets 28 because the year 1998 was not a leap year.
            int daysInFeb = DateTime.DaysInMonth(1998, Feb);
            Console.WriteLine($"The number of days in Feb of 1998 was {daysInFeb}.");

            // daysInFebLeap gets 29 because the year 1996 was a leap year.
            int daysInFebLeap = DateTime.DaysInMonth(1996, Feb);
            Console.WriteLine($"The number of days in Feb of 1996 was {daysInFebLeap}.");

            int daysInFeb2022 = DateTime.DaysInMonth(2022, Feb);
            Console.WriteLine($"The number of days in Feb of 2022 was {daysInFeb2022}.");
            return daysInFeb2022;
        }
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
            int daysOfMonth;
            currentTimeZone = p.DisplayTimeZone();
            currentDate = p.GetCurrentDate();
            p.DisplayDateWithTimeZoneName(currentDate, currentTimeZone);
            daysOfMonth = p.DaysInMonth();
            p.fullYearsDays();
            p.WeekDay();
        }
    }
}
