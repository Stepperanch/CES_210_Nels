using System.Globalization;
using System.Runtime.InteropServices;

public class Calender
{
    private List<Year> _years = new List<Year>();
    private DateTime _currentDateTime = DateTime.Now;

    public void Menu()
    {
        _currentDateTime = DateTime.Now;
        D.Clear();
        D.Print("Main Menu");
        D.Print($"The Date is {_currentDateTime.ToString("MMMM dd, yyyy")}");
        D.Print($"The Time is {_currentDateTime.ToString("hh:mm tt")}");
        D.NL();
        D.Print("1. View Year");
        D.Print("2. Create New Year");
        D.Print("3. Save Year (not implemented)");
        D.Print("4. Load Year (not implemented)");
        D.Print("5. Exit");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();

        if (input == "1")
        {
            ViewYear();
        }
        else if (input == "2")
        {
            CreateNewYear();
        }
        else if (input == "3")
        {
            // SaveYear();
        }
        else if (input == "4")
        {
            // LoadYear();
        }
        else if (input == "5")
        {
            D.Clear();
            D.Print("WARNING, if you have not saved your work, it will be lost.");
            D.Print("Are you sure you want to exit? (y/n)");
            string exitInput = Console.ReadLine();
            if (exitInput == "y")
            {
                D.Print("Exiting...");
                D.Pause(200);
                Environment.Exit(0);
            }
            else
            {
                D.Print("Returning to Main Menu...");
                D.Pause(1000);
            }
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        Menu();
    }
    public void ViewYear()
    {
        D.Clear();
        D.Print("Select a year to view:");
        for (int i = 0; i < _years.Count; i++)
        {
            D.Print($"{i + 1}. {_years[i].GetYear()}");
        }
        D.Print($"{_years.Count + 1}. Back to Main Menu");
        D.NL();
        D.Print("Please select an option: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int choice) && choice > 0 && choice <= _years.Count)
        {
            _years[choice - 1].Menu();
            return;
        }
        else if (input == (_years.Count + 1).ToString())
        {
            D.Clear();
            D.Print("Returning to Main Menu...");
            D.Pause(1000);
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        ViewYear();
    }
    public void CreateNewYear()
    {
        D.Clear();
        D.Print("Enter the year you want to create (enter 0 to exit): ");
        string input = Console.ReadLine();
        if (input == "0")
        {
            D.Clear();
            D.Print("Returning to Main Menu...");
            D.Pause(1000);
            return;
        }
        if (int.TryParse(input, out int year))
        {
            Year newYear = new Year(year);
            _years.Add(newYear);
            D.Print($"Year {year} created successfully.");
            D.Pause();
            return;
        }
        else
        {
            D.Print("Invalid input. Please try again.");
            D.Pause();
        }
        CreateNewYear();
    }
}