using System;

class Program
{
    static void Main(string[] args)
    {
        // List<Day> days = new List<Day>();
        // for (int i = 0; i < 7 ; i++)
        // {
        //     days.Add(new Day(27, 12, 2021).AddDays(i));
        // }
        // D.Clear();
        // foreach (Day day in days)
        // {
        //     if (day == days[0])
        //     {
        //         day.DisplayIn(true);
        //     }
        //     else
        //     {
        //         day.DisplayIn();
        //     }
        // }

        // // september 2025
        // Month september = new Month(2026, 4);
        // Console.WriteLine(september.MondaysInMonth());

        
        // Week.Display(year2025, 11, 1);
        // Console.ReadKey();
        // Week.Display(year2025, 11, 2);
        // Console.ReadKey();
        // Week.Display(year2025, 11, 3);
        // Console.ReadKey();
        // Week.Display(year2025, 11, 4);
        // Console.ReadKey();
        // Week.Display(year2025, 11, 5);
        // Console.ReadKey();
        // D.Clear();
        // List<Year> years = new List<Year>();
        // for (int i = 1; i < 20; i++)
        // {
        //     years.Add(new Year(i));
        // }
        // foreach (Year year in years)
        // {

        //     year.Desplay();
        //     D.Print("");
        //     D.Pause(1000);
        // }

        D.Print("Welcome to the Calendar App!");
        D.Print("Please make sure that the window is as large as it can go");
        D.Pause();
        D.Clear();

        Calender calender = new Calender();
        Year year2025 = new Year(2025);
        (List<Day> week, List<Event> events, int start, int end) = year2025.GetWeek(11, 1);
        foreach (Day day in week)
        {
            if (day == week[0])
            {
                day.DisplayIn(true);
            }
            else
            {
                day.DisplayIn();
            }
        }
        
        
    }

}