using System;
using System.Threading.Tasks.Dataflow;

public class Resume
{
    public string _name;
    public List<job> _jobs = new List<job>();
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job in _jobs)
        {
            job.Display();
        }
    }
}