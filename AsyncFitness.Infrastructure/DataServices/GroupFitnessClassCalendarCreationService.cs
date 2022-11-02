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
    public class GroupFitnessClassCalendarCreationService : IGroupFitnessClassCalendarCreationService
    {
        private readonly FitnessContext _fitnessContext;

        public FitnessCenter FitnessCenter { get; }

        public GroupFitnessClassCalendarCreationService(FitnessContext fitnessContext)
        {
            _fitnessContext = fitnessContext;
        }

        public Task<List<GroupFitnessClassCalendarWeek>> GetCalendarAsync(int year)
        {
            throw new NotImplementedException();
        }

        public Task<List<GroupFitnessClassCalendarWeek>> GetCalendarAsync(int year, int month)
        {
            throw new NotImplementedException();
        }

        public Task<GroupFitnessClassCalendarWeek> GetCalendarAsync(int year, int month, int week)
        {
            throw new NotImplementedException();
        }

        public Task<GroupFitnessClassCalendarWeek> GetCalendarAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<GroupFitnessClassCalendarWeek> SaveCalendarAsync()
        {
            throw new NotImplementedException();
        }
    }
}
