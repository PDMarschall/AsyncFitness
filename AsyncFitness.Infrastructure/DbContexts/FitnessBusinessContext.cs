using AsyncFitness.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            modelBuilder.Entity<Customer>()
                .HasOne(p => p.Subscription)
                .WithMany(c => c.Subscribers);

            modelBuilder.Entity<Customer>()
                .HasOne(p => p.Trainer)
                .WithMany(c => c.Clients);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}