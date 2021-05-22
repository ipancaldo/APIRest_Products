using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Entities;

namespace Data
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindConnection")
        {
        }

        //public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customers>()
            //    .Property(e => e.CustomerID)
            //    .IsFixedLength();

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.Employees1)
                .WithOptional(e => e.Employees2)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Products>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);
        }
    }
}
