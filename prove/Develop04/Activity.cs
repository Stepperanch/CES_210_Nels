public class Activity
{
    protected string _title;
    protected string _description;
    protected int _time;

    public string GetTitle()
    {
        return _title;
    }

    protected void StartActivity()
    {
        Console.WriteLine($"Welcome to the {_title} activity.");
        Console.WriteLine(_description);
        Animation(5);
        Console.Clear();
    }

    public void Animation(int duration)
    {
        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            Console.Write('-');
            Thread.Sleep(150);
            Console.Write('\b');
            Console.Write('\\');
            Thread.Sleep(150);
            Console.Write('\b');
            Console.Write('|');
            Thread.Sleep(150);
            Console.Write('\b');
            Console.Write('/');
            Thread.Sleep(150);
            Console.Write('\b');
            
        }
    }

    public void Countdown(int duration)
    {
        for (int i = duration; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write('\b');
            if (i >= 10)
            {
                Console.Write(' ');
                Console.Write('\b');
                Console.Write('\b');
            }
        }
    }

    public void EndingMessage()
    {
        Console.Clear();
        Console.WriteLine("Thank you for participating in the "+ _title +" activity.");
        Console.WriteLine("You spent "+ _time +" seconds on this activity.");
        Animation(5);
        Console.Clear();
    }
}