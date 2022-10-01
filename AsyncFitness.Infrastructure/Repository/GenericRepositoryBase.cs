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

        public virtual T Get(string id)
        {
            return _context.Find<T>(id);
        }

        public virtual IEnumerable<T> All()
        {
            return _context.Set<T>().ToArray();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
            .AsQueryable()
            .Where(predicate).ToArray();
        }

        public virtual T Add(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity).Entity;
        }

        public T Delete(T entity)
        {
            return _context.Remove(entity).Entity;
        }

        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
