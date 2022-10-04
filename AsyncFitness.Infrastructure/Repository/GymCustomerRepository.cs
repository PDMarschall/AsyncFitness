using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models;
using AsyncFitness.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.Repository
{
    public class GymCustomerRepository : GenericRepositoryBase<GymCustomer>
    {
        public GymCustomerRepository(FitnessBusinessContext context) : base(context)
        {

        }

        public override int Count => _context.GymCustomers.Count();

        public override GymCustomer Get(string id)
        {
            return _context.GymCustomers.Include(s => s.Subscription).FirstOrDefault(c => c.Email == id);
        }
    }
}
