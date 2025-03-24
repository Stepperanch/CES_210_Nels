class DisplayDriver
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }
    public string Read()
    {
        return Console.ReadLine();
    }
    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
    public void ResetColor()
    {
        Console.ResetColor();
    }

}