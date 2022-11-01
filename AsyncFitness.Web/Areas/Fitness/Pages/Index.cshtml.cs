using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Core.Services.GroupFitnessClassServices;
using AsyncFitness.Infrastructure.Repository;
using AsyncFitness.Web.Areas.Identity.Data;
using AsyncFitness.Web.WebServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AsyncFitness.Web.Areas.Fitness.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GroupFitnessClassBookingService _bookingService;        
        private readonly IRepository<Trainer> _trainerRepo;
        private readonly IRepository<Customer> _customerRepo;

        public IndexModel(GroupFitnessClassBookingService bookingService, IRepository<Trainer> trainerRepo, IRepository<Customer> customerRepo)
        {
            _bookingService = bookingService;            
            _trainerRepo = trainerRepo;
            _customerRepo = customerRepo;
        }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<GroupFitnessClassBookingListDto> UserBookings { get; set; }

        public async Task OnGetAsync()
        {
            Trainer trainer = _trainerRepo.Find(t => t.Email == User.Identity.Name).FirstOrDefault();
            Customer customer = _customerRepo.Find(c => c.Email == User.Identity.Name).FirstOrDefault();

            if (trainer != null)
            {
                UserBookings = await _bookingService.LoadClassesAsync(trainer);
            }
            else
            {
                UserBookings = await _bookingService.LoadClassesAsync(customer);
            }
        }
    }
}
