using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;

public class Year
{
    private List<Month> _months = new List<Month>(); // List of months in the year
    protected int _year; // The year
    protected DateTime _dateTime; // The date time of the year
    private List<List<List<Event>>> _weekEvents = new List<List<List<Event>>>();
    protected List<Event> _events = new List<Event>();
    protected string _fundementalIdentifier;
    public List<Event> Events // Just experimenting with properties i understand that this is not the best practice
    {
        get { return _events; }
        set { _events = value; }
    }
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
    public List<Month> GetAllMonths()   // Get all months
    {
        return _months;
    }
    public Month GetMonth(int whichMohth)   // Get a month
    {
        return _months[whichMohth - 1];
    }
    public (List<Day> week, int newMonthNumber, int newWeekNumber) GetWeek(int monthNumber, int weekNumber)
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
                    while (searchDay.DayOfWeek != DayOfWeek.Sunday)
                    {
                        searchDay = searchDay.AddDays(1);
                    }
                    for (int i = 1; i <= 7 - (int)searchDay.DayOfWeek - 1; i++)
                    {
                        week.Add(month.GetDay(i));
                    }
                    return (week, monthNumber, weekNumber);
                }
                return GetWeek(monthNumber - 1, GetMonth(monthNumber - 1).MondaysInMonth()+1); // Get the last week of the previous month
            }
            while (searchDay.DayOfWeek != DayOfWeek.Sunday)
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
        return (week, monthNumber, weekNumber);
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
        D.NL();
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
            ViewMonth();
        }
        else if (input == "2")
        {
            ViewEvents();
        }
        else if (input == "3")
        {
            D.Clear();
            D.Print("Returning to Main Menu...");
            D.Pause(200);
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        Menu();
    }
    private void AcessMonth(int choice)
    {
        (int monthNumebr, int weekNumber) = _months[choice - 1].Menu();
        if (monthNumebr != 0 || weekNumber != 0)
        {
            WeekMenu(monthNumebr, weekNumber);
            AcessMonth(monthNumebr);
        }
    }
    protected void ViewMonth()
    {
        D.NL();
        D.Print($"Please select a month to view:");
        D.Print($"Select {_months.Count + 1} to go back.");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int choice) && choice > 0 && choice <= _months.Count)
        {
            AcessMonth(choice);
            return;
        }
        else if (input == (_months.Count + 1).ToString())
        {
            D.Clear();
            D.Print("Returning to Year Menu...");
            D.Pause(200);
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        ViewMonth();
    }
    protected virtual void ViewEvents()
    {
        D.Clear();
        D.Print($"Events In {_fundementalIdentifier}:");
        for (int i = 0; i < _events.Count; i++)
        {
            Event e = _events[i];
            D.Print((i + 1).ToString());
            e.DisplayEvent();
            D.NL();
        }
        D.NL();
        D.Print("1. Add Event");
        D.Print("2. Edit Event");
        D.Print("3. Delete Event");
        D.Print("4. Return to Menu");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();

        if (input == "1")
        {
            AddEvent();
        }
        else if (input == "2")
        {
            EditEvent();
        }
        else if (input == "3")
        {
            DeleteEvent();
        }
        else if (input == "4")
        {
            D.Clear();
            D.Print("Returning to Menu...");
            D.Pause(200);
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        ViewEvents();
    }
    protected virtual void AddEvent()
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
    protected virtual void EditEvent(Event e = null)
    {
        D.Clear();
        if (e != null)
        {
            e.EditEvent();
            D.Print("Event Edited!");
            D.Pause();
            return;
        }
        D.Clear();
        D.Print("Select an event to edit:\n");
        int tempvalue = 0;
        for (int i = 0; i < _events.Count; i++)
        {
            e = _events[i];
            if (e.GetEvent().Title != "-")
            {
                D.Print("Event " + (i + 1).ToString());
                e.DisplayEvent();
                D.NL();
            }
            tempvalue = i+2;
        }
        D.Print($"{tempvalue}. Return to Year Menu");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();
        if (input == (tempvalue).ToString())
        {
            D.Clear();
            D.Print("Returning to Year Menu...");
            D.Pause(200);
            return;
        }
        if (int.TryParse(input, out int choice) && choice > 0 && choice <= _events.Count)
        {
            _events[choice - 1].EditEvent();
            D.Print("Event Edited!");
            D.Pause();
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        EditEvent();
    }
    protected virtual void DeleteEvent()
    {
        D.Clear();
        D.Print("Select an event to delete:\n");
        int tempvalue = 0;
        for (int i = 0; i < _events.Count; i++)
        {
            Event e = _events[i];
            if (e.GetEvent().Title != "-")
            {
                D.Print("Event " + (i + 1).ToString());
                e.DisplayEvent();
                D.NL();
            }
            tempvalue = i+2;
        }
        D.Print($"{tempvalue}. Return to Year Menu");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();
        if (input == (tempvalue).ToString())
        {
            D.Clear();
            D.Print("Returning to Year Menu...");
            D.Pause(200);
            return;
        }
        if (int.TryParse(input, out int choice) && choice > 0 && choice <= _events.Count)
        {
            _events[choice - 1].DeleteEvent();
            D.Print("Event Deleted!");
            D.Pause();
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        DeleteEvent();
    }
    public void WeekMenu(int monthNumber, int weekNumber)
    {
        (List<Day> week, monthNumber, weekNumber) = GetWeek(monthNumber, weekNumber);
        D.Clear();
        int x = 9;
        int y = 0;
        foreach (Day day in week)
        {
            if (day == week[0])
            {
                day.DisplayIn((x, y), true);
            }
            else
            {
                day.DisplayIn((x, y));
            }
            x += 23;
        }
        D.NL(2);
        D.Print("Events This Week:");
        foreach (Event e in _weekEvents[monthNumber - 1][weekNumber - 1])
        {
            D.Print(e.GetEvent().Title);
        }
        D.NL();
        D.Print("1. View Events");
        D.Print("2. Return to Month Menu");
        D.Print("3. Acess days (from the month menu)");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();
        if (input == "1")
        {
            List<Event> tempEvents = _events;
            _events = _weekEvents[monthNumber - 1][weekNumber - 1];
            ViewEvents();
            _weekEvents[monthNumber - 1][weekNumber - 1] = _events;
            _events = tempEvents;
        }
        else if (input == "2" || input == "3")
        {
            D.Clear();
            D.Print("Returning to Month Menu...");
            D.Pause(200);
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        WeekMenu(monthNumber, weekNumber);
    }
}