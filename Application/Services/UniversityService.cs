using System;
using System.Collections.Generic;
using Application.Dtos;
using Application.Dtos.Assemblers;
using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;

namespace Application.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISerialNumberGenerator _serialNumberGenerator;

        public UniversityService(ICourseRepository courseRepository, ISerialNumberGenerator serialNumberGenerator)
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
                CreationDate = DateTime.UtcNow,
                SpendingTime = new Time
                {
                    DayOfWeek = dto.DayOfWeek,
                    StartHour = dto.StartHour,
                    EndHour = dto.EndHour
                }
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