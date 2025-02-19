public class Assingment
{
    protected string _studentName;
    protected string _topic;

    public Assingment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} is working on {_topic}";
    }
}

public class MathAssignment : Assingment
{
    private string _textbookSection;
    private string _problemSet;

    public MathAssignment(string studentName, string topic, string textbookSection, string problemSet) : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problemSet = problemSet;
    }

    public string GetHomeworkList()
    {
        return $"Textbook Section: {_textbookSection}\nProblem Set: {_problemSet}";
    }

    public List<string> GetAllInformation()
    {
        return new List<string> { _studentName, _topic, _textbookSection, _problemSet };
    }
}

public class WritingAssignment : Assingment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{_title} by {_studentName}";
    }

    public string GetTopic()
    {
        return _topic;
    }

    public List<string> GetAllInformation()
    {
        return new List<string> { _studentName, _topic, _title };
    }
}
