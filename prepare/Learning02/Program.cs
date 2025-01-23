using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Watto's Junkyard";
        job1._jobTitle = "Slave";
        job1._startYear = -41;
        job1._endYear = -32;

        Job job2 = new Job();
        job2._company = "The Jedi Order";
        job2._jobTitle = "Padawan";
        job2._startYear = -32;
        job2._endYear = -22;

        Job job3 = new Job();
        job3._company = "The Jedi Order";
        job3._jobTitle = "Jedi Knight";
        job3._startYear = -22;
        job3._endYear = -19;

        Job job4 = new Job();
        job4._company = "The First Galactic Empire";
        job4._jobTitle = "Dark Lord of the Sith";
        job4._startYear = -19;
        job4._endYear = 4;

        Job job5 = new Job();
        job5._company = "The Cosmic Force";
        job5._jobTitle = "Force Ghost";
        job5._startYear = 4;


        Resume resume = new Resume();
        resume._name = "Anakin Skywalker";
        resume._jobs = new List<Job>();
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);
        resume._jobs.Add(job3);
        resume._jobs.Add(job4);
        resume._jobs.Add(job5);

        resume.Display();
        
    }
}