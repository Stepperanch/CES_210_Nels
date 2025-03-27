using System.Text.Json;

public static class Serializer
{
    public static void JsonSerialize(Year year, string filePath = "")
    {
        if (filePath == "")
        {
            filePath = $"year{year.GetYear()}.json";
        }
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            string json = JsonSerializer.Serialize(year);
            writer.Write(json);
        }
    }
    public static Year JsonDeserialize(string filePath = "")
    {
        if (filePath == "")
        {
            filePath = $"year{DateTime.Now.Year}.json";
        }
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }
        using (StreamReader reader = new StreamReader(filePath))
        {
            string json = reader.ReadToEnd();
            Year year = JsonSerializer.Deserialize<Year>(json);
            return year;
        }
    }
    public static Year JsonDeserialize(int yearValue = 0)
    {
        string filePath = $"year{yearValue}.json";
        if (yearValue == 0)
        {
            filePath = $"year{DateTime.Now.Year}.json";
        }
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }
        using (StreamReader reader = new StreamReader(filePath))
        {
            string json = reader.ReadToEnd();
            Year year = JsonSerializer.Deserialize<Year>(json);
            return year;
        }
    }
        
}