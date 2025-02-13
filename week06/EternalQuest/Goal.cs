using System;

abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsCompleted = false;
    }
    
    public abstract void RecordEvent(ref int score);
    public abstract string GetProgress();
}