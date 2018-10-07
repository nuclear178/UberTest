using System;

namespace Application.Dtos
{
    public class CreateCourseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DayOfWeek StartDayOfWeek { get; set; }
        public int StartHour { get; set; }
        public DayOfWeek EndDayOfWeek { get; set; }
        public int EndHour { get; set; }
    }
}