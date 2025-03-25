using System;

class Program
{
    static void Main(string[] args)
    {
        List<Day> days = new List<Day>();
        for (int i = 0; i < 7 ; i++)
        {
            days.Add(new Day(27, 12, 2021).AddDays(i));
        }
        D.Clear();
        foreach (Day day in days)
        {
            if (day == days[0])
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