using AsyncFitness.Core.DTOs.GroupFitnessClassDTOs;
using AsyncFitness.Core.DTOs.GroupFitnessClassDTOs.QueryObjects;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.DataServices
{
    public class GroupFitnessClassBookingService : IGroupFitnessClassBookingService
    {
        private readonly FitnessContext _fitnessContext;

        public GroupFitnessClassBookingService(FitnessContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        public async Task<int> CancelBooking(int fitnessClassId, string userEmail)
        {
            GroupFitnessClass fitnessClass = _fitnessContext.FitnessClass.Include(c => c.BookedParticipants).First(f => f.Id ==fitnessClassId);
            fitnessClass.BookedParticipants.RemoveAll(c => c.Email == userEmail);

            return await _fitnessContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GroupFitnessClass>> FilterClassesAsync(Dictionary<string, string> criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<GroupFitnessClassBookingListDto> LoadClassAsync(int fitnessClassId)
        {
            var fitnessQuery = _fitnessContext.FitnessClass.MapGroupFitnessClassToDto(fitnessClassId);

            return await fitnessQuery.FirstAsync();
        }

        public async Task<IEnumerable<GroupFitnessClassBookingListDto>> LoadClassesAsync(Customer customer)
        {            
            var fitnessQuery = _fitnessContext.FitnessClass.MapGroupFitnessClassToDto(customer);

            return await fitnessQuery.ToListAsync();
        }

        public Task SaveClassesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> VerifyUserBooking(int fitnessClassId, string userEmail)
        {
            GroupFitnessClass fitnessClass =  await _fitnessContext.FitnessClass.Include(c => c.BookedParticipants).FirstAsync(f => f.Id == fitnessClassId);
            Customer customer = await _fitnessContext.FitnessCustomer.Where(c => c.Email == userEmail).FirstOrDefaultAsync();
            return fitnessClass.BookedParticipants.Contains(customer);
        }
    }
}
