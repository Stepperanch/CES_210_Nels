public class D
{
    public static void Print(string message, bool newLine = true)
    {
        if (newLine)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.Write(message);
        }
    }
    public static string Read()
    {
        return Console.ReadLine();
    }
    public static void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
    public static void ResetColor()
    {
        Console.ResetColor();
    }
    public static void Clear()
    {
        Console.Clear();
    }
    public static void Pause()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    public static void Pause(int duration)
    {
        Thread.Sleep(duration);
    }
    public static void Spiner(int duration)
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
    public static void Countdown(int duration)

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
    public static void Dashes(int duration)
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
    public static (int x, int y) GetCursorPosition()
    {
        return (Console.CursorLeft, Console.CursorTop);
    }
    public static void SetCursorPosition(int x, int y)
    {
        Console.SetCursorPosition(x, y);
    }
    public static void NL(int lines = 1)
    {
        for (int i = 0; i < lines; i++)
        {
            Console.WriteLine();
        }
    }
}