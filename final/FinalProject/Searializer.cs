using System.Text.Json;

public static class Serializer
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true // Ensures private fields with [JsonInclude] are serialized
    };
    public static string JsonSerialize(Year year, string filePath = "")
    {
        if (filePath == "")
        {
            filePath = $"year{year.GetYear()}.json";
        }
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            string jsonString = JsonSerializer.Serialize(year, new JsonSerializerOptions { WriteIndented = true });
            writer.Write(jsonString);
        }
        return filePath;
    }
    public static Year JsonDeserialize(string filePath = "")
    {
        if (filePath == "")
        {
            filePath = $"year{DateTime.Now.Year}.json";
        }
        if (!File.Exists(filePath))
        {
            return null;
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
            return null;
        }
        using (StreamReader reader = new StreamReader(filePath))
        {
            string json = reader.ReadToEnd();
            Year year = JsonSerializer.Deserialize<Year>(json);
            return year;
        }
    }       
}