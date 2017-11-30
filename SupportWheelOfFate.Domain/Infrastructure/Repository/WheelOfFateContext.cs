using System.Data.Entity;

namespace SupportWheelOfFate.Domain.Infrastructure.Repository
{
    public class WheelOfFateContext : DbContext
    {
        public WheelOfFateContext()
        {
            Database.SetInitializer(new WheelOfFateInitializer()); 
        }
        public DbSet<SupportEngineerDto> SuportEngineers {get; set; }
    }
}
