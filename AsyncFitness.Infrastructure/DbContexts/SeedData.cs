using AsyncFitness.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.DbContexts
{

    public static class SeedData
    {
        public static void InitializeCustomer(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessBusinessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessBusinessContext>>()))
            {
                // Look for any movies.
                if (context.GymCustomers.Any())
                {
                    return;   // DB has been seeded
                }

                context.GymCustomers.AddRange(
                    new GymCustomer()
                    {
                        Email = "test@testmail.com",
                        FirstName = "Lars",
                        LastName = "Larsen",
                        MiddleName = "L.",
                        Phone = "11111111",
                        Password = "password",
                        City = "Sønderborg",
                        StreetName = "Fiskervænget",
                        StreetNumber = "12",
                        PostalCode = "6400",
                        Subscription = context.Subscriptions.Find("Test-Abonnement")
                       
                    }
                );
                context.SaveChanges();
            }
        }
        public static void InitializeSubscription(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessBusinessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessBusinessContext>>()))
            {
                // Look for any movies.
                if (context.Subscriptions.Any())
                {
                    return;   // DB has been seeded
                }

                List<GymCustomer> tempList = new List<GymCustomer>();
                tempList.Add(context.GymCustomers.Find("test@testmail.com"));
                context.Subscriptions.AddRange(
                    new Subscription()
                    {
                        Subscribers = tempList,
                        IsGroupFitness = true,
                        Cost = 50,
                        Description = "Dette er et test-abonnement",
                        Name = "Test-Abonnement"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

