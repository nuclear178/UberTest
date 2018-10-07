using System.Collections.Generic;
using Application.Dtos;

namespace WebApplication.ViewModels.Courses
{
    public class CourseIndexViewModel
    {
        public IEnumerable<CourseDto> Courses { get; set; }
    }
}