using AsyncFitness.Core.Exceptions;
using AsyncFitness.Core.Models.Facility;
using AsyncFitness.Core.Models.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFitness.Core.Datastructures
{
    public class GroupFitnessClassCalendar : IEnumerable<GroupFitnessClass>
    {
        private List<GroupFitnessClass>[] _calendarContainer;

        public FitnessCenter Center { get; private set; }

        public GroupFitnessClassCalendar(FitnessCenter fitnessCenter)
        {
            Center = fitnessCenter;
            _calendarContainer = new List<GroupFitnessClass>[7];
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                _calendarContainer[i] = new List<GroupFitnessClass>();
            }
        }

        public void AddClass(GroupFitnessClass fitnessClass)
        {
            GuardAgainstNull(fitnessClass);
            GuardAgainstInvalid(fitnessClass);
            GuardAgainstDuplication(fitnessClass);

            InsertFitnessClass(fitnessClass);
            SortCalendarDayAscending(GetClassIndex(fitnessClass));
        }

        public void AddClassRange(IEnumerable<GroupFitnessClass> fitnessClasses)
        {
            GuardAgainstNullCollection(fitnessClasses);
            GuardAgainstInvalidCollection(fitnessClasses);

            foreach (GroupFitnessClass fitnessClass in fitnessClasses)
            {
                GuardAgainstDuplication(fitnessClass);
                InsertFitnessClass(fitnessClass);
            }

            SortCalendarAscending();
        }

        public void RemoveClass(GroupFitnessClass fitnessClass)
        {
            int indexOfClass = GetClassIndex(fitnessClass);
            _calendarContainer[indexOfClass].Remove(fitnessClass);
        }

        public void RemoveClass(int id)
        {
            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                for (int y = 1; y == _calendarContainer[i].Count; y++)
                {
                    if (_calendarContainer[i][y].Id == id)
                    {
                        _calendarContainer[i].RemoveAt(y);
                        break;
                    }
                }
            }
        }

        public List<GroupFitnessClass> GetClassesByLocation(GroupFitnessLocation fitnessLocation)
        {
            List<GroupFitnessClass> conceptClasses = new List<GroupFitnessClass>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                conceptClasses.AddRange(_calendarContainer[i].Where(c => c.Location == fitnessLocation));
            }

            return conceptClasses;
        }

        public List<GroupFitnessClass> GetClassesByConcept(GroupFitnessConcept concept)
        {
            List<GroupFitnessClass> conceptClasses = new List<GroupFitnessClass>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                conceptClasses.AddRange(_calendarContainer[i].Where(c => c.Concept == concept));
            }

            return conceptClasses;
        }

        public List<GroupFitnessClass> GetClassesByTrainer(Trainer trainer)
        {
            List<GroupFitnessClass> conceptClasses = new List<GroupFitnessClass>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                conceptClasses.AddRange(_calendarContainer[i].Where(c => c.Instructors.Contains(trainer)));
            }

            return conceptClasses;
        }

        public List<GroupFitnessClass> GetClassesByParticipant(Customer customer)
        {
            List<GroupFitnessClass> conceptClasses = new List<GroupFitnessClass>();

            for (int i = 0; i < _calendarContainer.Length; i++)
            {
                conceptClasses.AddRange(_calendarContainer[i].Where(c => c.BookedParticipants.Contains(customer)));
            }

            return conceptClasses;
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

        #region GuardMethods

        private void GuardAgainstNullCollection(IEnumerable<GroupFitnessClass> fitnessClasses)
        {
            if (fitnessClasses == null)
            {
                throw new GroupFitnessClassException("GroupFitnessClass-collection cannot be null");
            }
        }

        private void GuardAgainstInvalidCollection(IEnumerable<GroupFitnessClass> fitnessClasses)
        {
            foreach (GroupFitnessClass fitnessClass in fitnessClasses)
            {
                GuardAgainstNull(fitnessClass);
            }
        }

        private void GuardAgainstNull(GroupFitnessClass fitnessClass)
        {
            if (fitnessClass == null)
            {
                throw new GroupFitnessClassException("GroupFitnessClass cannot be null.");
            }
        }

        private void GuardAgainstInvalid(GroupFitnessClass fitnessClass)
        {
            if (!fitnessClass.IsValid())
            {
                throw new GroupFitnessClassException($"GroupFitnessClass ID:{fitnessClass.Id} did not pass internal class validity test.");
            }
        }

        private void GuardAgainstDuplication(GroupFitnessClass fitnessClass)
        {
            if (_calendarContainer[GetClassIndex(fitnessClass)].Contains(fitnessClass))
            {
                throw new GroupFitnessClassException($"GroupFitnessClass Id: {fitnessClass.Id}, Concept: {fitnessClass.Concept.Name} is already contained in this collection.");
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
