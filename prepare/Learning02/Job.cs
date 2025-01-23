using System.Runtime.CompilerServices;

public class Job
{
        public string _company;
        public string _jobTitle;
        public int _startYear;
        public int _endYear;
        public void Display()
        {
            string startYearFormatted = _startYear + " ABY";

            if (_startYear < 0)
            {
                _startYear = _startYear * -1;
                startYearFormatted = _startYear + " BBY";
            }
            if (_endYear == 0)
            {
                Console.WriteLine(_jobTitle + " (" + _company + ") "+ startYearFormatted + " to Present");
            }
            else
            {
                string endYearFormatted = _endYear + " ABY";
                if (_endYear < 0)
                {
                    _endYear = _endYear * -1;
                    endYearFormatted = _endYear + " BBY";
                }
                Console.WriteLine(_jobTitle + " (" + _company + ") "+ startYearFormatted + " to " + endYearFormatted);
            }
        }
}

public class Resume
{
    public string _name;
    public List<Job> _jobs;
    public void Display()
    {
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}