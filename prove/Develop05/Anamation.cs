public class Anamation()
{
    public void Spiner(int duration)
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
    public void Dashes(int duration)
    {
        DateTime end = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < end)
        {
            Console.Write('-');
            Thread.Sleep(150);
            Console.Write('-');
            Thread.Sleep(150);
            Console.Write('-');
            Thread.Sleep(150);
            Console.Write("\b\b\b");
            Console.Write("   ");
            Console.Write("\b\b\b");
            Thread.Sleep(150);
        }
    }
    public void PressAnyKeyToContinue()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}