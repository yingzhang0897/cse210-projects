using System;

class Program
{
    static void Main(string[] args)
    {
        //base class
        Assignment assignment = new Assignment("Samuel", "multiplication");
        Console.WriteLine(assignment.GetSummary());
        //derived class: MathAssignment
        MathAssignment mathAssignment = new MathAssignment("Samuel", "fraction", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHwkList());
        //derived class: WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("Samuel", "religious freedom", "Restoration of Gospel");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInfo());


    }
}