class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent(ref int score)
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            score += Points;
        }
    }

    public override string GetProgress()
    {
        return IsCompleted ? "[X] Completed" : "[ ] Not Completed";
    }
}