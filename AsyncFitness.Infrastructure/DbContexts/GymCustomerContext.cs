using AsyncFitness.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncFitness.Infrastructure.DbContexts
{
    public class GymCustomerContext : DbContext
    {
        public GymCustomerContext(DbContextOptions<GymCustomerContext> options)
    : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GymCustomer>()
                .HasOne(p => p.Subscription)
                .WithMany(c => c.Subscribers);

        }

        public DbSet<GymCustomer> GymCustomers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}