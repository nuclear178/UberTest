using System.Collections.Generic;
using System.Linq;
using Application.Dtos;
using WebApplication.Models;

namespace WebApplication.ViewModels.Courses
{
    public class CourseIndexViewModel
    {
        public CourseIndexViewModel(IEnumerable<CourseDto> models)
        {
            var dayOfWeekParser = new DayOfWeekParser();
            Courses = models.Select(model => new CourseIndexItemViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                PublicationDate = model.PublicationDate,
                DayOfWeek = dayOfWeekParser.Stringify(model.DayOfWeek),
                StartHour = model.StartHour,
                EndHour = model.EndHour
            });
        }

        public IEnumerable<CourseIndexItemViewModel> Courses { get; }
    }
}