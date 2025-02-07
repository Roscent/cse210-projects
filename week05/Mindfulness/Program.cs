using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Start {Name}");
        Console.WriteLine(Description);
        Console.Write("Enter duration (in seconds): ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowAnimation(3);
        RunActivity();
        EndActivity();
    }
    protected void EndActivity()
        {
            Console.WriteLine("Great job! You've completed the activity.");
            Console.WriteLine($"You spent {Duration} seconds on {Name}.");
            ShowAnimation(3);
        }

        protected void ShowAnimation(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected abstract void RunActivity();
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        Name = "Breathing Exercise";
        Description = "This activity will help you relax bu guiding you through deep brathing exercise.";
    }

    protected override void RunActivity()
    {
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            ShowAnimation(3);
            Console.WriteLine("Breathe out...");
            ShowAnimation(3);
            elapsed += 6;
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truely selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was completed?",
        "What made this time different than other times when you were not as successful?",
        "What is your favourite thing about this expereince?",
        "What could you learn from this experience that applies to other situation?",
        "What did you learn about yourself through this expereince?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection Exercise";
        Description = "This activity will help you reflect on moments of strenght and resilience.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        Console.WriteLine(prompts[random.Next(prompts.Count)]);
        ShowAnimation(5);

        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine(questions[random.Next(questions.Count)]);
            ShowAnimation(5);
            elapsed += 5;
        }
    }
}

class ListingActivity : Activity
{
    private List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strenght of yours?"
    };

    public ListingActivity()
    {
        Name = "Listing Exercise";
        Description = "This activity helps you reflect on positive aspects by listing as many items as possible.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
        ShowAnimation(5);
        Console.WriteLine("Start listing...");

        int count = 0;
        DateTime endTime = DateTime.Now.AddSeconds(Duration);
        while (DateTime.Now < endTime)
        {
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        Console.WriteLine("Roscent's first mindfulness program");

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activity");
            Console.WriteLine("1. Breathing Exercise");
            Console.WriteLine("2. Reflection Exercise");
            Console.WriteLine("3. Listing Exercise");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            };

            if (activity == null)
                break;

                activity.StartActivity();
        }
    }
}