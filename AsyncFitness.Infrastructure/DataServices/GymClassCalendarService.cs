using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.DTOs.GymClassDTOs;
using AsyncFitness.Core.Extensions;
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
            DateTime[] Week = date.GetWeekStartAndEnd();

            var fitnessQuery = _fitnessContext;

                throw new NotImplementedException();
        }
    }
}
