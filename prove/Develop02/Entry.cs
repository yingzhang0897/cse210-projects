using System.Reflection.Metadata.Ecma335;

public class Entry
{
    public string _date;
    //_prompt is private string because it is from a predesigned array
    private string _prompt;
    //_response is private string of which the value need to be attained by customized getter and setter
    private string _response;

    //use fuction "Prompt" to set customized getter and setter to get random prompts from an array
    public string Prompt
    {
        get {return _prompt;}
        set
        {
            //get random prompts from an array
            string[] prompts = 
            {"Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
            Random random = new Random();
            _prompt = prompts[random.Next(prompts.Length)];
        }   
    }
    
    //use fuction "Response" to set customized getter and setter to get userResponse to that prompt
    public string Response
    {
        get {return _response;}
        set
        {
            Console.WriteLine(_prompt);
            _response = Console.ReadLine();
        }
    }
   
    
    
}