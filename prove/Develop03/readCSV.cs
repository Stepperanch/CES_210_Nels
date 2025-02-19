// CSV fromat:
// Book ~-| Chapter ~-| Start Verse ~-| End Verse (optional) ~-| text



public class ScriptureReader
{
    public List<Scripture> ReadFromCSVFile()   // ReadFromCSVFile method
    {
        List<Scripture> scriptures = new List<Scripture>();
        string fileName = "Scriptures.csv";
        using (StreamReader reader = new StreamReader(fileName))    // Create a new StreamReader object
        {
            string line = "";   // Initialize line
            while ((line = reader.ReadLine()) != null)   // Read each line from the file
            {
                if (!string.IsNullOrWhiteSpace(line))   // Check if the line is not empty
                {   
                    string[] entry = line.Split("~-|");  // Split the line by the delimiter
                    if (entry.Length < 5 || string.IsNullOrEmpty(entry[4]))  // Check the length of the entry
                    {
                        scriptures.Add(new Scripture(entry[0], int.Parse(entry[1]), int.Parse(entry[2]), entry[3]));    // Add a new Scripture object to the list
                    }
                    else
                    {
                        scriptures.Add(new Scripture(entry[0], int.Parse(entry[1]), int.Parse(entry[2]), int.Parse(entry[3]), entry[4]));   // Add a new Scripture object to the list
                    }
                }
            }
        }
        return scriptures;
    }
}