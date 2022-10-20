﻿using AsyncFitness.Core.Datastructures;
using AsyncFitness.Core.Extensions;
using AsyncFitness.Core.Models.Facility;
using System.Globalization;

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
// tests for double booking

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
        var conflicts = _calendar.GetScheduleConflicts();
        foreach (var conflict in conflicts)
        {
            Console.WriteLine(conflict);
        }
        var testByConcept = _calendar.GetClasses(_fitnessConcept);
        var testByLocation = _calendar.GetClasses(_fitnessLocation);
    }

    public void Setup()
    {
        _fitnessCenter = new FitnessCenter { Name = "Viborgvej Centeret" };
        _calendar = new GroupFitnessClassCalendar(new DateTime(2022, 10, 4, 20, 0, 0));
        _fitnessConcept = new GroupFitnessConcept { Name = "TestConcept", Description = "Dette er et test koncept og varer en time.", Duration = new TimeSpan(1, 0, 0) };
        _fitnessLocation = new GroupFitnessLocation { Name = "Holdsal 1", Center = _fitnessCenter, Capacity = 30 };
        _testClasses = new GroupFitnessClass[]
        {
            new GroupFitnessClass{Id = 1,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 4, 20, 0, 0),End = new DateTime(2022, 10, 4, 21, 0, 0)},
            new GroupFitnessClass{Id = 2,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 4, 21, 0, 0),End = new DateTime(2022, 10, 4, 22, 0, 0)},
            new GroupFitnessClass{Id = 3,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 4, 19, 0, 0),End = new DateTime(2022, 10, 4, 20, 0, 0)},
            new GroupFitnessClass{Id = 4,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 5, 20, 0, 0),End = new DateTime(2022, 10, 5, 21, 0, 0)},
            new GroupFitnessClass{Id = 5,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 5, 21, 0, 0),End = new DateTime(2022, 10, 5, 22, 0, 0)},
            new GroupFitnessClass{Id = 6,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 5, 19, 0, 0),End = new DateTime(2022, 10, 5, 20, 0, 0)},
            new GroupFitnessClass{Id = 7,Concept = _fitnessConcept,Location = _fitnessLocation,Start = new DateTime(2022, 10, 5, 19, 30, 0),End = new DateTime(2022, 10, 5, 20, 30, 0)}
        };

        var testOne = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 19, 0, 0), End = new DateTime(2022, 10, 4, 20, 0, 0) };
        var testTwo = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 20, 0, 0), End = new DateTime(2022, 10, 4, 21, 0, 0) };
        var falseOne = testOne.DoubleBooking(testTwo);

        testOne = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 19, 0, 0), End = new DateTime(2022, 10, 4, 20, 0, 0) };
        testTwo = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 19, 30, 0), End = new DateTime(2022, 10, 4, 20, 30, 0) };
        var TrueOne = testOne.DoubleBooking(testTwo);

        testOne = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 19, 0, 0), End = new DateTime(2022, 10, 4, 20, 0, 0) };
        testTwo = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 18, 30, 0), End = new DateTime(2022, 10, 4, 19, 30, 0) };
        var TrueTwo = testOne.DoubleBooking(testTwo);

        testOne = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 19, 0, 0), End = new DateTime(2022, 10, 4, 20, 0, 0) };
        testTwo = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 20, 00, 0), End = new DateTime(2022, 10, 4, 21, 00, 0) };
        var falseTwo = testTwo.DoubleBooking(testOne);

        testOne = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 19, 0, 0), End = new DateTime(2022, 10, 4, 20, 0, 0) };
        testTwo = new GroupFitnessClass { Id = 3, Concept = _fitnessConcept, Location = _fitnessLocation, Start = new DateTime(2022, 10, 4, 18, 30, 0), End = new DateTime(2022, 10, 4, 19, 30, 0) };
        var trueThree = testTwo.DoubleBooking(testOne);
    }

    public void PrintCalendar()
    {
        foreach (GroupFitnessClass fitnessClass in _calendar)
        {
            Console.WriteLine($"Class {fitnessClass.Id}: {fitnessClass.Start} - {fitnessClass.End}");
        }
    }
}