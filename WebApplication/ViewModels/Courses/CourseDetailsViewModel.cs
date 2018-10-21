using System;
using Application.Dtos;

namespace WebApplication.ViewModels.Courses
{
    public class CourseDetailsViewModel
    {
        public CourseDetailsViewModel(CourseDto model)
        {
            Id = model.Id;
            Title = model.Title;
            Description = model.Description;
            CreationDate = model.CreationDate;
        }

        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime CreationDate { get; }
    }
}