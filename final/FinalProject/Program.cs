using System;

class Program
{
    static void Main(string[] args)
    {
        D.Print("Welcome to the Calendar App!");
        D.Print("Please make sure that the window is as large as it can go");
        D.Clear();

        Calender calender = new Calender();
        calender.Menu();

        
    }

}