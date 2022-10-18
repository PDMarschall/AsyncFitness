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
    public class TrainerRepository : GenericRepositoryBase<Trainer>
    {
        public TrainerRepository(FitnessContext context) : base(context)
        {

        }

        public override int Count => _context.FitnessTrainer.Count();

        public override Trainer Get(string id)
        {
            return _context.FitnessTrainer.Include(s => s.Clients).FirstOrDefault(c => c.Email == id);
        }
    }
}