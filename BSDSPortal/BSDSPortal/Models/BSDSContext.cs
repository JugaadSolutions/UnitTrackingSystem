using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class BSDSContext : DbContext
    {
        public DbSet<Family> Familys {get;set;}
        public DbSet<Location> Locations { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Tester> Testers { get; set; }
        public DbSet<TestCycle> TestCycles { get; set; }
        public DbSet<TestUnit> TestUnits { get; set; }
        public DbSet<Bay> Bays { get; set; }
        public DbSet<TesterBreakdown> TesterBreakdowns {get;set;}
        public DbSet<BayBreakdown> BayBreakdowns { get; set; }
        public DbSet<TestTransaction> TestTransactions { get; set; }
      


        public BSDSContext()
            : base("name=BSDSV1ConnectionString")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
    }
}