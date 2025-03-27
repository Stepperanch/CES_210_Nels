public class Event
{
    private string _title = "-";
    private string _description = "";
    private string _report = "";
    private string _location = "";
    private bool _isReminder = false;
    public void CreateEvent()
    {
        D.Print($"Creating a new event");
        D.Print("(*) denotes required fields");
        D.Print("What is the title of the event? (*)");
        _title = D.Read();
        D.Print("What is the description of the event?");
        _description = D.Read();
        D.Print("What is the Location of the event?");
        _location = D.Read();
        D.Print("Would you like to set a reminder for 30 min before this event? (y/n) (*)");
        string reminder = D.Read();
        if (reminder == "y")
        {
            _isReminder = true;
        }
        else
        {
            _isReminder = false;
        }
    }
    public (string Title, string Description, string Location, string Report, bool IsReminder) GetEvent()
    {
        return (_title, _description, _location, _report, _isReminder);
    }
    public void DisplayEvent()
    {
        Console.WriteLine($"Title: {_title}");
        if (_description != "")
        {
            D.Print($"Description: {_description}");
        }
        if (_location != "")
        {
            D.Print($"Location: {_location}");
        }
        if (_report != "")
        {
            D.Print($"Report: {_report}");
        }
        if (_isReminder)
        {
            D.Print("Reminder set for 30 minutes before the event");
        }
    }
    private char EditEventMenu()
    {
        DisplayEvent();
        D.Print("What would you like to Do?");
        D.Print("1. Title");
        if (_description != "")
        {
            D.Print("2. Add Description");
        }
        else
        {
            D.Print("2. Edit Description");
        }
        if (_location != "")
        {
            D.Print("3. Add Location");
        }
        else
        {
            D.Print("3. Edit Location");
        }
        if (_report != "")
        {
            D.Print("4. Add Report");
        }
        else
        {
            D.Print("4. Edit Report");
        }
        if (_isReminder)
        {
            D.Print("5. Remove Reminder");
        }
        else
        {
            D.Print("5. Add Reminder");
        }
        D.Print("6. Exit");
        return Convert.ToChar(D.Read());
    }
    public void EventMenu()
    {
        char choice = '0';
        while (choice != '6')
        {
            choice = EditEventMenu();
            switch (choice)
            {
                case '1':
                    D.Print("Current Title :" + _title);
                    D.Print("Enter the new title");
                    _title = D.Read();
                    break;
                case '2':
                    if (_description != "")
                    {
                        D.Print("Current Description :" + _description);
                    }
                    D.Print("Enter the new description");
                    _description = D.Read();
                    break;
                case '3':
                    if (_location != "")
                    {
                        D.Print("Current Location :" + _location);
                    }
                    D.Print("Enter the new location");
                    _location = D.Read();
                    break;
                case '4':
                    if (_report != "")
                    {
                        D.Print("Current Report :" + _report);
                    }
                    D.Print("Enter the new report");
                    _report = D.Read();
                    break;
                case '5':
                    if (_isReminder)
                    {
                        _isReminder = false;
                        D.Print("Reminder removed");
                    }
                    else
                    {
                        _isReminder = true;
                        D.Print("Reminder set for 30 minutes before the event");
                    }
                    break;
                case '6':
                    break;
                default:
                    D.Print("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
