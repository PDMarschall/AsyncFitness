using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IDomainCalendar<T> : IEnumerable<T>
    {
        int CalendarWeekNumber { get; }
        int CalendarYear { get; }
        DateTime[] Dates { get; }
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        IEnumerable<T> GetDay(int index);
    }
}
