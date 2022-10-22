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
    public interface IGroupFitnessClassCalendarCreationService
    {
        FitnessCenter FitnessCenter { get; }

        Task<List<GroupFitnessClassCalendarWeek>> GetCalendarAsync(int year);
        Task<List<GroupFitnessClassCalendarWeek>> GetCalendarAsync(int year, int month);
        Task<GroupFitnessClassCalendarWeek> GetCalendarAsync(int year, int month, int week);
        Task<GroupFitnessClassCalendarWeek> GetCalendarAsync(DateTime date);
        Task<GroupFitnessClassCalendarWeek> SaveCalendarAsync();
    }
}