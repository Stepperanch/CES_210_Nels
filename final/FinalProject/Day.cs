public class Day : Month
{
    List<Event> _events = new List<Event>();
    List<Event> _dayEvents = new List<Event>();
    private int _day;
    public Day(int year, int month, int day) : base(year, month, false)
    {
        _day = day;
        _dateTime = new DateTime(_year, _month, _day);
        for (int i = 0; i < 34; i++)
        {
            _events.Add(new Event());
        }
    }
    public new void Display()
    {
        D.Print(_dateTime.ToString("dddd, MMMM dd, yyyy"));
        D.NL();
        for (int i = 0; i < _events.Count; i++)
        {
            TimeOnly time = new TimeOnly(6, 0).AddMinutes(i * 30);
            Event e = _events[i];
            D.Print(((i+1).ToString() + ".").PadRight(4) + time.ToString().PadRight(8) + " - " + e.GetEvent().Title);
        }
        D.NL();
        for (int i = 0; i < _dayEvents.Count; i++)
        {
            Event e = _dayEvents[i];
            D.Print((i + 1).ToString() + " " + e.GetEvent().Title);
        }
    }
    public void DisplayIn(bool first = false)
    {
        if (first)
        {
            D.Clear();
            D.Print("         | " + _dateTime.ToString("MMMM"));
            D.Print("         | ");
            var (x , y) = D.GetCursorPosition();
            D.Print("         | " + _dateTime.Day.ToString().PadRight(3) + _dateTime.ToString("dddd").PadRight(17) + " | ");
            for (int i = 0; i < _events.Count; i++)
            {
                if (i != 0)
                { 
                    (x, y) = D.GetCursorPosition();
                    D.SetCursorPosition(x-34, y+1);
                }
                TimeOnly time = new TimeOnly(6, 0).AddMinutes(i * 30);
                Event e = _events[i];
                string eventTitle = e.GetEvent().Title;
                string formattedTitle = eventTitle.Length > 20 ? eventTitle.Substring(0, 20) : eventTitle.PadRight(20);
                D.Print(time.ToString().PadRight(8) + " | " + formattedTitle + " | ", false);
            }
            for (int i = 0; i < _dayEvents.Count; i++)
            {

            }
            
        }
        else
        {
            var (x , y) = D.GetCursorPosition();
            if (_dateTime.Day == 1)
            {
                D.SetCursorPosition(x-2, y-36);
                D.Print("| " + _dateTime.ToString("MMMM"));
                D.SetCursorPosition(x-2, y-35);
                D.Print("| ");
            }
            D.SetCursorPosition(x, y-34);
            D.Print(_dateTime.Day.ToString().PadRight(3) + _dateTime.ToString("dddd").PadRight(17) + " | ", false);
        
            for (int i = 0; i < _events.Count; i++)
            {
                (x, y) = D.GetCursorPosition();
                D.SetCursorPosition(x-23, y+1);
                Event e = _events[i];
                string eventTitle = e.GetEvent().Title;
                string formattedTitle = eventTitle.Length > 20 ? eventTitle.Substring(0, 20) : eventTitle.PadRight(20);
                D.Print(formattedTitle + " | ", false);
            }
        }
    }
    public Day AddDays(int daysToAdd)
    {
        DateTime date = new DateTime(_year, _month, _day).AddDays(daysToAdd);
        return new Day(date.Day, date.Month, date.Year);
    }
}  