using AsyncFitness.Core.DTOs.GymClassDTOs;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.Repository;
using AsyncFitness.Web.Areas.Identity.Data;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AsyncFitness.Web.Areas.Fitness.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IGymClassBookingService _bookingService;        
        private readonly IDomainRepository<Customer> _customerRepo;

        public IndexModel(IGymClassBookingService bookingService, IDomainRepository<Customer> customerRepo)
        {
            _bookingService = bookingService;            
            _customerRepo = customerRepo;
        }

        [BindProperty(SupportsGet = true)]
        public IEnumerable<GymClassBookingOverviewDto> UserBookings { get; set; }

        public async Task OnGetAsync()
        {
            await LoadBookings();
        }

        private async Task LoadBookings()
        {
            IEnumerable<Customer> customerResult = await _customerRepo.FindAsync(c => c.Email == User.Identity.Name);

            UserBookings = await _bookingService.LoadClassesAsync(customerResult.First());
        }
    }
}
