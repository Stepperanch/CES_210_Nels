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
        D.Print(searchDay.ToString());
        D.Print(searchDay.DayOfWeek.ToString());
        D.Print(searchDay.Day.ToString());
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
        D.Print("| " + _dateTime.ToString("MMMM").PadRight(19) + "| ", false);
        D.SetCursorPosition(x, y+line);
        line++;
        D.Print("|Su|Mo|Tu|We|Th|Fr|Sa|", false);
        D.SetCursorPosition(x, y+line);
        line++;
        int firstDayValue = ((int)_dateTime.DayOfWeek + 6) % 7 + 1;
        for (int i = 1; i <= firstDayValue; i++)
        {
            D.Print("|  ", false);
        }
        int daynum = 1;
        int inum = 0;
        for (int i = firstDayValue; i <= DateTime.DaysInMonth(_year, _month) + firstDayValue - 1; i++)
        {
            inum = i;
            if (i % 7 == 0 )
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
    public void DisplayLarge()
    {
        D.Clear();
        D.Print("     " + _dateTime.ToString("MMMM"));
        D.Print("");
        //       | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 | 12345678900987654321 |
        D.Print("|        Monday        |        Tuesday       |       Wednesday      |       Thursday       |        Friday        |        Saturday      |         Sunday       |");
        var (x, y) = D.GetCursorPosition();
        D.SetCursorPosition(x, y+1);
        int firstDayValue = ((int)_dateTime.DayOfWeek + 6) % 7 + 1;
        for (int i = 1; i <= firstDayValue; i++)
        {
            D.Print("|                     |", false);
        }
               

    }
}