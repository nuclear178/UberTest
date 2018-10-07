namespace WebApplication.Forms.Courses
{
    public class CreateCourseForm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SpendingStartHour { get; set; }
        public int SpendingEndHour { get; set; }
        public string DayOfWeek { get; set; }
    }
}