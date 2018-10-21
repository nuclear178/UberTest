using System;

namespace WebApplication.ViewModels.Courses
{
    public class CourseIndexItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string DayOfWeek { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }
}