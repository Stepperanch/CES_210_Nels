public class ReflectionActivity : Activity
{
    private List<string> _question1;
    private List<string> _question2;

    public ReflectionActivity(int time)
    {
        _title = "Reflection";
        _time = time;
        _description = "A reflection exercise to help you relax. \nThis exercise will prompt you to reflect on your life and answer some questions.";
        MakeQuestions();
    }

    private void MakeQuestions()
    {
        _question1 = new List<string>();
        _question2 = new List<string>();

        _question1.Add("Think of a time when you did something really difficult.");
        _question1.Add("Think of a time when you helped someone in need.");
        _question1.Add("Think of a time when you did something truly selfless.");
        _question1.Add("Think of a time when you stood up for someone else.");
        
        _question2.Add("Why was this experience meaningful to you?");
        _question2.Add("Have you ever done anything like this before?");
        _question2.Add("How did you get started?");
        _question2.Add("How did you feel when it was complete?");
        _question2.Add("What made this time different than other times when you were not as successful?");
        _question2.Add("What is your favorite thing about this experience?");
        _question2.Add("What could you learn from this experience that applies to other situations?");
        _question2.Add("What did you learn about yourself through this experience?");
        _question2.Add("How can you keep this experience in mind in the future?");
    }
    public void Start()
    {
        Console.Clear();
        StartActivity();
        Console.WriteLine("Please answer the following questions:");
        ReflectionCycle();
        EndingMessage();
    }

    private int SetIndex(List<int> usedIndex)
    {
        Random random = new Random();
        int newindex = random.Next(0, _question1.Count);
            if (newindex == usedIndex[0] || newindex == usedIndex[1] || newindex == usedIndex[2])
            {
                return SetIndex(usedIndex);
            }
            else
            {
                usedIndex.Add(newindex);
                usedIndex.RemoveAt(0);
                return newindex;
            }
    }
    private void ReflectionCycle()
    {   
        int index = -1;
        List<int> usedIndex = new List<int>();
        usedIndex.Add(-1);
        usedIndex.Add(-1);
        usedIndex.Add(-1);

        DateTime end = DateTime.Now.AddSeconds(_time);
        while (true)
        {
            if (DateTime.Now >= end)
                {
                    break;
                }
            Console.Clear();
            index = SetIndex(usedIndex); 
            Console.WriteLine(_question1[index]);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            foreach (string question in _question2)
            {
                Console.WriteLine(question);
                Animation(0);
                if (DateTime.Now >= end)
                {
                    break;
                }
            }
        }
    }
}