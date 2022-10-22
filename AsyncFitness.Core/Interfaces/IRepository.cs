using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IRepository<T>
    {
        public int Count { get; }
        T Add(T entity);
        T Update(T entity);
        T Get(string id);
        T Delete(T entity);
        IQueryable<T> All();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        Task SaveChangesAsync();
    }
}
