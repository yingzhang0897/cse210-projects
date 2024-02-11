public class SimpleGoal : Goal
{
    private bool _isComplete;
   
    public SimpleGoal(string name, string description,int points): base(name,description,points)
    {
        _isComplete = false;
    }
    public override int RecordEvent()//mark that is has been accomplished another time;return the point value associated with recording the event
    {
       _isComplete = true;
       return _points;

    }
    
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()// returns a string containing the pieces of data that I need for my object
    {
       return $"SimpleGoal:{_name}|{_description}|{_points}|{_isComplete}";
    }

}