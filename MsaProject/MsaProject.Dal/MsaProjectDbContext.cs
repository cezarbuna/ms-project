using Microsoft.EntityFrameworkCore;
using MsaProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsaProject.Dal
{
    public class MsaProjectDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Table> Tables { get; set; }

        public MsaProjectDbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=DESKTOP-DLVFJ7V\SQLEXPRESS;Database=Database1;Trusted_Connection=True;TrustServerCertificate=True;",
                b => b.MigrationsAssembly("MsaProject.Dal"))
                .EnableSensitiveDataLogging();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.ApplyConfiguration(new TradeOfferEntityTypeConfiguration());
        //    throw new NotImplementedException();
        //}
    }
}
