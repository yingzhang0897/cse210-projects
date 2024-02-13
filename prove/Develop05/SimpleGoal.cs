public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description,int points, bool isComplete): base(name,description,points)
    {
        _isComplete = isComplete;
    }
    public override int RecordEvent()//mark that is has been accomplished another time;return the point value associated with recording the event
    {
       _isComplete = true;
       return _points;

    }

    
    public override string GetStringRepresentation()// returns a string containing the pieces of data that I need for my object
    {
       return $"SimpleGoal:{_name}|{_description}|{_points}|{_isComplete}";
    }

    public override string GetDetailString()
    {
        string checkbox = _isComplete ? "[X]" : "[ ]";
        return $"{checkbox} {base.GetDetailString()}";
    }

}