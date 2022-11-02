using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Infrastructure.DataServices
{
    public class GymClassScheduleService : IGymClassScheduleService
    {
        private readonly FitnessDbContext _fitnessContext;

        public Gym FitnessCenter { get; }

        public GymClassScheduleService(FitnessDbContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        public Task<List<GymClassCalendarWeek>> GetCalendarAsync(int year)
        {
            throw new NotImplementedException();
        }

        public Task<List<GymClassCalendarWeek>> GetCalendarAsync(int year, int month)
        {
            throw new NotImplementedException();
        }

        public Task<GymClassCalendarWeek> GetCalendarAsync(int year, int month, int week)
        {
            throw new NotImplementedException();
        }

        public Task<GymClassCalendarWeek> GetCalendarAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<GymClassCalendarWeek> SaveCalendarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
