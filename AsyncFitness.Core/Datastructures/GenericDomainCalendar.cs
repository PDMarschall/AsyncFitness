using AsyncFitness.Core.DTOs.GymClassDTOs;
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
    public abstract class GenericDomainCalendarWeek<T> : IDomainCalendar<T>
    {
        protected List<T>[] _calendarContainer;

        public abstract int CalendarWeekNumber { get; }
        public abstract int CalendarYear { get; }

        public GenericDomainCalendarWeek()
        {
            _calendarContainer = new List<T>[7];
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i] = new List<T>();
            }
        }

        public abstract void Add(T entity);
        public abstract void AddRange(IEnumerable<T> entities);

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
