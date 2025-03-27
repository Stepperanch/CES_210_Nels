using System.Diagnostics.Tracing;

public class Year
{
    private List<Month> _months = new List<Month>(); // List of months in the year
    protected int _year; // The year
    protected DateTime _dateTime; // The date time of the year
    private List<List<List<Event>>> _weekEvents = new List<List<List<Event>>>();
    public Year(int year, bool isYear = true)   // Constructor
    {
        _year = year;
        _dateTime = new DateTime(_year, 1, 1);
        if (isYear)
        {
            for (int i = 1; i <= 12; i++)
            {
                _months.Add(new Month(_year, i));
            }
        }
        for (int i = 0; i < 12; i++)
        {
            List<List<Event>> monthEvents = new List<List<Event>>();
            for (int j = 0; j < 5; j++)
            {
                List<Event> weekEvents = new List<Event>();
                for (int k = 0; k < 4; k++)
                {
                    weekEvents.Add(new Event());
                }
                monthEvents.Add(weekEvents);
            }
            _weekEvents.Add(monthEvents);
        }
    }
    public Month GetMonth(int whichMohth)   // Get a month
    {
        return _months[whichMohth - 1];
    }

    public (List<Day> week, List<Event> eventsThisWeek, int newMonthNumber, int newWeekNumber) GetWeek(int monthNumber, int weekNumber)
    {
        List<Event> events = _weekEvents[monthNumber-1][weekNumber-1];
        int daysInMonth = DateTime.DaysInMonth(_year, monthNumber);
        Month month = GetMonth(monthNumber);
        List<Day> week = new List<Day>();
        DateOnly searchDay = new DateOnly(_year, monthNumber, 1);
        if (searchDay.DayOfWeek != DayOfWeek.Monday)
        {
            if (weekNumber == 1 ) // If the first week is not a full week
            {
                if (monthNumber == 1) // If it is jan, just desplay from jan 1st to the first sunday
                {
                    while (searchDay.DayOfWeek != DayOfWeek.Monday)
                    {
                        searchDay = searchDay.AddDays(1);
                    }
                    for (int i = 1; i <= 7 - (int)searchDay.DayOfWeek - 1; i++)
                    {
                        week.Add(month.GetDay(i));
                    }
                    return (week, events, monthNumber, weekNumber);
                }
                return GetWeek(monthNumber - 1, GetMonth(monthNumber - 1).MondaysInMonth()+1); // Get the last week of the previous month
            }
            while (searchDay.DayOfWeek != DayOfWeek.Monday)
            {
                searchDay = searchDay.AddDays(1);
            }
            searchDay = searchDay.AddDays((weekNumber - 2) * 7);
        }  
        else
        {
            searchDay = searchDay.AddDays((weekNumber - 1) * 7);
        }
        int monday = searchDay.Day;
        if (monday + 6 <= daysInMonth)
        {
            for (int i = monday; i < monday + 7; i++)
            {
                week.Add(month.GetDay(i));
            }
        }
        else
        {
            int nextMonthNumber = monthNumber + 1;
            if (nextMonthNumber > 12) // if it is at the end of the year just desplay untill the last day of the year
            {
                for (int i = monday; i < monday + 7; i++)
                {
                    if (i <= daysInMonth)
                    {
                        week.Add(month.GetDay(i));
                    }
                }
            
            }
            else
            {
                Month nextMonth = GetMonth(nextMonthNumber);
                for (int i = monday; i < monday + 7; i++)
                {
                    if (i <= daysInMonth)
                    {
                        week.Add(month.GetDay(i));
                    }
                    else
                    {
                        week.Add(nextMonth.GetDay(i - daysInMonth));
                    }
                }
            }
        }
        return (week, events, monthNumber, weekNumber);
    }

    public void Desplay()
    {
        D.Clear();
        D.Print(_year.ToString());
        int k = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                D.SetCursorPosition(j * 24, i * 16 + 2);
                _months[k].Display();
                k++;
            }
        }
        
    }
}