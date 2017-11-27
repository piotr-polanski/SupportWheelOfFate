using System.Data.Entity;
using SupportWheelOfFate.Domain.Model;

namespace SupportWheelOfFate.Domain.Repository
{
    public class WheelOfFateContext : DbContext
    {
        public WheelOfFateContext()
        {
            Database.SetInitializer(new WheelOfFateInitializer()); 
        }
        public DbSet<SupportEngineer> SuportEngineers {get; set; }
    }
}
