public class CheckListGoal : Goal
{
    private int _amountComplete;
    private int _target;
    private int _bonus;
    private List<string> _subGoals;
    public CheckListGoal(string name,string description, string points, int target, int bonus):base(name,description,points)
    {
       _target = target;
       _bonus = bonus;
    }
     public override void RecordEvent()
    {
        
    }
    public override bool IsComplete()
    {
        return true;
    }
    public override string GetDetailString()
    {
        return " ";
    }
    public override string GetStringRepresentation()
    {
       return " ";
    }
    

}