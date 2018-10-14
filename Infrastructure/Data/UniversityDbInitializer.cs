using System.Data.Entity;

namespace Infrastructure.Data
{
    public class UniversityDbInitializer : DropCreateDatabaseIfModelChanges<UniversityContext>
    {
    }
}