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
    public class InstructorRepository : GenericRepositoryBase<Instructor>
    {
        public InstructorRepository(FitnessContext context) : base(context)
        {

        }

        public override int Count => _context.Instructors.Count();

        public override Instructor Get(string id)
        {
            return _context.Instructors.Include(s => s.Clients).FirstOrDefault(c => c.Email == id);
        }
    }
}