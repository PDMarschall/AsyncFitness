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
    public abstract class GenericRepositoryBase<T> : IRepository<T>, IRepositoryAsync<T> where T : class
    {
        protected readonly FitnessContext _context;

        public abstract int Count { get; }

        public GenericRepositoryBase(FitnessContext context)
        {
            _context = context;
        }

        public virtual T Get(string id)
        {
            return _context.Find<T>(id);
        }

        public virtual IQueryable<T> All()
        {
            return _context.Set<T>();
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsQueryable<T>().Where(predicate);
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

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
