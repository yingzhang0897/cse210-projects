using System.Security.Cryptography.X509Certificates;

public class ReflectingActivity: Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    public ReflectingActivity(string name,string description,int duration):base(name,description,duration)
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else",
            "Think of a time when you did something really difficult",
            "Think of a time when you helped someone in need",
            "Think of a time when you did something truly selfless"
        };
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }
    
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int Index = random.Next(_prompts.Count());
        string RandomPrompt = _prompts[Index];
        //_prompts.RemoveAt(Index);//try to avoid repetition, but I don't know why
        return RandomPrompt;
    }
    public string GetRandomQuestion()
    {
        Random random = new Random();
        int Index = random.Next(_questions.Count);
        string RandomQuestion = _questions[Index];
        //_questions.RemoveAt(Index);//try to avoid repetition, but I don't know how
        return RandomQuestion;
    }
    public void DisplayPrompt()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"---{GetRandomPrompt()}---");
    }
    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
    }
    public void Run()
    {
        ReflectingActivity reflectingActivity = new ReflectingActivity("Reflecting","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",0);
        DisplayStartingMessage();
        GetReady();
        ShowSpinner();
        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.WriteLine("You may begin in: ");
        ShowCountDown();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while(DateTime.Now < endTime)
        {
            DisplayQuestions();
            ShowSpinner();
        }
        DisplayEndingMessage();
    }
}
