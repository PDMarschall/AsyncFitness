using AsyncFitness.Core.DTOs.GymClassDTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Datastructures
{
    public class GymClassCalendarWeekDto : GenericDomainCalendarWeek<GymClassBookingCalendarDto>
    {
        public GymClassCalendarWeekDto()
        {

        }
        public GymClassCalendarWeekDto(IQueryable<GymClassBookingCalendarDto> gymClasses, DateTime dateFromWeek)
        {
            CalendarWeekNumber = ISOWeek.GetWeekOfYear(dateFromWeek);
            CalendarYear = dateFromWeek.Year;
        }

        public override int CalendarWeekNumber { get; }

        public override int CalendarYear { get; }

        public override GymClassBookingCalendarDto Add(GymClassBookingCalendarDto entity)
        {
            throw new NotImplementedException();
        }

        public override GymClassBookingCalendarDto AddRange(IEnumerable<GymClassBookingCalendarDto> entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<GymClassBookingCalendarDto> All()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<GymClassBookingCalendarDto> Find(Expression<Func<GymClassBookingCalendarDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<GymClassBookingCalendarDto> GetCalendarConflicts()
        {
            throw new NotImplementedException();
        }

        public override GymClassBookingCalendarDto Remove(GymClassBookingCalendarDto entity)
        {
            throw new NotImplementedException();
        }

        public override GymClassBookingCalendarDto Update(GymClassBookingCalendarDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
