using System.Runtime.CompilerServices;

public class ListingActivity: Activity
{
    private int _count;
    private List<string> _prompts;
   
   public ListingActivity(string name, string description, int duration): base(name,description,duration)
   {
        _count = 0;
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
   }
    public string GetRandomPrompt()
    { 
        Random random = new Random();
        string RandomPrompt = _prompts[random.Next(_prompts.Count)];
        //_prompts.RemoveAt(random.Next(_prompts.Count));//try to avoid repetition but I don't know how
        return RandomPrompt;
    }
    public List<string> GetListFromUser()
    {
        List<string> userResponses = new List<string>();
       
        string response = Console.ReadLine();
        userResponses.Add(response);
        
        return userResponses;
       
    }
    public void Run()
    {
        ListingActivity listingActivity = new ListingActivity("Listing","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",0);
        DisplayStartingMessage();
        GetReady();
        ShowSpinner();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"---{GetRandomPrompt()}---");
        Console.WriteLine("You may begin in: ");
        ShowCountDown();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        while(DateTime.Now < endTime)
        {
            List<string> userResponses = GetListFromUser();
            _count += userResponses.Count;
        }
        
        Console.WriteLine($"You listed {_count} items");
        DisplayEndingMessage();
    }
   
        




}