using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
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
    public class TrainerRepository : GenericRepositoryBase<Trainer>
    {
        public TrainerRepository(FitnessDbContext context) : base(context)
        {

        }

        public override int Count => _context.FitnessTrainer.Count();

        public override Trainer Get(string id)
        {
            return _context.FitnessTrainer.Include(s => s.Clients).FirstOrDefault(c => c.Email == id);
        }

        public override IEnumerable<Trainer> Find(Expression<Func<Trainer, bool>> predicate)
        {
            return _context.Set<Trainer>().AsQueryable<Trainer>().Where(predicate).Include(c => c.ClassesByTrainer).Include(p => p.Certifications).Include(f => f.Clients);
        }

        public override async Task<IEnumerable<Trainer>> FindAsync(Expression<Func<Trainer, bool>> predicate)
        {
            return await _context.Set<Trainer>().AsQueryable<Trainer>().Where(predicate).Include(c => c.ClassesByTrainer).Include(p => p.Certifications).Include(f => f.Clients).ToListAsync();
        }
    }
}