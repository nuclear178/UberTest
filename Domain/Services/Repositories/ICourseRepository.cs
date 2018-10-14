using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Services.Repositories
{
    public interface ICourseRepository
    {
        Course Find(int id);

        IEnumerable<Course> FindAll();

        void Insert(Course entity);

        void Update(Course entity);

        void Remove(int id);
    }
}