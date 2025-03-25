public class Year
{
    private List<Month> _months = new List<Month>();
    protected int _year;
    protected DateTime _dateTime;
    public Year(int year)
    {
        _year = year;
        _dateTime = new DateTime(_year, 1, 1);
        if (this.GetType() == typeof(Year))
        {
            for (int i = 1; i <= 12; i++)
            {
                _months.Add(new Month(_year, i));
            }
        }
        
    }
}