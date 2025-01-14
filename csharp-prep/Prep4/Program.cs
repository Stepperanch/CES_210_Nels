using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        while (true)
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                break;
            }
            numbers.Add(number);
        }

        numbers.Sort();
        int sum = numbers.Sum();
        double average = numbers.Average();
        int min = numbers.Min();
        int max = numbers.Max();
        int smallestpositive = numbers.Where(n => n > 0).Min();
        
        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The min is {min}");
        Console.WriteLine($"The max is {max}");
        Console.WriteLine($"The smallest positive number is {smallestpositive}");
        Console.WriteLine("The numbers in order are:" + string.Join(", ", numbers));
    }
}