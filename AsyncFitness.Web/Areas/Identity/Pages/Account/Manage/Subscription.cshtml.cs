using AsyncFitness.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.WebUtilities;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AsyncFitness.Web.Areas.Identity.Pages.Account.Manage
{
    public class SubscriptionModel : PageModel
    {
        private readonly UserManager<AsyncFitnessUser> _userManager;
        private readonly SignInManager<AsyncFitnessUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<Subscription> _subscriptionRepo;

        public SubscriptionModel(
            UserManager<AsyncFitnessUser> userManager,
            SignInManager<AsyncFitnessUser> signInManager,
            IEmailSender emailSender,
            IRepository<Customer> customerRepo,
            IRepository<Subscription> subscriptionRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _customerRepo = customerRepo;
            _subscriptionRepo = subscriptionRepo;
        }

        public Subscription Subscription { get; set; }
        public List<Subscription> SubscriptionsList { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public string NewSubscriptionName { get; set; }



        public async Task<IActionResult> OnGetAsync()
        {
            AsyncFitnessUser user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        private async Task LoadAsync(AsyncFitnessUser user)
        {
            string email = await _userManager.GetEmailAsync(user);
            Subscription = _customerRepo.Get(email).Subscription;
            SubscriptionsList = _subscriptionRepo.Find(s => !s.Subscribers.Contains(_customerRepo.Get(email))).ToList();
        }

        public async Task<IActionResult> OnPostChangeSubscriptionAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var customer = _customerRepo.Get(user.Email);
            if (user == null || customer == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var currentSubscription = _subscriptionRepo.Find(s => s.Subscribers.Contains(customer));
            var selectedSubscription = _subscriptionRepo.Get(NewSubscriptionName);

            if (selectedSubscription != currentSubscription)
            {
                customer.Subscription = selectedSubscription;
                _customerRepo.Update(customer);
                _customerRepo.SaveChanges();

                StatusMessage = $"Subscription changed to {selectedSubscription.Name}";
                return RedirectToPage();
            }

            StatusMessage = "Your subscription is unchanged.";
            return RedirectToPage();
        }
    }
}
