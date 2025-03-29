// using System.Diagnostics.Tracing;

// public class Week 
// {    
//     public static void Display(Year year, int monthNumber, int weekNumber)
//     {
//         var (week, events, newmonthNumber, newweekNumber) = year.GetWeek(monthNumber, weekNumber);
//         D.Clear();
//         foreach (Day day in week)
//         {
//             if (day == week[0])
//             {
//                 day.DisplayIn(true);
//             }
//             else
//             {
//                 day.DisplayIn();
//             }
//         }
//         D.NL();
//         D.Print("Events This Week:");
//         foreach (Event e in events)
//         {
//             D.Print(e.GetEvent().Title);
//         }
//     }
//     (List<Day> week, List<Event> events, int start, int end) = year2025.GetWeek(11, 1);
//     int x = 9;
//     int y = 0;
//     foreach (Day day in week)
//     {
//         if (day == week[0])
//         {
//             day.DisplayIn((x, y), true);
//         }
//         else
//         {
//             day.DisplayIn((x, y));
//         }
//         x += 23;
//     }
// }