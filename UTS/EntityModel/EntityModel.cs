
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

namespace UTS
{
    public partial class UTSDbContext : DbContext
    {
        public UTSDbContext()
            : base("name=DBConnectionString")
        {
        }

        public virtual DbSet<BayBreakdown> BayBreakdowns { get; set; }
        public virtual DbSet<Bay> Bays { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<ProductModel> ProductModels { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<TestCycle> TestCycles { get; set; }
        public virtual DbSet<TesterBreakdown> TesterBreakdowns { get; set; }
        public virtual DbSet<Tester> Testers { get; set; }
        public virtual DbSet<TestTransaction> TestTransactions { get; set; }
        public virtual DbSet<TestUnit> TestUnits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .HasMany(e => e.Testers)
                .WithMany(e => e.Members)
                .Map(m => m.ToTable("MemberTesters"));

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Sectors)
                .WithMany(e => e.Members)
                .Map(m => m.ToTable("SectorMembers"));

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Shifts)
                .WithMany(e => e.Members)
                .Map(m => m.ToTable("ShiftMembers"));
        }
    }
}
