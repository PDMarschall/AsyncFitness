using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
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


                context.SaveChanges();
            }
        }

    }
}
