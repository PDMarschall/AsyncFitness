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

        public Task<List<GroupFitnessClass>> FilterClassesAsync(Dictionary<string, string> criteria)
        {
            throw new NotImplementedException();
        }

        public List<GroupFitnessClass> LoadClassesAsync(Customer customer)
        {
            List<GroupFitnessClass> result = new List<GroupFitnessClass>();

            result = _fitnessClassRepo.Find(c => c.BookedParticipants.Contains(customer)).ToList();

            return result;
        }

        public List<GroupFitnessClass> LoadClassesAsync(Trainer trainer)
        {
            List<GroupFitnessClass> result = new List<GroupFitnessClass>();

            result = _fitnessClassRepo.Find(c => c.Instructors.Contains(trainer)).ToList();

            return result;
        }

        public Task SaveClassesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
