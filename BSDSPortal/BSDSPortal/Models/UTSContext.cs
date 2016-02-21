using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BSDSPortal.Models
{
    public class UTSContext : DbContext
    {
        public DbSet<Bay> Bays { get; set; }
       
        public DbSet<Family> Familys {get;set;}
        public DbSet<Location> Locations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
       
        public DbSet<Member> Members { get; set; }
        
        public DbSet<ProductModel> ProductModels { get; set; }
       
       
        public DbSet<Shift> Shifts { get; set; }
       
   
        public DbSet<Unit> Units { get; set; }

        public UTSContext()
            : base("name=UTSConnectionString")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
    }
}