public class BoxBreathing : BreathingActivity
{
    private int _holdTime;

    private void HoldBreath()
    {
        Console.Write("Hold...   ");
        Countdown(_holdTime);
        Console.Clear();
    }

    protected void BreatheCycle()
    {
        DateTime end = DateTime.Now.AddSeconds(_time);
        while (DateTime.Now < end)
        {
            BreatheIn();
            HoldBreath();
            BreatheOut();
            HoldBreath();
        }
    }

    public BoxBreathing(int time) : base(time)
    {
        _title = "Box Breathing";
        _time = time;
        Console.WriteLine("How Long would you like to hold your breath for? (default 5)");
        if (!int.TryParse(Console.ReadLine(), out _holdTime))
        {
            _holdTime = 5;
        }
        _description = $"A breathing exercise to help you relax. \nThis exercise will prompt you to breathe in for {_inTime} seconds, hold your breath for {_holdTime} seconds, breathe out for {_outTime} seconds, and hold your breath for {_holdTime} seconds.";
        Console.Clear();
    }

    public new void Start()
    {
        Console.Clear();
        StartActivity();
        BreatheCycle();
        EndingMessage();
    }
}