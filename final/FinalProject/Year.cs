using System.Diagnostics.Tracing;

public class Year
{
    private List<Month> _months = new List<Month>(); // List of months in the year
    protected int _year; // The year
    protected DateTime _dateTime; // The date time of the year
    private List<List<List<Event>>> _weekEvents = new List<List<List<Event>>>();
    protected List<Event> _events = new List<Event>();
    protected string _fundementalIdentifier;
    public Year(int year, bool isYear = true)   // Constructor
    {
        _year = year;
        _dateTime = new DateTime(_year, 1, 1);
        
        if (isYear)
        {
            _fundementalIdentifier = _dateTime.ToString("yyyy");
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
        for (int i = 0; i < 4; i++)
        {
            _events.Add(new Event());
        }
    }
    public int GetYear()
    {
        return _year;
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
    private void Display()
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
        D.Print("Events This Year:");
        for (int i = 0; i < _events.Count; i++)
        {
            Event e = _events[i];
            D.Print((i + 1).ToString() + " " + e.GetEvent().Title);
        }
        D.NL();
    }
    public void Menu()
    {
        Display();
        D.Print("1. View Month");
        D.Print("2. View Events This Year");
        D.Print("3. Return To Main Menu");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();

        if (input == "1")
        {
            // ViewMonth();
            Menu();
        }
        else if (input == "2")
        {
            ViewEvents();
            Menu();
        }
        else if (input == "3")
        {
            D.Clear();
            D.Print("Returning to Main Menu...");
            D.Pause();
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
            Menu();
        }
        return;
    }
    protected virtual void ViewEvents()
    {
        D.Clear();
        D.Print($"Events In {_fundementalIdentifier}:");
        for (int i = 0; i < _events.Count; i++)
        {
            Event e = _events[i];
            D.Print((i + 1).ToString() + " " + e.GetEvent().Title);
        }
        D.NL();
        D.Print("1. Add Event");
        D.Print("2. Edit Event");
        D.Print("3. Delete Event");
        D.Print("4. Return to Year Menu");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();

        if (input == "1")
        {
            AddEvent();
            ViewEvents();
        }
        else if (input == "2")
        {
            // EditEvent();
            ViewEvents();
        }
        else if (input == "3")
        {
            // DeleteEvent();
            ViewEvents();
        }
        else if (input == "4")
        {
            Menu();
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
            ViewEvents();
        }
    }
    public void AddEvent()
    {
        foreach (Event e in _events)
        {
            if (e.GetEvent().Title == "-")
            {
                D.Clear();
                e.CreateEvent();
                D.Print("Event Created!");
                return;
            } 
        }
        D.Print("You cannot have more than 4 events, Please Edit or Delete an event");
        D.Pause();
        ViewEvents();
    } 
}