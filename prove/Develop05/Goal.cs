public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }
    public abstract int RecordEvent();//mark that is has been accomplished another time;return the point value associated with recording the event
    public abstract bool IsComplete();//return true if the goal is completed.
    public virtual string GetDetailString() //include the checkbox, the short name, and description,in the case of the ChecklistGoal class, it should be overridden to shown the number of times the goal has been accomplished so far.
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }
    public abstract string GetStringRepresentation();//provide all of the details of a goal in a way that is easy to save to a file, and then load later.
   
}