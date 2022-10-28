using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.Repository
{
    public class GroupFitnessClassRepository : GenericRepositoryBase<GroupFitnessClass>
    {
        public GroupFitnessClassRepository(FitnessContext context) : base(context)
        {
        }

        public override int Count => _context.FitnessClass.Count();

        public override IQueryable<GroupFitnessClass> Find(Expression<Func<GroupFitnessClass, bool>> predicate)
        {
            return base.Find(predicate)
                .Include(c => c.BookedParticipants)
                .Include(f => f.Concept)
                .Include(p => p.Instructors)
                .Include(l => l.Location).ThenInclude(t => t.Center);
        }
    }
}
