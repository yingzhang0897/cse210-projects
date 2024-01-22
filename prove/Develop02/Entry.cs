using System.Reflection.Metadata.Ecma335;

public class Entry
{
    public string _date;
    
    public string _prompt;
   
    public string _response;

    public string Date()
    {
        _date = DateTime.Now.ToShortDateString();
        return _date;
    }

    //use fuction "Prompt" to get random prompts from an array
    public string Prompt()
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
        return _prompt;
    }   
    
    
    //use fuction "Response" to get userResponse to that prompt
    public string Response()
    {
        _response = Console.ReadLine();
        return _response;
    }
    
   
    
    
}