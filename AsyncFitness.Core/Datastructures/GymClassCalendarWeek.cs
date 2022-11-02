using AsyncFitness.Core.Exceptions;
using AsyncFitness.Core.Extensions;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Datastructures
{
    /// <summary>
    /// A collection of GroupFitnessClasses spanning one ISO 8601 calendar week.
    /// </summary>
    public class GymClassCalendarWeek : IEnumerable<GymClass>
    {
        private readonly List<GymClass>[] _calendarContainer;

        public int CalendarWeekNumber { get; }
        public int CalendarYear { get; }

        /// <summary>
        /// Initiates an instance of a GroupFitnessClassCalendar for a particular ISO 8601 calendar week of a particular year.
        /// </summary>
        /// <param name="calendarWeek">The DateOnly containing the information of the year and week for the calendar.</param>
        public GymClassCalendarWeek(DateOnly dateFromWeek)
        {
            CalendarWeekNumber = ISOWeek.GetWeekOfYear(dateFromWeek.ToDateTime(TimeOnly.MinValue));
            CalendarYear = dateFromWeek.Year;
            _calendarContainer = new List<GymClass>[7];
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i] = new List<GymClass>();
            }
        }

        /// <summary>
        /// Adds a GroupFitnessClass to the GroupFitnessClassCalendar. Only GroupFitnessClasses matching the calendars week and year can be added.
        /// </summary>
        /// <param name="fitnessClass">The GroupFitnessClass to be added to the calendar.</param>
        public void AddClass(GymClass fitnessClass)
        {
            TestAgainstGuards(fitnessClass);
            InsertFitnessClass(fitnessClass);
            SortCalendarDayAscending(GetClassIndex(fitnessClass));
        }

        /// <summary>
        /// Adds a range of GroupFitnessClasses to the GroupFitnessClassCalendar. Only GroupFitnessClasses matching the calendars week and year can be added.
        /// </summary>
        /// <param name="fitnessClass">The GroupFitnessClass to be added to the calendar.</param>
        public void AddClassRange(IEnumerable<GymClass> fitnessClasses)
        {
            foreach (GymClass fitnessClass in fitnessClasses)
            {
                TestAgainstGuards(fitnessClass);
                InsertFitnessClass(fitnessClass);
            }
            SortCalendarAscending();
        }

        public void RemoveClass(GymClass fitnessClass)
        {
            int indexOfClass = GetClassIndex(fitnessClass);
            _calendarContainer[indexOfClass].Remove(fitnessClass);
        }

        /// <summary>
        /// Filters the GroupFitnessClassCalendar based on a DayOfWeek.
        /// </summary>
        /// <param name="fitnessLocation">The DayOfWeek to filter according to.</param>
        /// <returns>The GroupFitnessClasses of the GroupFitnessClassCalendar taking place on the DayOfWeek.</returns>
        public IEnumerable<GymClass> GetClasses(DayOfWeek day)
        {
            return _calendarContainer[(int)(day + 6) % 7];
        }

        /// <summary>
        /// Filters the GroupFitnessClassCalendar based on a GroupFitnessLocation.
        /// </summary>
        /// <param name="fitnessLocation">The GroupFitnessLocation to filter according to.</param>
        /// <returns>The GroupFitnessClasses of the GroupFitnessClassCalendar taking place at the GroupFitnessLocation.</returns>
        public IEnumerable<GymClass> GetClasses(GymLocation fitnessLocation)
        {
            List<GymClass> locationClasses = new List<GymClass>();
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                locationClasses.AddRange(_calendarContainer[i].Where(c => c.Location == fitnessLocation));
            }
            return locationClasses;
        }

        /// <summary>
        /// Filters the GroupFitnessClassCalendar based on a GroupFitnessConcept.
        /// </summary>
        /// <param name="concept">The GroupFitnessConcept to filter according to.</param>
        /// <returns>The GroupFitnessClasses of the GroupFitnessClassCalendar containing the GroupFitnessConcept.</returns>
        public IEnumerable<GymClass> GetClasses(GymClassConcept concept)
        {
            List<GymClass> conceptClasses = new List<GymClass>();
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                conceptClasses.AddRange(_calendarContainer[i].Where(c => c.Concept == concept));
            }
            return conceptClasses;
        }

        /// <summary>
        /// Filters the GroupFitnessClassCalendar based on a Trainer.
        /// </summary>
        /// <param name="trainer">The Trainer to filter according to.</param>
        /// <returns>The GroupFitnessClasses of the GroupFitnessClassCalendar which include the Trainer.</returns>
        public IEnumerable<GymClass> GetClasses(Trainer trainer)
        {
            List<GymClass> trainerClasses = new List<GymClass>();
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                trainerClasses.AddRange(_calendarContainer[i].Where(c => c.Instructors.Contains(trainer)));
            }
            return trainerClasses;
        }

        /// <summary>
        /// Filters the GroupFitnessClassCalendar based on a Customer.
        /// </summary>
        /// <param name="customer">The Customer to filter according to.</param>
        /// <returns>The GroupFitnessClasses of the GroupFitnessClassCalendar which include the Customer.</returns>
        public IEnumerable<GymClass> GetClasses(Customer customer)
        {
            List<GymClass> customerClasses = new List<GymClass>();
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                customerClasses.AddRange(_calendarContainer[i].Where(c => c.BookedParticipants.Contains(customer)));
            }
            return customerClasses;
        }

        /// <summary>
        /// Filters the GroupFitnessClassCalendar for GroupFitnessClasses that overlap in their GroupFitnessLocation as well as Start and End times.
        /// </summary>
        /// <returns>A list of strings detailing the GroupFitnessClasses in conflict.</returns>
        public List<string> GetScheduleConflicts()
        {
            List<string> warningLog = new List<string>();
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                if (_calendarContainer[i].Count > 0)
                {
                    for (int y = 1; y < _calendarContainer[i].Count; y++)
                    {
                        if (_calendarContainer[i][y - 1].DoubleBooking(_calendarContainer[i][y]))
                        {
                            GymClass classOne = _calendarContainer[i][y - 1];
                            GymClass classTwo = _calendarContainer[i][y];
                            warningLog.Add($"Scheduling Conflict: {classOne.Concept.Name} {classOne.Id} {classOne.Start} and {classTwo.Concept.Name} {classTwo.Id} {classTwo.Start}.");
                        }
                    }
                }
            }
            return warningLog;
        }

        public void Clear()
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i].Clear();
            }
        }

        #region PrivateMethods

        private void InsertFitnessClass(GymClass fitnessClass)
        {
            int indexOfClass = GetClassIndex(fitnessClass);
            _calendarContainer[indexOfClass].Add(fitnessClass);
        }

        /// <summary>
        /// ISO 8601 weeks start on Monday. This returns 0 for Monday.
        /// </summary>
        private int GetClassIndex(GymClass fitnessClass)
        {
            return (int)(fitnessClass.Start.DayOfWeek + 6) % 7;
        }

        private void SortCalendarDayAscending(int indexOfDay)
        {
            _calendarContainer[indexOfDay].Sort((c1, c2) => c1.Start.CompareTo(c2.Start));
        }

        private void SortCalendarAscending()
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i].Sort((c1, c2) => c1.Start.CompareTo(c2.Start));
            }
        }

        #endregion

        #region LocalGuardMethods

        private void TestAgainstGuards(GymClass fitnessClass)
        {
            fitnessClass.GuardAgainstNull();
            fitnessClass.GuardAgainstInvalid();
            fitnessClass.GuardAgainstOverbooking();
            GuardAgainstDuplication(fitnessClass);
            GuardAgainstWrongWeek(fitnessClass);
        }

        private void GuardAgainstDuplication(GymClass fitnessClass)
        {
            if (_calendarContainer[GetClassIndex(fitnessClass)].Contains(fitnessClass))
            {
                throw new GroupFitnessClassException($"GroupFitnessClass Id: {fitnessClass.Id}, Concept: {fitnessClass.Concept.Name} is already contained in this collection.");
            }
        }

        private void GuardAgainstWrongWeek(GymClass fitnessClass)
        {
            if (ISOWeek.GetWeekOfYear(fitnessClass.Start) != CalendarWeekNumber)
            {
                throw new GroupFitnessClassException($"GroupFitnessClass Id: {fitnessClass.Id}, Date: {fitnessClass.Start.Date} did not match the specified week number for the calendar.");
            }
        }

        #endregion

        #region Enumerator

        public IEnumerator<GymClass> GetEnumerator()
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                foreach (GymClass fitnessClass in _calendarContainer[i])
                {
                    yield return fitnessClass;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
