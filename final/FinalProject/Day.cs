using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Day : Month
{
    [JsonInclude] List<Event> _dayEvents = new List<Event>();
    [JsonInclude] private int _day;
    public Day() { } // Needed for JsonSerializer
    public Day(int year, int month, int day) : base(year, month, false)
    {
        _day = day;
        _dateTime = new DateTime(_year, _month, _day);
        _fundementalIdentifier = _dateTime.ToString("dddd-MMMM-dd-yyyy");
        for (int i = 0; i < 34; i++)
        {
            _dayEvents.Add(new Event());
        }
    }
    public new void Display()
    {
        D.Clear();
        D.Print(_dateTime.ToString("dddd, MMMM dd, yyyy"));
        D.NL();
        TimeOnly time = new TimeOnly(6, 0);
        for (int i = 0; i < _dayEvents.Count; i++)
        {
            Event e = _dayEvents[i];
            D.Print((i+1).ToString().PadLeft(2) + " | " + time.ToString().PadRight(8) + " | " + e.GetEvent().Title);
            time = time.AddMinutes(30);
        }
        D.NL(2);
        D.Print("Full Day Events:");
        for (int i = 0; i < _events.Count; i++)
        {
            Event e = _events[i];
            D.Print((i + 1).ToString() + " " + e.GetEvent().Title);
        }
        D.NL();

    }
    public new void Menu()
    {
        Display();
        D.Print("1. Add Event");
        D.Print("2. Edit Event");
        D.Print("3. Delete Event");
        D.Print("4. Display Event");
        D.Print("5. View Full Day Events");
        D.Print("6. Return to Month Menu");
        string input = D.Read();
        if (input == "1")
        {
            EditEvent(0);
        }
        else if (input == "2")
        {
            EditEvent(1);
        }
        else if (input == "3")
        {
            EditEvent(2);
        }
        else if (input == "4")
        {
            EditEvent(3);
        }
        else if (input == "5")
        {
            ViewEvents();
        }
        else if (input == "6")
        {
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        Menu();
    }
    private void EditEvent(int status)
    {
        D.Clear();
        D.Print("Chose a time between 6:00 AM and 10:30 PM");
        D.Print("Enter the time in the format HH:MM AM/PM");
        D.Print("Example: 6:00 AM or 10:30 PM");
        D.Print("Enter 0 to return to the menu");
        string timeInput = D.Read();
        if (TimeOnly.TryParse(timeInput, out TimeOnly time) && time.Hour >= 6 && time.Hour <= 22 && time.Minute % 30 == 0)
        {
            int eventIndex = (int)((time.Hour - 6) * 2 + (time.Minute / 30));
            if (status == 0)
            {
                _dayEvents[eventIndex].CreateEvent();
            }
            else if (status == 1)
            {
                _dayEvents[eventIndex].EditEvent();
            }
            else if (status == 2)
            {
                _dayEvents[eventIndex].DeleteEvent();
            }
            else if (status == 3)
            {
                _dayEvents[eventIndex].DisplayEvent();
            }
            return;
        }
        else if (timeInput == "0")
        {
            D.Clear();
            D.Print("Returning to Menu...");
            D.Pause(500);
            return;
        }
        else
        {
            D.Print("Invalid time. Please try again.");
            D.Pause();
        }
    EditEvent(status);
    }            
    public void DisplayIn((int X, int Y) position, bool first = false) // size is 23 char wide and 37 lines high
    {
        var (x, y) = position;
        if (first)
        {
            x = x - 9;
            y = y + 2;
            D.SetCursorPosition(x, y);
            D.Print("Time".PadRight(8) + " |", false);
            y++;
            TimeOnly time = new TimeOnly(6, 0);
            for (int i = 0; i < _dayEvents.Count; i++)
            {
                D.SetCursorPosition(x, y);
                time = time.AddMinutes(30);
                D.Print(time.ToString().PadRight(8) + " |", false);
                y++;
            }
            x = x + 9;
            for (int i = 0; i < _events.Count+2; i++)
            {
                D.SetCursorPosition(x, y);
                D.Print("|", false);
                y++;
            }
        }
        (x, y) = position;
        if (first || (_dateTime.Day == 1))
        {
            D.SetCursorPosition(x, y);
            D.Print("| " + _dateTime.ToString("MMMM-yyyy"), false);
            y++;
            D.SetCursorPosition(x, y);
            D.Print("|");
        }
        (x, y) = position;
        y = y + 2;
        x = x + 2;
        D.SetCursorPosition(x, y);
        D.Print(_dateTime.Day.ToString().PadRight(3) + _dateTime.ToString("dddd").PadRight(17) + " |", false);
        y++;
        foreach (Event e in _dayEvents)
        {
            D.SetCursorPosition(x, y);
            string eventTitle = e.GetEvent().Title;
            string formattedTitle = eventTitle.Length > 20 ? eventTitle.Substring(0, 20) : eventTitle.PadRight(20);
            D.Print(formattedTitle + " |", false);
            y++;
        }    
        D.SetCursorPosition(x, y);
        D.Print("                     |", false);
        y++;
        D.SetCursorPosition(x, y);
        D.Print("    Events Today     |", false);
        y++;
        for (int i = 0; i < _events.Count; i++)
        {
            D.SetCursorPosition(x, y);
            Event e = _events[i];
            string eventTitle = e.GetEvent().Title;
            string formattedTitle = eventTitle.Length > 20 ? eventTitle.Substring(0, 20) : eventTitle.PadRight(20);
            D.Print(formattedTitle + " |", false);
            y++;
        }

        // (x , y) = D.GetCursorPosition();
        // if (_dateTime.Day == 1)
        // {
        //     D.SetCursorPosition(x-2, y-36);
        //     D.Print("| " + _dateTime.ToString("MMMM-yyyy"));
        //     D.SetCursorPosition(x-2, y-35);
        //     D.Print("| ");
        // }
        // D.SetCursorPosition(x, y-34);
        // D.Print(_dateTime.Day.ToString().PadRight(3) + _dateTime.ToString("dddd").PadRight(17) + " | ", false);
    
        // for (int i = 0; i < _dayEvents.Count; i++)
        // {
        //     (x, y) = D.GetCursorPosition();
        //     D.SetCursorPosition(x-23, y+1);
        //     Event e = _dayEvents[i];
        //     string eventTitle = e.GetEvent().Title;
        //     string formattedTitle = eventTitle.Length > 20 ? eventTitle.Substring(0, 20) : eventTitle.PadRight(20);
        //     D.Print(formattedTitle + " | ", false);
        // }
        // (x, y) = D.GetCursorPosition();
        // D.SetCursorPosition(x-22, y+1);
        // //         12345678900987654321 
        // D.Print("|     Events Today     |");
        // D.SetCursorPosition(x-22, y+2);
        // D.Print("|                     |");
        // D.SetCursorPosition(x-22, y+3);
        // for (int i = 0; i < _events.Count; i++)
        //     {
        //         (x, y) = D.GetCursorPosition();
        //         D.SetCursorPosition(x, y+1);
        //         Event e = _events[i];
        //         string eventTitle = e.GetEvent().Title;
        //         string formattedTitle = eventTitle.Length > 20 ? eventTitle.Substring(0, 20) : eventTitle.PadRight(20);
        //         D.Print(formattedTitle + " | ", false);
        //     }
    }
    public Day AddDays(int daysToAdd)
    {
        DateTime date = new DateTime(_year, _month, _day).AddDays(daysToAdd);
        return new Day(date.Day, date.Month, date.Year);
    }
}  