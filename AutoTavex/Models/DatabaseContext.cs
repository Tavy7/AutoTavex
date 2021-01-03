using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AutoTavex.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }

        public DatabaseContext() : base("TavexDatabase") { }
    }
}