using System;

namespace Domain.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        /*public TimeRange SpendingTime { get; set; }*/
        public DayOfWeek StartDayOfWeek { get; set; }
        public int StartHour { get; set; }
        public DayOfWeek EndDayOfWeek { get; set; }
        public int EndHour { get; set; }
    }
}