using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.DTOs.GymClassDTOs;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.DataServices
{
    internal class GymClassCalendarService : IGymClassCalendarService
    {
        private readonly FitnessDbContext _fitnessContext;

        public GymClassCalendarService(FitnessDbContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        public async Task<GymClassCalendarWeekDto> LoadCalendarWeekAsync(DateTime date, Customer customer)
        {
            DateTime[] Week = GetWeekStartAndEnd(date);

            var fitnessQuery = _fitnessContext;

                throw new NotImplementedException();
        }

        private DateTime[] GetWeekStartAndEnd(DateTime date)
        {
            int weekOfYear = ISOWeek.GetWeekOfYear(DateTime.Now);
            DateTime[] weekDates = new DateTime[2];
            weekDates[0] = ISOWeek.ToDateTime(DateTime.Now.Year, weekOfYear, DayOfWeek.Monday);
            weekDates[1] = ISOWeek.ToDateTime(DateTime.Now.Year, weekOfYear, DayOfWeek.Sunday);

            return weekDates;
        }
    }
}
