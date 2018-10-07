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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new UniversityDbInitializer());

            modelBuilder.Entity<Course>()
                .HasKey(model => model.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}