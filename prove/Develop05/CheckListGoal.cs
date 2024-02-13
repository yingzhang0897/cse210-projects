public class CheckListGoal : Goal
{
    private int _amountComplete; 
    private int _target;
    private int _bonus;

    public CheckListGoal(string name,string description, int points,int bonus, int amountComplete, int target):base(name,description,points)
    {
       _bonus = bonus;
       _amountComplete = amountComplete;
       _target = target;
    }


     public override int RecordEvent()//mark that is has been accomplished another time;return the point value associated with recording the event
    {
        _amountComplete++;
        int totalPointsEarned = _points; // Points earned without considering bonus
    
        if (_amountComplete == _target)
        {
            _isComplete = true;
            totalPointsEarned += _bonus; // Add bonus if the target is reached
        }
        
        return totalPointsEarned;

    }

    public override  bool IsComplete()
    {
        if( _amountComplete == _target)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public override string GetDetailString()//include the checkbox, the short name, and description,and the number of times the goal has been accomplished so far.
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {base.GetDetailString()}) -- Currently accomplished {_amountComplete}/{_target} times";
    }
    public override string GetStringRepresentation()//provide all of the details of a goal in a way that is easy to save to a file, and then load later.
    {
       return $"CheckListGoal:{_name}|{_description}|{_points}|{_bonus}|{_amountComplete}|{_target}";
    }
}