using AsyncFitness.Core.Interfaces;
using AsyncFitness.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.Repository
{
    public abstract class GenericRepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly FitnessBusinessContext _context;

        public GenericRepositoryBase(FitnessBusinessContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> All()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual T Get(string id)
        {
            throw new NotImplementedException();
        }

        public virtual void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
