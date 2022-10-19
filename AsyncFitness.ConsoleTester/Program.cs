using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Models.Facility;

internal class Program
{
    private static void Main(string[] args)
    {
        var testProgram = new GroupFitnessClassCalendarTests();
        testProgram.Run();
        testProgram.PrintCalendar();
    }
}

// start and end cannot be shorter than concept duration
// ugenummer for visning af array


internal class GroupFitnessClassCalendarTests
{
    private GroupFitnessClassCalendar _calendar;
    private GroupFitnessClass[] _testClasses;
    private GroupFitnessConcept _fitnessConcept;
    private GroupFitnessLocation _fitnessLocation;
    private FitnessCenter _fitnessCenter;

    public GroupFitnessClassCalendarTests()
    {
        Setup();
    }

    public void Run()
    {
        _calendar.AddClassRange(_testClasses);
        _calendar.AddClassRange(_testClasses);
    }

    public void Setup()
    {
        _fitnessCenter = new FitnessCenter { Name = "Viborgvej Centeret" };
        _calendar = new GroupFitnessClassCalendar(_fitnessCenter);
        _fitnessConcept = new GroupFitnessConcept { Name = "TestConcept", Description = "Dette er et test koncept og varer en time.", Duration = new TimeSpan(1, 0, 0) };
        _fitnessLocation = new GroupFitnessLocation { Name = "Holdsal 1", Center = _fitnessCenter, Capacity = 30 };
        _testClasses = new GroupFitnessClass[]
        {
            new GroupFitnessClass{Id = 1,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 4, 20, 0, 0),End = new DateTime(2022, 10, 4, 21, 0, 0)},
            new GroupFitnessClass{Id = 2,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 4, 21, 0, 0),End = new DateTime(2022, 10, 4, 22, 0, 0)},
            new GroupFitnessClass{Id = 3,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 4, 19, 0, 0),End = new DateTime(2022, 10, 4, 20, 0, 0)},
            new GroupFitnessClass{Id = 4,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 5, 20, 0, 0),End = new DateTime(2022, 10, 5, 21, 0, 0)},
            new GroupFitnessClass{Id = 5,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 5, 21, 0, 0),End = new DateTime(2022, 10, 5, 22, 0, 0)},
            new GroupFitnessClass{Id = 6,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 5, 19, 0, 0),End = new DateTime(2022, 10, 5, 20, 0, 0)}
        };


    }

    public void PrintCalendar()
    {
        foreach (GroupFitnessClass fitnessClass in _calendar)
        {
            Console.WriteLine($"Class {fitnessClass.Id}: {fitnessClass.Start} - {fitnessClass.End}");
        }
    }
}