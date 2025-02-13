class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }
    public void RecordEvent(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            goals[index].RecordEvent(ref score);
            Console.WriteLine("Event recorded!");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name} - {goals[i].GetProgress()}");
        }
        Console.WriteLine($"Total Score: {score}\n");
    }
    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter ("goals.txt"))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
            {
                if (goal is ChecklistGoal checklistGoal)
                    writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Description},{goal.Points},{checklistGoal.GetProgress()}");
                else
                    writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Description},{goal.Points}");
            }
        }
        Console.WriteLine("Goals saved");
    }
    public void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(',');
                if (parts[0] == "SimpleGoal")
                    goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                else if (parts[0] == "EternalGoal")
                    goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                else if (parts[0] == "ChecklistGoal")
                    goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), 20, 200));
            }
            Console.WriteLine("Goals loaded!");
        }
        else
        {
            Console.WriteLine("No saved goals found.");
        }
    }
}