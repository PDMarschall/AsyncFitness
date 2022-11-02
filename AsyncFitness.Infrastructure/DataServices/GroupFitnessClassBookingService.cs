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

        public Task<IEnumerable<GroupFitnessClass>> FilterClassesAsync(Dictionary<string, string> criteria)
        {
            throw new NotImplementedException();
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
    }
}
