using System.ComponentModel;
using System.Dynamic;
using System.Security.Cryptography;

public class Month : Year
{
    private List<Day> _days = new List<Day>();
    protected int _month;
    public Month( int year, int month, bool isMonth = true) : base(year, false)
    {
        _month = month;
        _dateTime = new DateTime(_year, _month, 1);
        if (isMonth)
        {
            _fundementalIdentifier = _dateTime.ToString("MMMM-yyyy");
            for (int i = 1; i <= DateTime.DaysInMonth(_year, _month); i++)
            {
                _days.Add(new Day(_year, _month, i));
            }
        }
    }

    public Day GetDay(int day)
    {
        return _days[day - 1];
    }
    public string GetMonthName()
    {
        return _dateTime.ToString("MMMM");
    }
    public int GetMonth()
    {
        return _month;
    }
    public List<Day> GetAllDays()
    {
        return _days;
    }
    public int MondaysInMonth()
    {
        int daysLeftInMonth = DateTime.DaysInMonth(_year, _month)-1;
        DateOnly searchDay = new DateOnly(_year, _month, 1);
        while (searchDay.DayOfWeek != DayOfWeek.Monday)
        {
            searchDay = searchDay.AddDays(1);
            daysLeftInMonth--;
        }
        int mondays = 1;
        for (int i = 1; i <= daysLeftInMonth; i++)
        {
            searchDay = searchDay.AddDays(1);
            if (searchDay.DayOfWeek == DayOfWeek.Monday)
            {
                mondays++;
            }
        }
        return mondays;
    }
    public int FindFirstMonday()
    {
        DateOnly searchDay = new DateOnly(_year, _month, 1);
        while (searchDay.DayOfWeek != DayOfWeek.Monday)
        {
            searchDay = searchDay.AddDays(1);
        }
        return searchDay.Day;
    }
    public void Display() // it is 22 char wide and 13 lines high
    {
        var (x, y) = D.GetCursorPosition();
        int line = 1;
        D.Print("| " + _dateTime.ToString("MM").PadLeft(2) + " " + _dateTime.ToString("MMMM").PadRight(16) + "| ", false);
        D.SetCursorPosition(x, y+line);
        line++;
        D.Print("|Su|Mo|Tu|We|Th|Fr|Sa|", false);
        D.SetCursorPosition(x, y+line);
        line++;
        int firstDayValue = (int)_dateTime.DayOfWeek;
        for (int i = 1; i <= firstDayValue; i++)
        {
            D.Print("|  ", false);
        }
        int daynum = 1;
        int inum = 0;
        for (int i = firstDayValue; i <= DateTime.DaysInMonth(_year, _month) + firstDayValue - 1; i++)
        {
            inum = i;
            if (i % 7 == 0 && i != 0)
            {
                D.Print("| ", false);
                D.SetCursorPosition(x, y+line);
                line++;
            } 
            D.Print("|"+daynum.ToString().PadLeft(2), false);
            daynum++;
        }
        inum++;
        while (inum % 7 > 0)
        {
            D.Print("|  ", false);
            inum++;
        }
        D.Print("|", false);
        D.SetCursorPosition(x, y+line);
        line++;
        D.Print("|Events This Month".PadRight(21)+"|", false);
        D.SetCursorPosition(x, y+line);
        line++;
        for (int i = 0; i < _events.Count; i++)
        {
            Event e = _events[i];
            D.Print("|"+ (i+1).ToString() + " " + e.GetEvent().Title.PadRight(18)+"|", false);
            D.SetCursorPosition(x, y+line);
            line++;
        }
        
    }
    private void DisplayLarge()
    {
        D.Clear();
        D.Print("     " + _dateTime.ToString("MMMM - yyyy"));
        D.Print("");
        //       | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 |
        D.Print("|        Sunday        |        Monday        |        Tuesday       |       Wednesday      |       Thursday       |        Friday        |        Saturday      |");
        var (x, y) = D.GetCursorPosition();
        y++;
        D.SetCursorPosition(x, y);
        int firstDayValue = (int)_dateTime.DayOfWeek;
        int datecounter = - firstDayValue;
        int otherCounter = 0;
        for (int i = 1; i < (int)DateTime.DaysInMonth(_year, _month) + firstDayValue + 1; i++)
        {
            var (varx, vary) = (x + otherCounter, y);
            otherCounter = otherCounter + 23;
            if (datecounter < 0)
            {
                for (int j = 0; j < _events.Count + 2; j++)
                {
                    D.SetCursorPosition(varx, vary);
                    D.Print("|                      ", false);
                    vary++;
                }
            }
            else
            {
                List<Event> eventsToday = _days[datecounter].Events;
                D.SetCursorPosition(varx, vary);
                D.Print("|          " + (datecounter+1).ToString().PadLeft(2) + "          |", false);
                vary++;
                D.SetCursorPosition(varx, vary);
                //       | 12345678900987654321 |
                D.Print("|     Events Today     |", false);
                vary++;
                for (int j = 0; j < eventsToday.Count; j++)
                {
                    D.SetCursorPosition(varx, vary);
                    Event e = eventsToday[j];
                    string eventTitle = e.GetEvent().Title;
                    string formattedTitle = eventTitle.Length > 20 ? eventTitle.Substring(0, 20) : eventTitle.PadRight(20);
                    D.Print("| " + formattedTitle + " |", false);
                    vary++;
                }
            }
            datecounter++;
            if ((i)% 7 == 0 && datecounter > 0)
            {
                y = y + 7;
                D.SetCursorPosition(x, y);
                otherCounter = 0;
            }
        }
        D.NL(2); //New Line
        D.Print("Events This Month");
        for (int i = 0; i < _events.Count; i++)
        {
            Event e = _events[i];
            D.Print((i+1).ToString() + " " + e.GetEvent().Title);
        }
        D.NL();
    }
    public new (int monthNumber, int weeknumber) Menu()
    {
        DisplayLarge();
        D.Print("1. View Week (Not Implemented)");
        D.Print("2. View Day");
        D.Print("3. View Events This Month");
        D.Print("4. Return To Year");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();
        if (input == "1")
        {
            (int monthNumber, int weeknumber) = ViewWeek();
            if (monthNumber != 0 || weeknumber != 0)
            {
                return (monthNumber, weeknumber);
            }
        }
        else if (input == "2")
        {
            ViewDay();
        }
        else if (input == "3")
        {
            ViewEvents();
        }
        else if (input == "4")
        {
            return (0, 0);
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        Menu();
        return (0, 0);
    }
    private void ViewDay(string day = "")
    {
        if (day == "")
        {
            D.Print("Select a day to view: ");
            D.Print($"Selecct 0 to return to the month menu");
            day = D.Read();
        }
        if (int.TryParse(day, out int dayNum) && dayNum > 0 && dayNum <= DateTime.DaysInMonth(_year, _month))
        {
            _days[dayNum - 1].Menu();
            return;
        }
        else if (day == "0")
        {
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        ViewDay();
    }
    private (int monthNumber, int weekNumber) ViewWeek()
    {
        D.Print("Select a week to view (First week is line one, second is line two, etc.): ");
        D.Print($"Select 0 to return to the month menu");
        string week = D.Read();
        if (int.TryParse(week, out int weekNum) && weekNum > 0 && weekNum <= 5)
        {
            return (_month, weekNum);
        }
        else if (week == "0")
        {
            return (0, 0);
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        ViewWeek();
        return (0, 0);
    }
}