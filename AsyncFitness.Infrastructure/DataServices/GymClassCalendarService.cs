using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.DTOs.GymClassDTOs;
using AsyncFitness.Core.DTOs.GymClassDTOs.QueryObjects;
using AsyncFitness.Core.Extensions;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.User;
using AsyncFitness.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.DataServices
{
    public class GymClassCalendarService : IGymCalendarService
    {
        private readonly FitnessDbContext _fitnessContext;

        public GymClassCalendarService(FitnessDbContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        public GymCalendarWeekDto LoadCalendarWeek(DateTime date, Customer customer)
        {
            DateTime[] week = date.GetWeekStartAndEnd();

            var fitnessQuery = _fitnessContext.FitnessClass.Where(c => c.Start >= week[0] && c.Start <= week[1]).MapGroupFitnessClassToCalendarDto(customer).AsNoTracking();

            return new GymCalendarWeekDto(fitnessQuery, date);
        }
    }
}
