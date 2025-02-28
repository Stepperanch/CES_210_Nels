public class BreathingActivity : Activity
{
    protected int _inTime;
    protected int _outTime;

    protected void BreatheIn()
    {
        Console.Write("Breathe in...   ");
        Countdown(_inTime);
        Console.Clear();
    }

    protected void BreatheOut()
    {
        Console.Write("Breathe out...   ");
        Countdown(_outTime);
        Console.Clear();
    }

    private void BreatheCycle()
    {
        DateTime end = DateTime.Now.AddSeconds(_time);
        while (DateTime.Now < end)
        {
            BreatheIn();
            BreatheOut();
        }
    }

    public BreathingActivity(int time)
    {
        _title = "Breathing";
        _time = time;
        Console.WriteLine("How Long would you like to breathe in for? (default 5 seconds)");
        if (!int.TryParse(Console.ReadLine(), out _inTime))
        {
            _inTime = 5;
        }
        Console.WriteLine("How Long would you like to breathe out for? (default 5 seconds)");
        if (!int.TryParse(Console.ReadLine(), out _outTime))
        {
            _outTime = 5;
        }
        _description = $"A breathing exercise to help you relax. \nThis exercise will prompt you to breathe in for {_inTime} seconds and breathe out for {_outTime} seconds.";
    }

    public void Start()
    {
        
        StartActivity();
        BreatheCycle();
        EndingMessage();
    }
}