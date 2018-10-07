using System.Data.Entity;
using Domain.Models;

namespace Infrastructure.Persistence.EntityFramework
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityDb")
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}