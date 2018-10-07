using System.Collections.Generic;
using Domain.Models;

namespace Domain.Services.Repositories
{
    public interface ICourseRepository
    {
        Course Find(int courseId);

        IEnumerable<Course> FindAll();

        void Insert(Course entity);

        void Update(Course entity);

        void Remove(int courseId);
    }
}