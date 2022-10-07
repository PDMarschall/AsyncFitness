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
                
                if (context.Customers.Any())
                {
                    return;
                }

                context.Customers.Add(
                    new Customer()
                    {
                        Email = "test@testmail.com",
                        FirstName = "Lars",
                        LastName = "Larsen",                        
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
                
                if (context.Subscriptions.Any())
                {
                    return; 
                }

                List<Customer> tempList = new List<Customer>();
                tempList.Add(context.Customers.Find("test@testmail.com"));

                context.Subscriptions.Add(
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

        public static void InitializeInstructor(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessBusinessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessBusinessContext>>()))
            {

                if (context.Instructors.Any())
                {
                    return;
                }

                context.Instructors.Add(
                    new Instructor()
                    {
                        Email = "instructor@testmail.com",
                        FirstName = "Jens",
                        LastName = "Jensen",
                        Phone = "33333333",
                        Password = "password",
                        City = "Randers",
                        StreetName = "Hvalen",
                        StreetNumber = "12",
                        PostalCode = "6400",
                        Certifications = Core.Enums.InstructorCertifications.PersonalTrainer

                    }
                );
                context.SaveChanges();
            }
        }
    }
}

