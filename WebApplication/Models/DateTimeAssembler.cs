using System;

namespace WebApplication.Models
{
    public class DayOfWeekParser
    {
        public DayOfWeek Parse(string dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case "Mon":
                    return DayOfWeek.Monday;
                case "Tue":
                    return DayOfWeek.Tuesday;
                case "Wed":
                    return DayOfWeek.Wednesday;
                case "Thu":
                    return DayOfWeek.Thursday;
                case "Fri":
                    return DayOfWeek.Friday;
                default:
                    throw new Exception("Day of week parsing error.");
            }
        }
    }
}