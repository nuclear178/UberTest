using System;

namespace WebApplication.Models
{
    public class TimeParser
    {
        public (DayOfWeek, int) Parse(string dayHour)
        {
            string[] chunks = dayHour.Split('|');
            DayOfWeek dayOfWeek;
            switch (chunks[0])
            {
                case "Mon":
                    dayOfWeek = DayOfWeek.Monday;
                    break;
                case "Tue":
                    dayOfWeek = DayOfWeek.Tuesday;
                    break;
                case "Wed":
                    dayOfWeek = DayOfWeek.Wednesday;
                    break;
                case "Thu":
                    dayOfWeek = DayOfWeek.Thursday;
                    break;
                case "Fri":
                    dayOfWeek = DayOfWeek.Friday;
                    break;
                default:
                    throw new Exception("Day of week parsing error.");
            }

            var hour = Convert.ToInt32(chunks[1]);

            return (dayOfWeek, hour);
        }
    }
}