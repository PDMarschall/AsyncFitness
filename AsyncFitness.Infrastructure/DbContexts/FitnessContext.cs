using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncFitness.Infrastructure.DbContexts
{
    public class FitnessContext : DbContext
    {
        #region UserModelClasses
        public DbSet<Customer> FitnessCustomers { get; set; }
        public DbSet<Subscription> FitnessSubscriptions { get; set; }
        public DbSet<Trainer> FitnessTrainers { get; set; }
        public DbSet<Admin> FitnessAdmins { get; set; }
        #endregion

        #region FacilityModelClasses
        public DbSet<GroupFitnessClass> FitnessClasses { get; set; }
        public DbSet<GroupFitnessConcept> FitnessConcepts { get; set; }
        public DbSet<GroupFitnessLocation> FitnessLocations { get; set; }
        public DbSet<FitnessCenter> FitnessCenters { get; set; }
        #endregion

        public FitnessContext(DbContextOptions<FitnessContext> options)
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
            modelBuilder.Entity<FitnessCenter>().HasMany(f => f.Facilities).WithOne(c => c.Center);            
            modelBuilder.Entity<FitnessCenter>().HasMany(f => f.AvailableConcepts).WithMany(c => c.CentersWithConcept).UsingEntity(t => t.ToTable("FitnessCenterConcepts"));            
        }

        private void ConfigureGroupFitnessClass(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupFitnessClass>().HasMany(c => c.BookedParticipants).WithMany(s => s.BookedClasses).UsingEntity(t => t.ToTable("FitnessCustomerClassBookings"));
            modelBuilder.Entity<GroupFitnessClass>().HasMany(c => c.Instructors).WithMany(s => s.ClassesByTrainer).UsingEntity(t => t.ToTable("FitnessTrainerClassBookings"));
            modelBuilder.Entity<GroupFitnessClass>().HasOne(c => c.Location).WithMany(s => s.Classes);
            modelBuilder.Entity<GroupFitnessClass>().HasOne(c => c.Concept).WithMany(s => s.ClassesWithConcept);
        }
    }
}