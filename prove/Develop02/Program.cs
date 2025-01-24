using System;


class Program
{
    static void Main(string[] args) 
    {
        Journal journal = new Journal(); // Create a new Journal object
        Console.WriteLine("Welcome to the Journal App!"); // Display a welcome message
        while (true)
        {
            Console.WriteLine(); // Display a blank line
            Console.WriteLine("1. Add an entry");
            Console.WriteLine("2. Give me a prompt");
            Console.WriteLine("3. Display all entries");
            Console.WriteLine("4. Display entries from a specific date");
            Console.WriteLine("5. Write entries to a CSV file");
            Console.WriteLine("6. Fetch entries from a CSV file");
            Console.WriteLine("7. Exit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            Console.WriteLine(); // Display a blank line
            if (choice == "1")
            {
                JournalEntry entry = new JournalEntry(); // Create a new JournalEntry object
                entry.WriteEntry(); // Call the WriteEntry method on the JournalEntry object
                journal.AddEntry(entry); // Call the AddEntry method on the Journal object
                Console.WriteLine("Entry added successfully!");
            }
            else if (choice == "3")
            {
                journal.Display(); // Call the Display method on the Journal object

            }
            else if (choice == "4")
            {
                Console.WriteLine("What date would you like to see entries from? (YY-MM-DD)");
                string date = Console.ReadLine(); // Get the date from the user
                journal.DisplayDate(date); // Call the DisplayDate method on the Journal object
            }
            else if (choice == "2")
            {
                JournalPrompt promptObj = new JournalPrompt(); // Create a new JournalPrompt object
                string prompt = promptObj.GivePrompt(); // Call the GivePrompt method on the JournalPrompt object
                JournalEntry entry = new JournalEntry(); // Create a new JournalEntry object
                entry.WriteEntryFromPrompt(prompt); // Call the WriteEntryFromPrompt method on the JournalEntry object
                journal.AddEntry(entry); // Call the AddEntry method on the Journal object
                Console.WriteLine("Entry added successfully!");
            }
            else if (choice == "5")
            {
                journal.WriteToCSVFile(); // Call the WriteToCSVFile method on the Journal object
                Console.WriteLine("Entries written to CSV file successfully!");
            }
            else if (choice == "6")
            {
                journal.ReadFromCSVFile(); // Call the ReadFromCSVFile method on the Journal object
                Console.WriteLine("Entries fetched from CSV file successfully!");
            }
            else if (choice == "7")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}

// I exceded the reqirmement by 
// Giving a option to Enter a entry withou prompt
// Giving a option to Display entries from a specific date
// Giveing each entry a title atribute
// Gave the user a option to select a prompt from a certan catagory (Fun, Meaningful, Spiritual, Work)
// Added a invalid choice message