using System.Data.Entity;

namespace Infrastructure.Persistence.EntityFramework
{
    public class UniversityDbInitializer : DropCreateDatabaseIfModelChanges<UniversityContext>
    {
    }
}