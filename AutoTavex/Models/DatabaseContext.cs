using System;
using System.Data.Entity;

namespace AutoTavex.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<SpecialCars> SpecialCars { get; set; }
        public DbSet<Moto> Moto { get; set; }

        public DatabaseContext() : base("TavexDatabase")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<DatabaseContext>());
        }
    }
}