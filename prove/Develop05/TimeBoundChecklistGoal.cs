public class TimeBoundChecklistGoal : ChecklistGoal
{
    public TimeBoundChecklistGoal(string content, int points, int finalPoints, int times, DateTime endDate) : base(content, points, finalPoints, times, endDate)
    {
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"End Date: {_endDate}");
    }
}