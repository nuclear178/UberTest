using System;

namespace Domain.Models
{
    public class Time
    {
        public DayOfWeek DayOfWeek { get; set; }
        public int StartTimeHour { get; set; }
        public int EndTimeHour { get; set; }
    }
}