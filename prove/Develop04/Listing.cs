public class ListingActivity : Activity
{
    private List<string> _question = new List<string>();

    public ListingActivity(int time)
    {
        _title = "Listening";
        _time = time;
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        MakeQuestions();
        Console.Clear();
    }

    private void MakeQuestions()
    {
        _question.Add("Who are people that you appreciate?");
        _question.Add("What are personal strengths of yours?");
        _question.Add("Who are people that you have helped this week?");
        _question.Add("When have you felt the Holy Ghost this month?");
        _question.Add("Who are some of your personal heroes?");
    }

    public void Start()
    {
        Console.Clear();
        StartActivity();
        ListingCycle();
        EndingMessage();
    }

    private void ListingCycle()
    {
        Random random = new Random();
        Console.WriteLine($"Your Question is: {_question[random.Next(0, _question.Count)]}");
        Console.WriteLine($"Please write down as many answers as you can think of in the next {_time} seconds.");
        Console.WriteLine("Activity Begins in 10 seconds.");
        Countdown(10);

        DateTime end = DateTime.Now.AddSeconds(_time);
        int count = 0;
        while (DateTime.Now < end)
        {
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You wrote down {count} answers.");
        Animation(5);
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
}