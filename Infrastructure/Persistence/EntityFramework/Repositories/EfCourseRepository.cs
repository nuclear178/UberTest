using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Models;
using Domain.Services.Repositories;

namespace Infrastructure.Persistence.EntityFramework.Repositories
{
    public class EfCourseRepository : ICourseRepository
    {
        private readonly UniversityContext _db;

        public EfCourseRepository(UniversityContext db)
        {
            _db = db;
        }

        public Course Find(int id)
        {
            return _db.Courses.Find(id);
        }

        public IEnumerable<Course> FindAll()
        {
            return _db.Courses.ToList();
        }

        public void Insert(Course entity)
        {
            _db.Courses.Add(entity);
            _db.SaveChanges();
        }

        public void Update(Course entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Remove(int id)
        {
            Course course = _db.Courses.Find(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
            }

            _db.SaveChanges();
        }
    }
}