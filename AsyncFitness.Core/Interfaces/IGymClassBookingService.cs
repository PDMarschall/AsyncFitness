using AsyncFitness.Core.DTOs.GymClassDTOs;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IGymClassBookingService
    {
        Task<bool> VerifyUserBooking(int id, string email);
        Task<GymClassBookingOverviewDto> LoadClassAsync(int id);
        Task<IEnumerable<GymClassBookingOverviewDto>> LoadClassesAsync(Customer customer);        
        Task<IEnumerable<GymClass>> FilterClassesAsync(Dictionary<string, string> criteria);
        Task<int> CancelBooking(int id, string email);
        Task SaveClassesAsync();
    }
}