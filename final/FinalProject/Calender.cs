using System.Globalization;
using System.Runtime.InteropServices;

public class Calender
{
    private Year _calendar;
    public Calender(int year)
    {
        _calendar = new Year(year);
    }

}