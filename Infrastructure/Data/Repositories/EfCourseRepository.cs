using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Entities;
using Domain.Services.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class EfCourseRepository : ICourseRepository
    {
        private readonly UniversityContext _dbContext;

        public EfCourseRepository(UniversityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Course Find(int id)
        {
            return _dbContext.Courses.Find(id);
        }

        public IEnumerable<Course> FindAll()
        {
            return _dbContext.Courses.ToList();
        }

        public void Insert(Course entity)
        {
            _dbContext.Courses.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Course entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            Course course = _dbContext.Courses.Find(id);
            if (course != null)
            {
                _dbContext.Courses.Remove(course);
            }

            _dbContext.SaveChanges();
        }
    }
}