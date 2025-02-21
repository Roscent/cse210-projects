using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is Roscent's first Exercise Tracking Project.");
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 02, 18), 30, 4.8),
            new Cycling(new DateTime(2025, 02, 18), 45, 20.0),
            new Swimming(new DateTime(2025, 02, 18), 25, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}