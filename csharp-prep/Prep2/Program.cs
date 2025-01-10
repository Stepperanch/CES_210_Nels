using System;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write("What Grade did you get? ");
        int grade = int.Parse(Console.ReadLine());
        string letterGrade = "F";
        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        
        if (grade > 95)
        {
            letterGrade = "A";
        }
        else if (grade < 60)
        {
            letterGrade = "F";
        }
        else if (grade % 10 >= 7)
        {
            letterGrade += "+";
        }
        else if (grade % 10 <= 3)
        {
            letterGrade += "-";
        }

        Console.WriteLine($"You got a {letterGrade}");

        if (grade >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("You failed!");
        }
// add plus or minus
        

    }
}