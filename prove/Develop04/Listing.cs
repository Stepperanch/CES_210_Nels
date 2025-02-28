public class ListingActivity : Activity
{
    private List<string> _question = new List<string>();

    public ListingActivity(int time)
    {
        _title = "Listening";
        _time = time;
        _question.Add("What did you hear?");
        _question.Add("What did you feel?");
        _question.Add("What did you see?");
        _description = "A listening exercise to help you focus. \nThis exercise will prompt you to listen to the sounds around you and reflect on them.";
    }
}