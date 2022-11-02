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

                context.FitnessClass.AddRange(
                    new GymClass
                    {
                        Location = context.FitnessLocation.Where(c => c.Name == "Holdsal 1").First(),
                        Concept = context.FitnessConcept.Where(c => c.Name == "Concept One").First(),
                        Start = new DateTime(2022, 10, 4, 20, 0, 0),
                        End = new DateTime(2022, 10, 4, 21, 0, 0)
                    },
                    new GymClass
                    {
                        Location = context.FitnessLocation.Where(c => c.Name == "Holdsal 2").First(),
                        Concept = context.FitnessConcept.Where(c => c.Name == "Concept Two").First(),
                        Start = new DateTime(2022, 10, 4, 20, 0, 0),
                        End = new DateTime(2022, 10, 4, 21, 0, 0)
                    },
                    new GymClass
                    {
                        Location = context.FitnessLocation.Where(c => c.Name == "Holdsal 1").First(),
                        Concept = context.FitnessConcept.Where(c => c.Name == "Concept One").First(),
                        Start = new DateTime(2022, 10, 5, 20, 0, 0),
                        End = new DateTime(2022, 10, 5, 21, 0, 0)
                    },
                    new GymClass
                    {
                        Location = context.FitnessLocation.Where(c => c.Name == "Holdsal 2").First(),
                        Concept = context.FitnessConcept.Where(c => c.Name == "Concept Two").First(),
                        Start = new DateTime(2022, 10, 5, 20, 0, 0),
                        End = new DateTime(2022, 10, 5, 21, 0, 0)
                    }
                ); ;


                context.SaveChanges();
            }
        }

        private static void InitializeBridgeTables(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessDbContext>>()))
            {
                var class1 = context.FitnessClass.Include(c => c.Instructors).Include(p => p.BookedParticipants).Where(g => g.Id == 1).First();
                var class2 = context.FitnessClass.Include(c => c.Instructors).Include(p => p.BookedParticipants).Where(g => g.Id == 2).First();
                var class3 = context.FitnessClass.Include(c => c.Instructors).Include(p => p.BookedParticipants).Where(g => g.Id == 3).First();
                var class4 = context.FitnessClass.Include(c => c.Instructors).Include(p => p.BookedParticipants).Where(g => g.Id == 4).First();

                if (class1.BookedParticipants.Count == 0 && class1.Instructors.Count == 0 && class1 != null)
                {
                    class1.BookedParticipants.Add(context.FitnessCustomer.First());
                    class1.Instructors.Add(context.FitnessTrainer.First());
                    context.SaveChanges();
                }

                if (class2.BookedParticipants.Count == 0 && class2.Instructors.Count == 0 & class2 != null)
                {
                    class2.BookedParticipants.Add(context.FitnessCustomer.First());
                    class2.Instructors.Add(context.FitnessTrainer.First());
                    context.SaveChanges();
                }

                if (class3.BookedParticipants.Count == 0 && class3.Instructors.Count == 0 & class3 != null)
                {
                    class3.BookedParticipants.Add(context.FitnessCustomer.Where(c => c.Id == 2).First());
                    class3.Instructors.Add(context.FitnessTrainer.First());
                    context.SaveChanges();
                }

                if (class4.BookedParticipants.Count == 0 && class4.Instructors.Count == 0 & class4 != null)
                {
                    class4.BookedParticipants.Add(context.FitnessCustomer.Where(c => c.Id == 2).First());
                    class4.Instructors.Add(context.FitnessTrainer.First());
                    context.SaveChanges();
                }

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
