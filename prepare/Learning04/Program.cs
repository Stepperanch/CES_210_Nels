using System;

class Program
{
    static void Main(string[] args)
    {
        Assingment assingment = new Assingment("Peter Smith", "History");
        MathAssignment mathAssignment = new MathAssignment("John Doe", "Algebra", "Chapter 3", "Exercises 1-10");
        WritingAssignment writingAssignment = new WritingAssignment("Jane Smith", "The Great Gatsby", "Character Analysis");

        Console.WriteLine();
        Console.Clear();
        Console.WriteLine(assingment.GetSummary());

        Console.WriteLine();
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        Console.WriteLine();
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
        Console.Write("\b \b");
    }
}