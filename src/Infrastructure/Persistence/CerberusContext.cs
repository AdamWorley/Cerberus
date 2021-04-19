using Cerberus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cerberus.Infrastructure.Persistence
{
    public class CerberusContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public CerberusContext(DbContextOptions<CerberusContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (options.IsConfigured == false)
                options.UseSqlite(@"Data Source=./Cerberus.db");
        }
    }
}