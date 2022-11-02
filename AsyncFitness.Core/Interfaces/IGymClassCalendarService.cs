using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.DTOs.GroupFitnessClassDTOs;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Interfaces
{
    public interface IGymClassCalendarService
    {
        Task<GroupFitnessClassCalendarWeekDto> LoadCalendarWeekAsync(DateTime date, Customer customer);
    }
}
