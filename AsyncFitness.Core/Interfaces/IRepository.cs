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
        T ReturnEntity(string id);
        IEnumerable<T> Select(Expression<Func<T, bool>> predicate);
        T Update(T entity);
        T Insert(T entity);
        T Delete(T entity);
        void SaveChanges();
    }
}
