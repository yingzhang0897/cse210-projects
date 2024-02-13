public class EternalGoal : Goal
{
    public EternalGoal(string name,string description, int points):base(name,description,points)
    {

    }
    public override int RecordEvent()
    {
        return _points;
    }
    
    public override string GetStringRepresentation()//returns a string containing the pieces of data that I need for my object
    {
       return $"EternalGoal:{_name}|{_description}|{_points}";
    }

    public override string GetDetailString()
    {
        return "[ ] " + base.GetDetailString();
    }
}