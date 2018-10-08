using Application.Dtos;
using WebApplication.Models;

namespace WebApplication.Forms.Courses
{
    public class CreateCourseForm
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int SpendingStartHour { get; set; }
        public int SpendingEndHour { get; set; }
        public string DayOfWeek { get; set; }

        public CreateCourseDto ConvertToDto()
        {
            return new CreateCourseDto
            {
                Title = Title,
                Description = Description,
                DayOfWeek = new DayOfWeekParser().Parse(DayOfWeek),
                StartHour = SpendingStartHour,
                EndHour = SpendingEndHour
            };
        }
    }
}