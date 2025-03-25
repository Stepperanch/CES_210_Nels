public class Day : Month
{
    List<Event> _events = new List<Event>();
    private int _day;
    public Day(int day, int month, int year) : base(month, year)
    {
        _day = day;
        _dateTime = new DateTime(_year, _month, _day);
        for (int i = 0; i < 34; i++)
        {
            _events.Add(new Event());
        }
    }
    public void Display()
    {
        D.Print(_dateTime.ToString("dddd, MMMM dd, yyyy"));
        D.Print("");
        for (int i = 0; i < _events.Count; i++)
        {
            TimeOnly time = new TimeOnly(6, 0).AddMinutes(i * 30);
            Event e = _events[i];
            D.Print(((i+1).ToString() + ".").PadRight(4) + time.ToString().PadRight(8) + " - " + e.GetEvent().Title);
        }
    }
    public void DisplayIn(bool first = false)
    {
        var (x , y) = D.GetCursorPosition();
        if (first)
        {
            D.Clear();
            D.Print("         | " + _dateTime.ToString("dddd").PadRight(20) + " | ");
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
        }
        else
        {
            D.SetCursorPosition(x, y-34);
            D.Print(_dateTime.ToString("dddd").PadRight(20) + " | ", false);
        
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