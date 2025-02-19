
class Program
{
        static void Main()
    {
        
        Console.Clear();

        ScriptureReader reader = new ScriptureReader();

        List<Scripture> scriptures = reader.ReadFromCSVFile();

        Console.WriteLine("What scripture would you like to memorize? (Press 'e' to close)");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].ReturnRefrence()}");
        }

        char input = Console.ReadKey().KeyChar;
        if (input == 'e')
        {
            return;
        }

        int index = int.Parse(input.ToString()) - 1;

        Scripture scripture = scriptures[index];

        Console.Clear();

        Console.WriteLine("Here is the verse you will be memorizing:");
        Console.WriteLine();
        Console.WriteLine(scripture.ReturnRefrence());

        bool done = scripture.MemorizeLoop(true);
        Console.WriteLine();
        Console.WriteLine("The verse will be displayed repeatedly, each time you will have the opportunity to hide or unhide a word.");
        Console.WriteLine("Press 1 to hide a word, 2 to unhide a word, or 3 to exit.");

        while (!done)
        {
            char hide = Console.ReadKey().KeyChar;
            Console.Clear();
            if (hide == '1')
            {
                done = scripture.MemorizeLoop(false);
            }
            else if (hide == '2')
            {
                done = scripture.MemorizeLoop(true);
            }
            else if (hide == '3' || done == true)
            {
                Console.WriteLine();
                Main();
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
            Console.WriteLine();
        }

        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Congratulations! You have successfully memorized the verse.");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
        Main();
    }
}
