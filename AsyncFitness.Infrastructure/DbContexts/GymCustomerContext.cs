using AsyncFitness.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncFitness.Infrastructure.DbContexts
{
    public class FitnessBusinessContext : DbContext
    {
        public FitnessBusinessContext(DbContextOptions<FitnessBusinessContext> options)
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