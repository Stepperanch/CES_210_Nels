using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using System.Data.Common;
using System.IO;

// Class - JournalPrompt
// _funPrompt: List<string> -> List of fun prompts
// _meaningfullPrompt: List<string> -> List of meaningful prompts
// _spiritualPrompt: List<string> -> List of spiritual prompts
// _workPrompt: List<string> -> List of work prompts

// FetchPrompt(category: string, index: int) -> string -> Takes a category and index and returns a prompt
// GivePrompt() -> string -> Gives a random prompt

// Class - JournalEntry
// _entry: string -> Entry text
// _date: string -> Date of entry
// _title: string -> Title of entry

// WriteEntry() -> void -> Writes an entry
// WriteEntryFromPrompt(prompt: string) -> void -> Writes an entry from a prompt

// Class - Journal
// _entries: List<JournalEntry> -> List of journal entries
// AddEntry(entry: JournalEntry) -> void -> Adds an entry to the journal
// Display() -> void -> Displays all entries
// DisplayDate(date: string) -> void -> Displays entries from a specific date
// WriteToCSVFile() -> void -> Writes entries to a CSV file
// ReadFromCSVFile() -> void -> Reads entries from a CSV file


public class JournalPrompt
{
    public JournalPrompt() // Constructor
    {
        _funPrompt = new List<string>();  // Initialize fun prompts
        _funPrompt.Add("What is the funniest thing that happened to you today?");
        _funPrompt.Add("What is the most exciting thing that happened to you today?");
        _funPrompt.Add("What is a pretty sight you saw today?");
        _funPrompt.Add("What is a pretty sound you heard today?");
        _funPrompt.Add("What is a nice smell you smelled today?");
        _funPrompt.Add("What is a delicious taste you tasted today?");
        _funPrompt.Add("What is a nice thing you felt today?");
        _meaningfullPrompt = new List<string>();    // Initialize meaningful prompts
        _meaningfullPrompt.Add("What is the most meaningful thing that happened to you today?");
        _meaningfullPrompt.Add("What is the most important thing you learned today?");
        _meaningfullPrompt.Add("What is the most important thing you did today?");
        _meaningfullPrompt.Add("What is the most important thing you thought about today?");
        _meaningfullPrompt.Add("What is the most important thing you felt today?");
        _meaningfullPrompt.Add("What is the most important thing you heard today?");
        _meaningfullPrompt.Add("What is the most important thing you saw today?");
        _spiritualPrompt = new List<string>();  // Initialize spiritual prompts
        _spiritualPrompt.Add("What is the most spiritual thing that happened to you today?");
        _spiritualPrompt.Add("What is the most spiritual thing you learned today?");
        _spiritualPrompt.Add("What is the most spiritual thing you did today?");
        _spiritualPrompt.Add("What is the most spiritual thing you thought about today?");
        _spiritualPrompt.Add("What is the most spiritual thing you felt today?");
        _spiritualPrompt.Add("What is the most spiritual thing you heard today?");
        _spiritualPrompt.Add("What is the most spiritual thing you saw today?");
        _workPrompt = new List<string>();   // Initialize work prompts
        _workPrompt.Add("What is the biggest problem you solved today?");
        _workPrompt.Add("When was is the time you felt the most productive today?");
    }
    public List<string> _funPrompt; // List of fun prompts
    public List<string> _meaningfullPrompt; // List of meaningful prompts
    public List<string> _spiritualPrompt;   // List of spiritual prompts
    public List<string> _workPrompt;    // List of work prompts

    public string FetchPrompt(string category, int index)   // Fetches a prompt based on category and index
    {
        if (category == "1")
        {
            return _funPrompt[index];
        }
        else if (category == "2")
        {
            return _meaningfullPrompt[index];
        }
        else if (category == "3")
        {
            return _spiritualPrompt[index];
        }
        else if (category == "4")
        {
            return _workPrompt[index];
        }
        else
        {
            return "Invalid input please try again";
        }
    }
    
    public string GivePrompt()  // Gives a random prompt
    {
        Console.WriteLine("Choose a prompt category: Fun(1), Meaningful(2), Spiritual(3), Work(4)");    // Prompt the user to choose a category
        string category = Console.ReadLine();   // Get the category from the user
        Random random = new Random();   // Create a new random object
        int index;  // Initialize index
        string prompt = "Invalid input please try again";   // Initialize prompt
        if (category == "1")
        {
            index = random.Next(_funPrompt.Count);
            prompt = _funPrompt[index];
        }
        else if (category == "2")
        {
            index = random.Next(_meaningfullPrompt.Count);
            prompt = _meaningfullPrompt[index];
        }
        else if (category == "3")
        {
            index = random.Next(_spiritualPrompt.Count);
            prompt = _spiritualPrompt[index];
        }
        else if (category == "4")
        {
            index = random.Next(_workPrompt.Count);
            prompt = _workPrompt[index];
        }
        else
        {
            Console.WriteLine(prompt);  // If the category is invalid print the Invalid input message
            return GivePrompt();        // Call the GivePrompt method again
        }
        
        Console.WriteLine(prompt);  // Print the prompt
        return prompt;  // Return the prompt
    }

}

public class JournalEntry   // JournalEntry class
{
    public JournalEntry()   // Constructor
    {
        _entry = "";    // Initialize entry
        _title = "";    // Initialize title
        _date = DateTime.Now.ToString("yy-MM-dd");      // Initialize date
    }
    public string _entry;   // Entry text
    public string _date;    // Date of entry
    public string _title; // if prompt is used prompt will be the title
    public void WriteEntry()    // WriteEntry method
    {
        Console.WriteLine("What is the title of your entry?");  
        _title = Console.ReadLine();    // Get the title from the user
        Console.WriteLine("What is your entry?");
        _entry = Console.ReadLine();    // Get the entry from the user
    }
    public void WriteEntryFromPrompt(string prompt)
    {
        _title = prompt;    // Set the title to the prompt
        Console.WriteLine("What is your entry?");
        _entry = Console.ReadLine();    // Get the entry from the user
    }
}

public class Journal    // Journal class
{
    public Journal()    // Constructor
    {
        _entries = new List<JournalEntry>();    // Initialize entries
    }
    public List<JournalEntry> _entries; // List of journal entries

    public void AddEntry(JournalEntry entry)   // AddEntry method
    {
        _entries.Add(entry);    // Add the entry to the list
    }

    public void Display()   // Display method
    {
        foreach (JournalEntry entry in _entries)    // Loop through all entries
        {
            Console.WriteLine(entry._date);
            Console.WriteLine(entry._title);
            Console.WriteLine(entry._entry);
        }
    }

    public void DisplayDate(string date)    // DisplayDate method
    {
        foreach (JournalEntry entry in _entries)    // Loop through all entries
        {
            if (entry._date == date)    // If the entry date matches the given date print the entry
            {
                Console.WriteLine(entry._date);
                Console.WriteLine(entry._title);
                Console.WriteLine(entry._entry);
            }
            else
            {
                Console.WriteLine("No entries found for that date");    // If no entries are found print a message
            }
        }
    }

    public void WriteToCSVFile()    // WriteToCSVFile method
    
    {
        Console.WriteLine("What is the name of the file you want to write to? (default: journal.csv)");   // Prompt the user for a file name
        string fileName = Console.ReadLine();   // Get the file name from the user
        if (fileName == "")  // If the file name is empty set it to journal.csv
        {
            fileName = "journal.csv";
        }
        using (StreamWriter writer = new StreamWriter(fileName))    // Create a new StreamWriter object
        {
            foreach (JournalEntry entry in _entries) // Loop through all entries
            {
                writer.WriteLine(entry._date + "~|~" + entry._title + "~|~" + entry._entry);    // Write the entry to the file
            }
        }
    }

    public void ReadFromCSVFile()   // ReadFromCSVFile method
    {
        Console.WriteLine("What is the name of the file you want to read from? (default: journal.csv)");    // Prompt the user for a file name
        string fileName = Console.ReadLine();   // Get the file name from the user
        if (fileName == "") // If the file name is empty set it to journal.csv
        {
            fileName = "journal.csv";
        }
        using (StreamReader reader = new StreamReader(fileName))    // Create a new StreamReader object
        {
            _entries.Clear();   // Clear the entries list
            string line = "";   // Initialize line
            while ((line = reader.ReadLine()) != null)  //
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] entry = line.Split("~|~");
                    JournalEntry newEntry = new JournalEntry();
                    newEntry._date = entry[0];
                    newEntry._title = entry[1];
                    newEntry._entry = entry[2];
                    _entries.Add(newEntry);
                }
            }
        }
    }
}