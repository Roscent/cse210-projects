class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount;
    private int Bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        Bonus = bonus;
    }

    public override void RecordEvent(ref int score)
    {
        if(!IsCompleted)
        {
            CurrentCount++;
            score += Points;
            if (CurrentCount >= TargetCount)
            {
                IsCompleted = true;
                score += Bonus;
            }
        }
    }
    public override string GetProgress()
    {
        return IsCompleted ? "[X] Completed" : $"[ ] Completed {CurrentCount}/{TargetCount}";
    }
}