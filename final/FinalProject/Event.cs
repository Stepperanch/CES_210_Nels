public class Event
{
    public string _title;
    public string _description;
    public string _report;
    public string _location;
    public bool _isReminder;

    public Event(DateTime eventTimeObj)
    {
        string eventTime = eventTimeObj.ToString("MM/dd/yy hh:mm tt");
        Console.WriteLine($"Creating a new event at {eventTime}");
        Console.WriteLine("(*) denotes required fields");
        Console.WriteLine("What is the title of the event? (*)");
        _title = Console.ReadLine();
        Console.WriteLine("What is the description of the event?");
        _description = Console.ReadLine();
        Console.WriteLine("What is the Location of the event?");
        _location = Console.ReadLine();
        Console.WriteLine("Would you like to set a reminder for this event? (y/n) (*)");
        string reminder = Console.ReadLine();
        if (reminder == "y")
        {
            _isReminder = true;
        }
        else
        {
            _isReminder = false;
        }
    }
    Tuple<string, string, string, string, bool> GetEvent()
    {
        return Tuple.Create(_title, _description, _location, _report, _isReminder);
    }
}