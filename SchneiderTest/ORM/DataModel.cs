using ORM.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ORM
{
    /// <summary>
    /// Class with database context from EM6
    /// </summary>
    public class DataModel:DbContext
    {
        public DataModel()
        {
        }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<WaterMeter> WaterMeters { get; set; }
        public DbSet<ElectricityMeter> ElectricityMeters { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
