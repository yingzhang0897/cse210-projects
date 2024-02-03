using System.ComponentModel.DataAnnotations;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name,string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine(_description);
        Console.WriteLine($"How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }
    public void GetReady()
    {
        Console.WriteLine("Get ready...");
    }
    public void ShowCountDown()
    {
        for(int i = 3; i>0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public void ShowSpinner()
    {
        List<string> strings = new List<string>();
        strings.Add("|");
        strings.Add("/");
        strings.Add("-");
        strings.Add("\\");
        strings.Add("|");
        strings.Add("/");
        strings.Add("-");
        strings.Add("\\");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(8);
        int i=0;
        while(DateTime.Now < endTime)
        {
            string s = strings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            i++; 
        }
         
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!\n");
        ShowSpinner();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity.\n");
        ShowSpinner();
    }

}