using System.Diagnostics.Metrics;

public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description, int duration):base(name,description,duration)
    {}
    public void Run()
    {
        BreathingActivity breathingActivity = new BreathingActivity("Breathing","This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",0);
        DisplayStartingMessage();
        GetReady();
        ShowSpinner();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while(DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(); 
            Console.WriteLine("Now breathe out...");
            ShowCountDown();
        }
        DisplayEndingMessage();
    }    
}