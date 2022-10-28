using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        public override IEnumerable<GroupFitnessClass> Find(Expression<Func<GroupFitnessClass, bool>> predicate)
        {
            return _context.Set<GroupFitnessClass>().AsQueryable<GroupFitnessClass>().Where(predicate)
                .Include(c => c.BookedParticipants)
                .Include(f => f.Concept)
                .Include(p => p.Instructors)
                .Include(l => l.Location).ThenInclude(t => t.Center);
        }

        public override async Task<IEnumerable<GroupFitnessClass>> FindAsync(Expression<Func<GroupFitnessClass, bool>> predicate)
        {
            return await _context.Set<GroupFitnessClass>().AsQueryable<GroupFitnessClass>().Where(predicate)
                .Include(c => c.BookedParticipants)
                .Include(f => f.Concept)
                .Include(p => p.Instructors)
                .Include(l => l.Location).ThenInclude(t => t.Center).ToListAsync();
        }
    }
}
