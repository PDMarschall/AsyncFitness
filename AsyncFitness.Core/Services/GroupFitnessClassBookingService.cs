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
        private readonly IRepository<Customer> _customerRepo;
        private readonly IRepository<GroupFitnessClass> _fitnessClassRepo;
        private readonly IRepository<Trainer> _trainerRepository;

        public GroupFitnessClassBookingService(IRepository<Customer> customerRepo, IRepository<GroupFitnessClass> fitnessClassRepo, IRepository<Trainer> trainerRepository)
        {
            _customerRepo = customerRepo;
            _fitnessClassRepo = fitnessClassRepo;
            _trainerRepository = trainerRepository;
        }

        public Task<IEnumerable<GroupFitnessClass>> FilterClassesAsync(Dictionary<string, string> criteria)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupFitnessClass>> LoadClassesAsync(Customer customer)
        {
            IEnumerable<GroupFitnessClass> result = new List<GroupFitnessClass>();

            result = await _fitnessClassRepo.FindAsync(c => c.BookedParticipants.Contains(customer));

            return result;
        }

        public async Task<IEnumerable<GroupFitnessClass>> LoadClassesAsync(Trainer trainer)
        {
            IEnumerable<GroupFitnessClass> result = new List<GroupFitnessClass>();

            result = await _fitnessClassRepo.FindAsync(c => c.Instructors.Contains(trainer));

            return result;
        }

        public Task SaveClassesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
