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
        public SelectList SubscriptionsList { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            public Subscription NewSubscription { get; set; }
        }

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
            SubscriptionsList = new SelectList(_subscriptionRepo.Find(s => !s.Subscribers.Contains(_customerRepo.Get(email))));            
        }

        public async Task<IActionResult> OnPostChangeSubscriptionAsync()
        {
            //var user = await _userManager.GetUserAsync(User);
            //if (user == null)
            //{
            //    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            //}

            //if (!ModelState.IsValid)
            //{
            //    await LoadAsync(user);
            //    return Page();
            //}

            //var email = await _userManager.GetEmailAsync(user);
            //if (Input.NewEmail != email)
            //{
            //    var userId = await _userManager.GetUserIdAsync(user);
            //    var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
            //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            //    var callbackUrl = Url.Page(
            //        "/Account/ConfirmEmailChange",
            //        pageHandler: null,
            //        values: new { area = "Identity", userId = userId, email = Input.NewEmail, code = code },
            //        protocol: Request.Scheme);
            //    await _emailSender.SendEmailAsync(
            //        Input.NewEmail,
            //        "Confirm your email",
            //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            //    StatusMessage = "Confirmation link to change email sent. Please check your email.";
            //    return RedirectToPage();
            //}

            //StatusMessage = "Your email is unchanged.";
            //return RedirectToPage();
            return Page();
        }
    }
}
