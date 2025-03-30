using System.Globalization;
using System.Runtime.CompilerServices;
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
        D.Print("3. Save Year");
        D.Print("4. Load Year");
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
            SaveYear();
        }
        else if (input == "4")
        {
            LoadYear();
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
    private void ViewYear()
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
    private void CreateNewYear()
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
        if (int.TryParse(input, out int year) && year > 0 && year <= 9999)
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
    private void SaveYear()
    {
        D.Clear();
        D.Print("Select a year to save:");
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
            Year yearToSave = _years[choice - 1];
            D.Print("What would you like to name the file?");
            D.Print("Please enter the name of the file (without extension): ");
            D.Print($"Default name is year{yearToSave.GetYear()}");
            string fileName = D.Read();

            string filepath = Serializer.JsonSerialize(yearToSave, fileName);

            D.Print($"Year {yearToSave.GetYear()} saved successfully to {filepath}");
            D.Pause();
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
        SaveYear();
    }
    private void LoadYear()
    {
        D.Clear();
        D.Print("Enter the name of the file (without extension) or the int name of the year to load");
        D.Print($"Default year is {DateTime.Now.Year}");
        D.Print("Enter 0 to exit");
        string fileName = D.Read();
        if (fileName == "0")
        {
            D.Clear();
            D.Print("Returning to Main Menu...");
            D.Pause(1000);
            return;
        }
        else if (int.TryParse(fileName, out int year) && year > 0 && year <= 9999)
        {
            Year loadedYear = Serializer.JsonDeserialize(year);
            if (loadedYear != null)
            {
                _years.Add(loadedYear);
                D.Print($"Year {loadedYear.GetYear} loaded successfully.");
                D.Pause();
                return;
            }
            else
            {
                D.Print("Failed to load the year. Please try again.");
                D.Pause();
            }
        }
        else 
        {
            Year loadedYear = Serializer.JsonDeserialize(fileName);
            if (loadedYear != null)
            {
                _years.Add(loadedYear);
                D.Print($"Year {loadedYear.GetYear} loaded successfully.");
                D.Pause();
                return;
            }
            else
            {
                D.Print("Failed to load the year. Please try again.");
                D.Pause();
            }
        }
        LoadYear();
    }
}