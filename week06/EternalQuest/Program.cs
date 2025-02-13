using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is Roscent's EternalQuest Project.");
        GoalManager manager = new GoalManager();
        while (true)
        {
            Console.WriteLine("1. Add Simple Goal\n2. Add Eternal Goal\n3. Add Checklist Goal\n4. Record Event\n5. Show Goals\n6. Save Goals\n7. Load Goals\n8. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal("Run a Marathon", "Complete a full marathon", 1000));
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal("Read Scriptures", "Read scriptures daily", 100));
                    break;
                case "3":
                    manager.AddGoal(new ChecklistGoal("Attend Temple", "Go to the temple 10 times", 50, 10, 500));
                    break;
                case "4":
                    manager.DisplayGoals();
                    Console.Write("Enter goal number to record event: ");
                    if (int.TryParse(Console.ReadLine(), out int goalIndex))
                        manager.RecordEvent(goalIndex - 1);
                    break;
                case "5":
                    manager.DisplayGoals();
                    break;
                case "6":
                    manager.SaveGoals();
                    break;
                case "7":
                    manager.LoadGoals();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}