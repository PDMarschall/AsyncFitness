using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncFitness.Infrastructure.DbContexts
{
    public class FitnessDbContext : DbContext
    {
        #region UserModelClasses
        public DbSet<Customer> FitnessCustomer { get; set; }
        public DbSet<Subscription> FitnessSubscription { get; set; }
        public DbSet<Trainer> FitnessTrainer { get; set; }
        public DbSet<Admin> FitnessAdmin { get; set; }
        #endregion

        #region FacilityModelClasses
        public DbSet<GymClass> FitnessClass { get; set; }
        public DbSet<GymClassConcept> FitnessConcept { get; set; }
        public DbSet<GymClassLocation> FitnessLocation { get; set; }
        public DbSet<Gym> FitnessCenter { get; set; }
        #endregion

        public FitnessDbContext(DbContextOptions<FitnessDbContext> options)
    : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureUserModelClasses(modelBuilder);
            ConfigureFacilityModelClasses(modelBuilder);
        }
        private void ConfigureUserModelClasses(ModelBuilder modelBuilder)
        {
            ConfigureCustomerClass(modelBuilder);
            ConfigureTrainerClass(modelBuilder);
            ConfigureAdminClass(modelBuilder);
        }

        private void ConfigureCustomerClass(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasOne(s => s.Subscription).WithMany(ss => ss.Subscribers);
            modelBuilder.Entity<Customer>().HasOne(t => t.Trainer).WithMany(c => c.Clients);
            modelBuilder.Entity<Customer>(entity => entity.HasIndex(e => e.Email).IsUnique());
        }

        private void ConfigureTrainerClass(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trainer>(entity => entity.HasIndex(e => e.Email).IsUnique());
        }

        private void ConfigureAdminClass(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasMany(a => a.AdministratedFitnessCenters).WithOne(g => g.GymLeader);
            modelBuilder.Entity<Admin>(entity => entity.HasIndex(e => e.Email).IsUnique());
        }

        private void ConfigureFacilityModelClasses(ModelBuilder modelBuilder)
        {
            ConfigureFitnessCenterClass(modelBuilder);
            ConfigureGroupFitnessClass(modelBuilder);
        }

        private void ConfigureFitnessCenterClass(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gym>().HasMany(f => f.Facilities).WithOne(c => c.Center);
            modelBuilder.Entity<Gym>().HasMany(f => f.AvailableConcepts).WithMany(c => c.CentersWithConcept).UsingEntity(t => t.ToTable("FitnessConceptAtCenter"));
            modelBuilder.Entity<Gym>(entity => entity.HasIndex(e => e.Name).IsUnique());
        }

        private void ConfigureGroupFitnessClass(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GymClass>().HasMany(c => c.BookedParticipants).WithMany(s => s.BookedClasses).UsingEntity(t => t.ToTable("FitnessCustomerClassBooking"));
            modelBuilder.Entity<GymClass>().HasMany(c => c.Instructors).WithMany(s => s.ClassesByTrainer).UsingEntity(t => t.ToTable("FitnessTrainerClassBooking"));
            modelBuilder.Entity<GymClass>().HasOne(c => c.Location).WithMany(s => s.Classes);
            modelBuilder.Entity<GymClass>().HasOne(c => c.Concept).WithMany(s => s.ClassesWithConcept);
        }
    }
}