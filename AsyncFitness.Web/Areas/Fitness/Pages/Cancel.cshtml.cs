using AsyncFitness.Core.DTOs.GymClassDTOs;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AsyncFitness.Web.Areas.Fitness.Pages
{
    public class CancelModel : PageModel
    {
        private readonly IGymClassBookingService _bookingService;

        public GymClassBookingOverviewDto BookingToConfirmCancel { get; set; }
        public GymClass BookingToCancel { get; set; }
        public CancelModel(IGymClassBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            bool veriticationResult = await _bookingService.VerifyUserBooking(id.Value, User.Identity.Name);

            if (!veriticationResult)
            {
                return Forbid();
            }

            BookingToConfirmCancel = await _bookingService.LoadClassAsync(id.Value);

            if (BookingToConfirmCancel == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            bool veriticationResult = await _bookingService.VerifyUserBooking(id.Value, User.Identity.Name);

            if (!veriticationResult)
            {
                return Forbid();
            }

            int removeResult = await _bookingService.CancelBooking(id.Value, User.Identity.Name);

            if (removeResult <= 0)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
