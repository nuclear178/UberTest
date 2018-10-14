using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
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

            ConfigureCourse(builder.Entity<Course>());

            base.OnModelCreating(builder);
        }

        private static void ConfigureCourse(EntityTypeConfiguration<Course> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .IsRequired();

            builder.Property(c => c.SerialNumber)
                .IsRequired();

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.PublicationDate)
                .IsRequired();
        }
    }
}