using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.Repository
{
    public class GymClassConceptRepository : GenericRepositoryBase<GymClassConcept>
    {
        public GymClassConceptRepository(FitnessDbContext context) : base(context)
        {
        }

        public override int Count => throw new NotImplementedException();
    }
}
