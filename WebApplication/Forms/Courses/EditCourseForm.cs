using Application.Dtos;

namespace WebApplication.Forms.Courses
{
    public class EditCourseForm
    {
        public static EditCourseForm CreateFromModel(CourseDto model)
        {
            return new EditCourseForm
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description
            };
        }

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