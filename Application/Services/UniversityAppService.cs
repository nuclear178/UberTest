using System;
using System.Collections.Generic;
using Application.Dtos;
using Application.Dtos.Assemblers;
using Domain;
using Domain.Models;
using Domain.Services;
using Domain.Services.Repositories;

namespace Application.Services
{
    public class UniversityAppService : IUniversityAppService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISerialNumberGenerator _serialNumberGenerator;

        public UniversityAppService(ICourseRepository courseRepository, ISerialNumberGenerator serialNumberGenerator)
        {
            _courseRepository = courseRepository;
            _serialNumberGenerator = serialNumberGenerator;
        }

        public void CreateCourse(CreateCourseDto dto, out int id)
        {
            var createdCourse = new Course
            {
                SerialNumber = _serialNumberGenerator.Generate(),
                Title = dto.Title,
                Description = dto.Description,
                PublicationDate = DateTime.Now,
                /*SpendingTime = new TimeRange
                {
                    StartDate = new Time
                    {
                        DayOfWeek = dto.StartDayOfWeek,
                        Hour = dto.StartHour
                    },
                    EndDate = new Time
                    {
                        DayOfWeek = dto.EndDayOfWeek,
                        Hour = dto.EndHour
                    }
                }*/
                StartDayOfWeek = dto.StartDayOfWeek,
                StartHour = dto.StartHour,
                EndDayOfWeek = dto.EndDayOfWeek,
                EndHour = dto.EndHour
            };

            _courseRepository.Insert(createdCourse);

            id = createdCourse.Id;
        }

        public void EditCourse(EditCourseDto dto)
        {
            Course editedCourse = _courseRepository.Find(dto.Id);
            if (editedCourse == null)
            {
                throw new DomainException("Failed to edit course.");
            }

            editedCourse.Title = dto.Title;
            editedCourse.Description = dto.Description;

            _courseRepository.Update(editedCourse);
        }

        public void DeleteCourse(int courseId)
        {
            _courseRepository.Remove(courseId);
        }

        public CourseDto FindCourse(int courseId)
        {
            Course foundCourse = _courseRepository.Find(courseId);
            if (foundCourse == null)
            {
                throw new DomainException("Failed to find course.");
            }

            return new CourseDtoAssembler().ConvertToDto(foundCourse);
        }

        public IEnumerable<CourseDto> ListCourses()
        {
            return new CourseDtoAssembler()
                .ConvertToDto(_courseRepository.FindAll());
        }
    }
}