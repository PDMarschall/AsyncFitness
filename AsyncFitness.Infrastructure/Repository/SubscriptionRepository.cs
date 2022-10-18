using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.Repository
{
    public class SubscriptionRepository : GenericRepositoryBase<Subscription>
    {
        public SubscriptionRepository(FitnessContext context) : base(context)
        {
        }

        public override int Count => _context.FitnessSubscriptions.Count();
    }
}
