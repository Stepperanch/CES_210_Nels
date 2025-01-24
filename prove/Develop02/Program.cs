using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("Welcome to the Journal App!");
            Console.WriteLine("1. Add an entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Display entries from a specific date");
            Console.WriteLine("4. Give me a prompt");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                JournalEntry entry = new JournalEntry();
                entry.WriteEntry();
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                Console.WriteLine("What date would you like to see entries from?");
                string date = Console.ReadLine();
                journal.DisplayDate(date);
            }
            else if (choice == "4")
            {
                JournalPrompt promptObj = new JournalPrompt();
                string prompt = promptObj.GivePrompt();
                JournalEntry entry = new JournalEntry();
                entry.WriteEntryFromPrompt(prompt);
                journal.AddEntry(entry);
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}