using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Interfaces;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Services
{
    public class FitnessClassCalendarService : IFitnessClassCalendarService
    {
        public FitnessClassCalendarService(FitnessCenter center)
        {
            FitnessCenter = center;
        }

        public FitnessCenter FitnessCenter { get; }

        public async Task<List<GroupFitnessClassCalendar>> GetCalendarAsync(int year)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GroupFitnessClassCalendar>> GetCalendarAsync(int year, int month)
        {
            throw new NotImplementedException();
        }

        public async Task<GroupFitnessClassCalendar> GetCalendarAsync(int year, int month, int week)
        {
            throw new NotImplementedException();
        }
    }
}
