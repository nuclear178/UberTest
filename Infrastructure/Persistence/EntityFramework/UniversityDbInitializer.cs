using System.Data.Entity;

namespace Infrastructure.Persistence.EntityFramework
{
    public class UniversityDbInitializer : DropCreateDatabaseAlways<UniversityContext>
    {
    }
}