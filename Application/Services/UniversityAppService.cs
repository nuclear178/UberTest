using System.Collections.Generic;
using Application.Dtos;
using Domain.Services.Repositories;

namespace Application.Services
{
    public class UniversityAppService : IUniversityAppService
    {
        private readonly ICourseRepository _courseRepository;

        public UniversityAppService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void CreateCourse(CreateCourseDto dto, out int id)
        {
            throw new System.NotImplementedException();
        }

        public void EditCourse(EditCourseDto dto)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCourse(int courseId)
        {
            throw new System.NotImplementedException();
        }

        public CourseDto FindCourse(int courseId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CourseDto> ListCourses()
        {
            throw new System.NotImplementedException();
        }
    }
}