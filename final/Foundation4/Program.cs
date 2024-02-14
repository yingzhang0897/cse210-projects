//this program include a base class Activity and three derived classes: Running, StationaryBicycle, Swimming
//basically it is about calculating speed, pace, and displaying records of each activity
//the point is using polymorphism in program.cs by adding all activities into the same list and call the same function but achieving different behaviors
using System;

// Base Activity class
public abstract class Activity
{
    protected DateTime _date;
    protected int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }
   

    public abstract double GetSpeed();
   

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date.ToShortDateString()} {GetType().Name} ({_minutes} min)";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetSpeed()
    {
        return _distance / _minutes * 60;
    }

    public override double GetPace()
    {
        return _minutes / _distance;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {_distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

// Derived class for Stationary Bicycles
public class StationaryBicycle : Activity
{
    private double _speed;

    public StationaryBicycle(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {_speed} mph, Pace: {GetPace()} min/mile";
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public double GetDistance()
    {
        return _laps * 50 / 1000 * 0.62; // Convert meters to miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / _minutes * 60;
    }

    public override double GetPace()
    {
        return Math.Round(_minutes /GetDistance(),2);
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Put each activity in the same list
       List<Activity> activities = new List<Activity>
       {
            new Running(new DateTime(2023, 11, 3), 30, 3.0),
            new StationaryBicycle(new DateTime(2024, 1, 4), 45, 15.0),
            new Swimming(new DateTime(2024, 2, 14), 60, 20)
       };

        // Iterate through the list and call GetSummary method on each item
        foreach (Activity activity in activities)
        {
            Console.WriteLine();
            Console.WriteLine(activity.GetSummary());
        }
    }
}
