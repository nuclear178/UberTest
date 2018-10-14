using System.Collections.Generic;
using Application.Dtos;

namespace Application
{
    public interface IUniversityAppService
    {
        void CreateCourse(CreateCourseDto dto, out int id);

        void EditCourse(EditCourseDto dto);

        void DeleteCourse(int courseId);

        CourseDto FindCourse(int courseId);

        IEnumerable<CourseDto> ListCourses();
    }
}