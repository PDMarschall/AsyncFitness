using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Services
{
    public class GroupFitnessClassBookingService : IGroupFitnessClassBookingService
    {
        public Task<List<GroupFitnessClass>> FilterClassesAsync(Dictionary<string, string> criteria)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupFitnessClass>> LoadClassesAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupFitnessClass>> LoadClassesAsync(Trainer trainer)
        {
            throw new NotImplementedException();
        }

        public Task SaveClassesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
