using AsyncFitness.Core.DTOs.GroupFitnessClassDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Datastructures
{
    public class GroupFitnessClassCalendarWeekDto : GenericDomainCalendarWeek<GroupFitnessClassBookingCalendarDto>
    {
        public GroupFitnessClassCalendarWeekDto(DateOnly dateFromWeek) : base(dateFromWeek)
        {
        }

        public override GroupFitnessClassBookingCalendarDto Add(GroupFitnessClassBookingCalendarDto entity)
        {
            throw new NotImplementedException();
        }

        public override GroupFitnessClassBookingCalendarDto AddRange(IEnumerable<GroupFitnessClassBookingCalendarDto> entity)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<GroupFitnessClassBookingCalendarDto> All()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<GroupFitnessClassBookingCalendarDto> Find(Expression<Func<GroupFitnessClassBookingCalendarDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<GroupFitnessClassBookingCalendarDto> GetCalendarConflicts()
        {
            throw new NotImplementedException();
        }

        public override GroupFitnessClassBookingCalendarDto Remove(GroupFitnessClassBookingCalendarDto entity)
        {
            throw new NotImplementedException();
        }

        public override GroupFitnessClassBookingCalendarDto Update(GroupFitnessClassBookingCalendarDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
