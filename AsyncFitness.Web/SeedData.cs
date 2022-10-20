using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using AsyncFitness.Infrastructure.Repository;
using AsyncFitness.Web.Areas.Identity.Data;
using AsyncFitness.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncFitness.Web
{
    public static class SeedData
    {
        public static void InitializeCustomer(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {
                if (context.FitnessCustomer.Any())
                {
                    return;
                }

                context.FitnessCustomer.Add(
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
                    }
                );
                context.SaveChanges();
            }
        }

        public static void InitializeTrainer(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
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

        public static void InitializeAdmin(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
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

        public static void InitializeSubscription(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {

                if (context.FitnessSubscription.Any())
                {
                    return;
                }

                List<Customer> tempList = new List<Customer>();
                var customer = context.FitnessCustomer.Where(c => c.Email == "test@testmail.com");
                tempList.Add(customer.First());

                context.FitnessSubscription.AddRange(
                    new Subscription()
                    {
                        Subscribers = tempList,
                        IsGroupFitness = true,
                        Cost = 50,
                        Description = "Dette er et test-abonnement",
                        Name = "Test-Abonnement"
                    },
                    new Subscription()
                    {
                        Subscribers = null,
                        IsGroupFitness = false,
                        Cost = 25,
                        Description = "Dette er et andet abonnement",
                        Name = "Andet Abonnement"
                    }
                );


                context.SaveChanges();
            }
        }

        public static void InitializeFitnessCenter(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {
                if (context.FitnessCenter.Any())
                {
                    return;
                }
                context.FitnessCenter.Add(new FitnessCenter
                {
                    Name = "Testcenter",
                    GymLeader = context.FitnessAdmin.Where(c => c.FirstName == "Niels").First()
                });


                context.SaveChanges();
            }
        }
        public static void InitializeFitnessLocations(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {
                if (context.FitnessLocation.Any())
                {
                    return;
                }

                context.FitnessLocation.AddRange(
                    new GroupFitnessLocation
                    {
                        Name = "Holdsal 1",
                        Capacity = 30,
                        Center = context.FitnessCenter.Where(c => c.Name == "Testcenter").First()
                    },
                    new GroupFitnessLocation
                    {
                        Name = "Holdsal 2",
                        Capacity = 15,
                        Center = context.FitnessCenter.Where(c => c.Name == "Testcenter").First()
                    }
                    );

                context.SaveChanges();
            }
        }
        public static void InitializeFitnessConcept(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {
                if (context.FitnessConcept.Any())
                {
                    return;
                }

                context.FitnessConcept.AddRange(
                    new GroupFitnessConcept
                    {
                        Name = "Concept One",
                        Description = "This is the first test concept",
                        Duration = new TimeSpan(1, 0, 0),
                    },
                    new GroupFitnessConcept
                    {
                        Name = "Concept Two",
                        Description = "This is the second test concept",
                        Duration = new TimeSpan(1, 30, 0),
                    }
                );

                context.SaveChanges();
            }
        }
        public static void InitializeFitnessClass(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {
                if (context.FitnessClass.Any())
                {
                    return;
                }

                context.FitnessClass.AddRange(
                    new GroupFitnessClass
                    {
                        Location = context.FitnessLocation.Where(c => c.Name == "Holdsal 1").First(),
                        Concept = context.FitnessConcept.Where(c => c.Name == "Concept One").First(),
                        Start = new DateTime(2022, 10, 4, 20, 0, 0),
                        End = new DateTime(2022, 10, 4, 21, 0, 0)
                    },
                    new GroupFitnessClass
                    {
                        Location = context.FitnessLocation.Where(c => c.Name == "Holdsal 2").First(),
                        Concept = context.FitnessConcept.Where(c => c.Name == "Concept Two").First(),
                        Start = new DateTime(2022, 10, 4, 20, 0, 0),
                        End = new DateTime(2022, 10, 4, 21, 0, 0)
                    }
                ); ;


                context.SaveChanges();
            }
        }

        public static void InitializeBridgeTables(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {

            }
        }
    }
}
