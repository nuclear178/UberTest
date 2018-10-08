using Application.Dtos;

namespace WebApplication.Forms.Courses
{
    public class EditCourseForm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public EditCourseDto ConvertToDto()
        {
            return new EditCourseDto
            {
                Id = Id,
                Title = Title,
                Description = Description,
            };
        }
    }
}