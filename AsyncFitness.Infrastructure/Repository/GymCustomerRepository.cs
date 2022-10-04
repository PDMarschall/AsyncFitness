using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models;
using AsyncFitness.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.Repository
{
    public class GymCustomerRepository : GenericRepositoryBase<GymCustomer>
    {        
        private readonly IRepository<Subscription> _subRepo;

        public GymCustomerRepository(FitnessBusinessContext context, IRepository<Subscription> subRepo) : base(context)
        {            
            _subRepo = subRepo;
        }

        public override int Count => _context.GymCustomers.Count();

        public override GymCustomer Get(string id)
        {
            GymCustomer customer = _context.Find<GymCustomer>(id);
            customer.Subscription = _subRepo.Find(s => s.Subscribers.Contains(customer)).First();
            return customer;
        }
    }
}
