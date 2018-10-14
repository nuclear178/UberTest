using System.Data.Entity;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityDb")
        {
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            Database.SetInitializer(new UniversityDbInitializer());

            builder.Entity<Course>()
                .HasKey(c => c.Id);

            base.OnModelCreating(builder);
        }
    }
}