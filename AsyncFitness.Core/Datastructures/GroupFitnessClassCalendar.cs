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
    public class GroupFitnessClassCalendar : IEnumerable<GroupFitnessClass>
    {
        private List<GroupFitnessClass>[] _calendarContainer;
        public int WeekNumber { get; }

        public GroupFitnessClassCalendar(int weekNumber)
        {
            WeekNumber = weekNumber;
            _calendarContainer = new List<GroupFitnessClass>[7];
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i] = new List<GroupFitnessClass>();
            }
        }

        public void AddClass(GroupFitnessClass fitnessClass)
        {
            TestAgainstGuards(fitnessClass);
            InsertFitnessClass(fitnessClass);
            SortCalendarDayAscending(GetClassIndex(fitnessClass));
        }

        public void AddClassRange(IQueryable<GroupFitnessClass> fitnessClasses)
        {
            fitnessClasses.GuardAgainstNull();

            foreach (GroupFitnessClass fitnessClass in fitnessClasses)
            {
                TestAgainstGuards(fitnessClass);
                InsertFitnessClass(fitnessClass);
            }

            SortCalendarAscending();
        }

        public void RemoveClass(GroupFitnessClass fitnessClass)
        {
            int indexOfClass = GetClassIndex(fitnessClass);
            _calendarContainer[indexOfClass].Remove(fitnessClass);
        }

        public IEnumerable<GroupFitnessClass> GetClassesByLocation(GroupFitnessLocation fitnessLocation)
        {
            List<GroupFitnessClass> locationClasses = new List<GroupFitnessClass>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                locationClasses.AddRange(_calendarContainer[i].Where(c => c.Location == fitnessLocation));
            }

            return locationClasses;
        }

        public IEnumerable<GroupFitnessClass> GetClassesByConcept(GroupFitnessConcept concept)
        {
            List<GroupFitnessClass> conceptClasses = new List<GroupFitnessClass>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                conceptClasses.AddRange(_calendarContainer[i].Where(c => c.Concept == concept));
            }

            return conceptClasses;
        }

        public IEnumerable<GroupFitnessClass> GetClassesByTrainer(Trainer trainer)
        {
            List<GroupFitnessClass> trainerClasses = new List<GroupFitnessClass>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                trainerClasses.AddRange(_calendarContainer[i].Where(c => c.Instructors.Contains(trainer)));
            }

            return trainerClasses;
        }

        public IEnumerable<GroupFitnessClass> GetClassesByParticipant(Customer customer)
        {
            List<GroupFitnessClass> customerClasses = new List<GroupFitnessClass>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                customerClasses.AddRange(_calendarContainer[i].Where(c => c.BookedParticipants.Contains(customer)));
            }

            return customerClasses;
        }

        public List<string> GetScheduleConflicts()
        {
            List<string> errorLog = new List<string>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                for (int y = 1; y == _calendarContainer[i].Count; y++)
                {

                }
            }

            return errorLog;
        }

        public void Clear()
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i].Clear();
            }
        }

        #region PrivateMethods

        private void InsertFitnessClass(GroupFitnessClass fitnessClass)
        {
            int indexOfClass = GetClassIndex(fitnessClass);
            _calendarContainer[indexOfClass].Add(fitnessClass);
        }

        private int GetClassIndex(GroupFitnessClass fitnessClass)
        {
            return (int)fitnessClass.Start.DayOfWeek;
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

        private void TestAgainstGuards(GroupFitnessClass fitnessClass)
        {
            fitnessClass.GuardAgainstNull();
            fitnessClass.GuardAgainstInvalid();
            GuardAgainstDuplication(fitnessClass);
            GuardAgainstWrongWeek(fitnessClass);
        }

        private void GuardAgainstDuplication(GroupFitnessClass fitnessClass)
        {
            if (_calendarContainer[GetClassIndex(fitnessClass)].Contains(fitnessClass))
            {
                throw new GroupFitnessClassException($"GroupFitnessClass Id: {fitnessClass.Id}, Concept: {fitnessClass.Concept.Name} is already contained in this collection.");
            }
        }

        private void GuardAgainstWrongWeek(GroupFitnessClass fitnessClass)
        {
            if (ISOWeek.GetWeekOfYear(fitnessClass.Start) != WeekNumber)
            {
                throw new GroupFitnessClassException($"GroupFitnessClass Id: {fitnessClass.Id}, Date: {fitnessClass.Start.Date} did not match the specified week number for the calendar.");
            }
        }

        #endregion

        #region Enumerator

        public IEnumerator<GroupFitnessClass> GetEnumerator()
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                foreach (GroupFitnessClass fitnessClass in _calendarContainer[i])
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
