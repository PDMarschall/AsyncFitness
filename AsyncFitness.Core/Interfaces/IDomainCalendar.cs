using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IDomainCalendarWeek<T> : IEnumerable<T>
    {
        int CalendarWeekNumber { get; }
        int CalendarYear { get; }

        T Add(T entity);
        T AddRange(IEnumerable<T> entity);
        T Update(T entity);
        T Remove(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> All();
        IEnumerable<T> GetCalendarConflicts();
    }
}
