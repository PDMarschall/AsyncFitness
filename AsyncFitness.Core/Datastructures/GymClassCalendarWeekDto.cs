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
    public class GymClassCalendarWeekDto : GenericDomainCalendarWeek<GymClassCalendarDto>
    {
        public GymClassCalendarWeekDto()
        {

        }

        public GymClassCalendarWeekDto(IQueryable<GymClassCalendarDto> gymClasses, DateTime dateFromWeek)
        {
            CalendarWeekNumber = ISOWeek.GetWeekOfYear(dateFromWeek);
            CalendarYear = dateFromWeek.Year;
            AddRange(gymClasses);
        }

        public override int CalendarWeekNumber { get; }

        public override int CalendarYear { get; }

        public override void Add(GymClassCalendarDto gymClass)
        {
            //TestAgainstGuards(gymClass);
            InsertGymClass(gymClass);
            SortCalendarDayAscending(GetClassIndex(gymClass));
        }

        public override void AddRange(IEnumerable<GymClassCalendarDto> gymClasses)
        {
            foreach (GymClassCalendarDto gymClass in gymClasses)
            {
                //TestAgainstGuards(fitnessClass);
                InsertGymClass(gymClass);
            }
            SortCalendarAscending();
        }

        private void InsertGymClass(GymClassCalendarDto entity)
        {
            int indexOfClass = GetClassIndex(entity);
            _calendarContainer[indexOfClass].Add(entity);
        }

        private int GetClassIndex(GymClassCalendarDto entity)
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
