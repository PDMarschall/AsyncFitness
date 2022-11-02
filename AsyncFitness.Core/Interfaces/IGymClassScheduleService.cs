using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Models.Facility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IGymClassScheduleService
    {
        Gym FitnessCenter { get; }

        Task<List<GymClassCalendarWeek>> GetCalendarAsync(int year);
        Task<List<GymClassCalendarWeek>> GetCalendarAsync(int year, int month);
        Task<GymClassCalendarWeek> GetCalendarAsync(int year, int month, int week);
        Task<GymClassCalendarWeek> GetCalendarAsync(DateTime date);
        Task<GymClassCalendarWeek> SaveCalendarAsync();
    }
}