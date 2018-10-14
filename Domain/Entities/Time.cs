using System;

namespace Domain.Entities
{
    public class Time
    {
        public DayOfWeek DayOfWeek { get; set; }
        public int StartTimeHour { get; set; }
        public int EndTimeHour { get; set; }
    }
}