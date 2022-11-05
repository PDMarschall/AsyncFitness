using AsyncFitness.Core.DTOs.GymClassDTOs;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Datastructures
{
    public class GymCalendarWeekDto : GenericDomainCalendarWeek<GymCalendarClassDto>
    {
        public GymCalendarWeekDto()
        {

        }

        public GymCalendarWeekDto(IQueryable<GymCalendarClassDto> gymClasses, DateTime dateFromWeek)
        {
            CalendarWeekNumber = ISOWeek.GetWeekOfYear(dateFromWeek);
            CalendarYear = dateFromWeek.Year;
            AddRange(gymClasses);
        }

        public override int CalendarWeekNumber { get; }

        public override int CalendarYear { get; }

        public override void Add(GymCalendarClassDto gymClass)
        {            
            InsertGymClass(gymClass);
            SortCalendarDayAscending(GetClassIndex(gymClass));
        }

        public override void AddRange(IEnumerable<GymCalendarClassDto> gymClasses)
        {
            foreach (GymCalendarClassDto gymClass in gymClasses)
            {                
                InsertGymClass(gymClass);
            }
            SortCalendarAscending();
        }

        private void InsertGymClass(GymCalendarClassDto entity)
        {
            int indexOfClass = GetClassIndex(entity);
            _calendarContainer[indexOfClass].Add(entity);
        }

        private int GetClassIndex(GymCalendarClassDto entity)
        {
            return (int)(entity.Start.DayOfWeek + 6) % 7;
        }

        private void SortCalendarDayAscending(int indexOfDay)
        {
            _calendarContainer[indexOfDay].Sort((c1, c2) => c1.Start.CompareTo(c2.Start));
        }

        private void SortCalendarAscending()
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i].Sort((c1, c2) => c1.Start.CompareTo(c2.Start));
            }
        }
    }
}
