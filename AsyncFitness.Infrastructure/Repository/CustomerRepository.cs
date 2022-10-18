using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.Repository
{
    public class CustomerRepository : GenericRepositoryBase<Customer>
    {
        public CustomerRepository(FitnessContext context) : base(context)
        {

        }

        public override int Count => _context.FitnessCustomer.Count();

        public override Customer Get(string id)
        {
            return _context.FitnessCustomer.Include(s => s.Subscription).FirstOrDefault(c => c.Email == id);
        }
    }
}
