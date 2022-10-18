using AsyncFitness.Core.Models;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using AsyncFitness.Web.Areas.Identity.Data;
using AsyncFitness.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AsyncFitness.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly UserManager<AsyncFitnessUser> _userManager;
        private readonly IServiceProvider _serviceProvider;

        public IndexModel(ILogger<IndexModel> logger, UserManager<AsyncFitnessUser> userManager, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
        }

        public void OnGet()
        {
            InitializeCustomer(_serviceProvider);
            InitializeSubscription(_serviceProvider);
        }

        private void InitializeCustomer(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {
                // Look for any movies.
                if (context.FitnessCustomers.Any())
                {
                    return;   // DB has been seeded
                }

                context.FitnessCustomers.Add(
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

            using (var context = new AsyncFitnessWebContext(
                serviceProvider.GetRequiredService<DbContextOptions<AsyncFitnessWebContext>>()))
            {
                if (context.Users.Any())
                {
                    var user = new AsyncFitnessUser
                    {
                        FirstName = "Lars",
                        LastName = "Larsen",
                        UserName = "test@testmail.com",
                        NormalizedUserName = "TEST@TESTMAIL.COM",
                        Email = "test@testmail.com",
                        NormalizedEmail = "TEST@TESTMAIL.COM",
                        EmailConfirmed = true,
                        PhoneNumber = "11111111",

                    };
                    using (_userManager)
                    {
                        _userManager.CreateAsync(user, "Hej123!");
                    }

                }
            }
        }

        private void InitializeSubscription(IServiceProvider serviceProvider)
        {
            using (var context = new FitnessContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<FitnessContext>>()))
            {

                if (context.FitnessSubscriptions.Any())
                {
                    return;
                }

                List<Customer> tempList = new List<Customer>();
                tempList.Add(context.FitnessCustomers.Find("test@testmail.com"));

                context.FitnessSubscriptions.AddRange(
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
    }
}