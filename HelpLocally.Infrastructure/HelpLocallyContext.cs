using HelpLocally.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HelpLocally.Infrastructure
{
    public class HelpLocallyContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<Offer> Offers { get; set; }

        public static readonly ILoggerFactory DbLoggerFactory = LoggerFactory.Create(DbContextOptionsBuilder => { DbContextOptionsBuilder.AddConsole(); });

        public HelpLocallyContext(DbContextOptions<HelpLocallyContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(DbLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Company" },
                new Role { Name = "Customer" }
            });
            
            modelBuilder.Entity<OfferType>().HasData(new List<OfferType>
            {
                new OfferType { Name = "Voucher", Description = "Voucher type of offer" },
                new OfferType { Name = "Product", Description = "Standard product" }
            });
        }
    }
}
