using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.Repository;
using AsyncFitness.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AsyncFitness.Web.Areas.Fitness.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGroupFitnessClassBookingService _bookingService;
        private readonly UserManager<AsyncFitnessUser> _userManager;
        private readonly IRepository<Trainer> _trainerRepo;
        private readonly IRepository<Customer> _customerRepo;

        public IndexModel(IGroupFitnessClassBookingService bookingService, UserManager<AsyncFitnessUser> userManager, IRepository<Trainer> trainerRepo, IRepository<Customer> customerRepo)
        {
            _bookingService = bookingService;
            _userManager = userManager;
            _trainerRepo = trainerRepo;
            _customerRepo = customerRepo;
        }

        [BindProperty(SupportsGet = true)]
        public List<GroupFitnessClass> UserBookings { get; set; }

        public async Task OnGetAsync()
        {
            Trainer trainer = _trainerRepo.Find(t => t.Email == User.Identity.Name).FirstOrDefault();
            Customer customer = _customerRepo.Find(c => c.Email == User.Identity.Name).FirstOrDefault();

            if (trainer != null)
            {
                UserBookings =  _bookingService.LoadClassesAsync(trainer);
            }
            else
            {
                UserBookings = _bookingService.LoadClassesAsync(customer);
            }
        }
    }
}
