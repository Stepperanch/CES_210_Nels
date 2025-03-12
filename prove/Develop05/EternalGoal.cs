public class EternalGoal : TimeBoundRepeatingGoal
{
    public EternalGoal(string content, int points) : base(content, points, DateTime.MaxValue)
    {
    }
    public override void DisplayGoal()
    {
        Console.WriteLine($"Content: {_content}");
        Console.WriteLine($"Points: {_points}");
        Console.WriteLine($"Times Completed: {_timesCompleted}");
    }
}