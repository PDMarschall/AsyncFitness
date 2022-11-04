using AsyncFitness.Core.Extensions;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using AsyncFitness.Infrastructure.Repository;
using AsyncFitness.Web.Areas.Identity.Data;
using AsyncFitness.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncFitness.Web
{
    public static class SeedData
    {
        public static void CreateInitialDb(IServiceProvider serviceProvider)
        {
            EnsureDB(serviceProvider);

            //user classes
            InitializeCustomer(serviceProvider);
            InitializeIdentity(serviceProvider);
            InitializeSubscription(serviceProvider);
            InitializeTrainer(serviceProvider);
            InitializeAdmin(serviceProvider);

            //facility classes
            InitializeFitnessCenter(serviceProvider);
            InitializeFitnessLocations(serviceProvider);
            InitializeFitnessConcept(serviceProvider);
            InitializeFitnessClass(serviceProvider);

            //many to many relations
            InitializeBridgeTables(serviceProvider);
        }

        private static void EnsureDB(IServiceProvider serviceProvider)
        {
            var domainDBContext = serviceProvider.GetRequiredService<FitnessDbContext>();
            domainDBContext.Database.EnsureDeleted();
            domainDBContext.Database.EnsureCreated();

            var identityDBContext = serviceProvider.GetRequiredService<AsyncFitnessWebContext>();
            identityDBContext.Database.EnsureDeleted();
            identityDBContext.Database.EnsureCreated();
        }

        private static void InitializeCustomer(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                if (context.FitnessCustomer.Any())
                {
                    return;
                }

                context.FitnessCustomer.AddRange(
                    new Customer
                    {
                        Email = "test@testmail.com",
                        Phone = "11111111",
                        FirstName = "Lars",
                        LastName = "Larsen",
                        StreetName = "Fiskervænget",
                        StreetNumber = "14",
                        City = "Sønderborg",
                        PostalCode = "6400"
                    },
                    new Customer
                    {
                        Email = "test2@testmail.com",
                        Phone = "22222222",
                        FirstName = "Thyge",
                        LastName = "Thygesen",
                        StreetName = "Fiskervænget",
                        StreetNumber = "14",
                        City = "Sønderborg",
                        PostalCode = "6400"
                    }
                );
                context.SaveChanges();
            }
        }

        private static async void InitializeIdentity(IServiceProvider serviceProvider)
        {
            using (var _context = new AsyncFitnessWebContext(serviceProvider.GetRequiredService<DbContextOptions<AsyncFitnessWebContext>>()))
            {
                var userOne = new AsyncFitnessUser
                {
                    FirstName = "Lars",
                    LastName = "Larsen",
                    UserName = "test@testmail.com",
                    PhoneNumber = "11111111",
                    NormalizedUserName = "test@testmail.com",
                    Email = "test@testmail.com",
                    NormalizedEmail = "test@testmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var userTwo = new AsyncFitnessUser
                {
                    FirstName = "Thyge",
                    LastName = "Thygesen",
                    UserName = "test2@testmail.com",
                    PhoneNumber = "22222222",
                    NormalizedUserName = "test2@testmail.com",
                    Email = "test2@testmail.com",
                    NormalizedEmail = "test2@testmail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var roleStore = new RoleStore<IdentityRole>(_context);

                if (!_context.Roles.Any(r => r.Name == "admin"))
                {
                    await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
                }

                if (!_context.Users.Any(u => u.UserName == userOne.UserName))
                {
                    var password = new PasswordHasher<AsyncFitnessUser>();
                    var hashed = password.HashPassword(userOne, "Hej123!");
                    userOne.PasswordHash = hashed;
                    var userStore = new UserStore<AsyncFitnessUser>(_context);
                    await userStore.CreateAsync(userOne);
                    await userStore.AddToRoleAsync(userOne, "admin");
                }
                if (!_context.Users.Any(u => u.UserName == userTwo.UserName))
                {
                    var password = new PasswordHasher<AsyncFitnessUser>();
                    var hashed = password.HashPassword(userTwo, "Hej456!");
                    userTwo.PasswordHash = hashed;
                    var userStore = new UserStore<AsyncFitnessUser>(_context);
                    await userStore.CreateAsync(userTwo);
                    await userStore.AddToRoleAsync(userTwo, "admin");
                }

                await _context.SaveChangesAsync();
            }
        }

        private static void InitializeTrainer(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                if (context.FitnessTrainer.Any())
                {
                    return;
                }

                context.FitnessTrainer.Add(
                    new Trainer
                    {
                        Email = "test2@testmail.com",
                        Phone = "22222222",
                        FirstName = "Jens",
                        LastName = "Jensen",
                        StreetName = "Fiskervænget",
                        StreetNumber = "14",
                        City = "Sønderborg",
                        PostalCode = "6400"
                    }
                );
                context.SaveChanges();
            }
        }

        private static void InitializeAdmin(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                if (context.FitnessAdmin.Any())
                {
                    return;
                }

                context.FitnessAdmin.Add(
                    new Admin
                    {
                        Email = "test3@testmail.com",
                        Phone = "33333333",
                        FirstName = "Niels",
                        LastName = "Nielsen",
                        StreetName = "Fiskervænget",
                        StreetNumber = "14",
                        City = "Sønderborg",
                        PostalCode = "6400"
                    }
                );
                context.SaveChanges();
            }
        }

        private static void InitializeSubscription(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {

                if (context.FitnessSubscription.Any())
                {
                    return;
                }

                var customerOne = context.FitnessCustomer.Where(c => c.Email == "test@testmail.com");
                var customerTwo = context.FitnessCustomer.Where(c => c.Email == "test2@testmail.com");

                context.FitnessSubscription.AddRange(
                    new Subscription()
                    {
                        Subscribers = new List<Customer>(customerOne),
                        IsGroupFitness = true,
                        Cost = 50,
                        Description = "Dette er et test-abonnement",
                        Name = "Test-Abonnement"
                    },
                    new Subscription()
                    {
                        Subscribers = new List<Customer>(customerTwo),
                        IsGroupFitness = false,
                        Cost = 25,
                        Description = "Dette er et andet abonnement",
                        Name = "Andet Abonnement"
                    }
                );


                context.SaveChanges();
            }
        }

        private static void InitializeFitnessCenter(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                if (context.FitnessCenter.Any())
                {
                    return;
                }
                context.FitnessCenter.Add(new Gym
                {
                    Name = "Testcenter",
                    GymLeader = context.FitnessAdmin.Where(c => c.FirstName == "Niels").First()
                });

                context.SaveChanges();
            }
        }

        private static void InitializeFitnessLocations(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                if (context.FitnessLocation.Any())
                {
                    return;
                }

                context.FitnessLocation.AddRange(
                    new GymClassLocation
                    {
                        Name = "Holdsal 1",
                        Capacity = 30,
                        Center = context.FitnessCenter.Where(c => c.Name == "Testcenter").First()
                    },
                    new GymClassLocation
                    {
                        Name = "Holdsal 2",
                        Capacity = 15,
                        Center = context.FitnessCenter.Where(c => c.Name == "Testcenter").First()
                    }
                    );

                context.SaveChanges();
            }
        }

        private static void InitializeFitnessConcept(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                if (context.FitnessConcept.Any())
                {
                    return;
                }

                context.FitnessConcept.AddRange(
                    new GymClassConcept
                    {
                        Name = "Concept One",
                        Description = "This is the first test concept",
                        Duration = new TimeSpan(1, 0, 0),
                    },
                    new GymClassConcept
                    {
                        Name = "Concept Two",
                        Description = "This is the second test concept",
                        Duration = new TimeSpan(1, 30, 0),
                    }
                );

                context.SaveChanges();
            }
        }

        private static void InitializeFitnessClass(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                if (context.FitnessClass.Any())
                {
                    return;
                }

                var week = DateTime.Now.GetWeekStartAndEnd();

                for (DateTime i = week[0]; i <= week[1].AddDays(7); i = i.AddDays(1))
                {
                    context.FitnessClass.AddRange(
                    new GymClass
                    {
                        Location = context.FitnessLocation.Where(c => c.Name == "Holdsal 1").First(),
                        Concept = context.FitnessConcept.Where(c => c.Name == "Concept One").First(),
                        Start = i.AddHours(20),
                        End = i.AddHours(21)
                    },
                    new GymClass
                    {
                        Location = context.FitnessLocation.Where(c => c.Name == "Holdsal 2").First(),
                        Concept = context.FitnessConcept.Where(c => c.Name == "Concept Two").First(),
                        Start = i.AddHours(20),
                        End = i.AddHours(21)
                    });
                }

                context.SaveChanges();
            }
        }

        private static void InitializeBridgeTables(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                var seededGymClasses = context.FitnessClass.Include(c => c.Instructors).Include(p => p.BookedParticipants);

                foreach (var item in seededGymClasses)
                {
                    if (item.BookedParticipants.Count == 0 && item.Instructors.Count == 0 && item != null)
                    {
                        item.BookedParticipants.Add(context.FitnessCustomer.First());
                        item.Instructors.Add(context.FitnessTrainer.First());
                        
                    }
                }

                context.SaveChanges();

                var fitnessCenter = context.FitnessCenter.Include(c => c.GymLeader).Include(d => d.Facilities).Include(a => a.AvailableConcepts).First();

                if (fitnessCenter.AvailableConcepts.Count == 0)
                {
                    fitnessCenter.AvailableConcepts.Add(context.FitnessConcept.Find(1));
                    fitnessCenter.AvailableConcepts.Add(context.FitnessConcept.Find(2));
                    context.SaveChanges();
                }
            }
        }
    }
}
