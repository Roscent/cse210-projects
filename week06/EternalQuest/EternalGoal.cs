class EternalGoal : Goal
{
    public EternalGoal (string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent(ref int score)
    {
        score += Points;
    }

    public override string GetProgress()
    {
        return "[~] Ongoing";
    }
}