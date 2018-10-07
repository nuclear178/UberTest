using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Course> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Course entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Course entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int courseId)
        {
            throw new System.NotImplementedException();
        }
    }
}