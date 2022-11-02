using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Datastructures
{
    public abstract class GenericDomainCalendarWeek<T> : IDomainCalendarWeek<T>
    {
        private readonly List<T>[] _calendarContainer;

        public int CalendarWeekNumber { get; }
        public int CalendarYear { get; }

        public GenericDomainCalendarWeek(DateOnly dateFromWeek)
        {
            CalendarWeekNumber = ISOWeek.GetWeekOfYear(dateFromWeek.ToDateTime(TimeOnly.MinValue));
            CalendarYear = dateFromWeek.Year;
            _calendarContainer = new List<T>[7];
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i] = new List<T>();
            }
        }

        public abstract T Add(T entity);
        public abstract T AddRange(IEnumerable<T> entity);
        public abstract IEnumerable<T> All();
        public abstract IEnumerable<T> GetCalendarConflicts();
        public abstract IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        public abstract T Remove(T entity);
        public abstract T Update(T entity);

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                foreach (T element in _calendarContainer[i])
                {
                    yield return element;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        
    }
}
