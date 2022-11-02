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
    public class GymClassRepository : GenericRepositoryBase<GymClass>
    {
        public GymClassRepository(FitnessDbContext context) : base(context)
        {
        }

        public override int Count => _context.FitnessClass.Count();

        public override IEnumerable<GymClass> Find(Expression<Func<GymClass, bool>> predicate)
        {
            return _context.Set<GymClass>().AsQueryable<GymClass>().Where(predicate)
                .Include(c => c.BookedParticipants)
                .Include(f => f.Concept)
                .Include(p => p.Instructors)
                .Include(l => l.Location).ThenInclude(t => t.Center);
        }

        public override async Task<IEnumerable<GymClass>> FindAsync(Expression<Func<GymClass, bool>> predicate)
        {
            return await _context.Set<GymClass>().AsQueryable<GymClass>().Where(predicate)
                .Include(c => c.BookedParticipants)
                .Include(f => f.Concept)
                .Include(p => p.Instructors)
                .Include(l => l.Location).ThenInclude(t => t.Center).ToListAsync();
        }
    }
}
