using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Models;
using Domain.Services.Repositories;

namespace Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EfCourseRepository : ICourseRepository
    {
        private readonly UniversityContext _context;

        public EfCourseRepository(UniversityContext context)
        {
            _context = context;
        }

        public Course Find(int courseId)
        {
            return _context.Courses.Find(courseId);
        }

        public IEnumerable<Course> FindAll()
        {
            return _context.Courses.ToList();
        }

        public void Insert(Course entity)
        {
            _context.Courses.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Course entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int courseId)
        {
            Course course = _context.Courses.Find(courseId);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            _context.SaveChanges();
        }
    }
}