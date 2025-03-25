using System.Security.Cryptography;

public class Month : Year
{
    private List<Day> _days = new List<Day>();
    protected int _month;
    public Month(int month, int year) : base(year)
    {
        _month = month;
        _year = year;
        _dateTime = new DateTime(_year, _month, 1);
        if (this.GetType() == typeof(Month))
        {
            for (int i = 1; i <= DateTime.DaysInMonth(_year, _month); i++)
            {
                _days.Add(new Day(_year, _month, i));
            }
        }
    }
    
}