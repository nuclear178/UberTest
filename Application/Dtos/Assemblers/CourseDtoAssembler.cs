using Domain.Models;

namespace Application.Dtos.Assemblers
{
    public class CourseDtoAssembler : DtoAssembler<Course, CourseDto>
    {
        public override CourseDto ConvertToDto(Course entity)
        {
            return new CourseDto
            {
                Id = entity.Id,
                SerialNumber = entity.SerialNumber,
                Title = entity.Title,
                Description = entity.Description,
                PublicationDate = entity.PublicationDate
            };
        }
    }
}