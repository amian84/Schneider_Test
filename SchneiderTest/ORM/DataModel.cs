using ORM.Model;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ORM
{
    /// <summary>
    /// Class with database context from EM6
    /// </summary>
    public class DataModel:DbContext, IDataModel
    {
        public DataModel()
        {
        }

        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<WaterMeter> WaterMeters { get; set; }
        public DbSet<ElectricityMeter> ElectricityMeters { get; set; }

        public Gateway AddGateway(Gateway gw)
        {
            Gateway gatewayret =  Gateways.Add(gw);
            SaveChanges();
            return gatewayret;
        }

        public IEnumerable<Gateway> GetGateways()
        {
            return Gateways;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
