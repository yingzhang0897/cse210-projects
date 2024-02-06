
//creativity1: read from an external file to get a scripture
//creativity2: select words that are not hidden yet to hide
class Program
{
    static void Main()
    {
       //read from a file and get a random line(include reference and text)
        ScriptureProcessor processor = new ScriptureProcessor(); 
        string randomLine = processor.GetLineFromFile("sources.txt");//read from my local file and get a random line
        Console.WriteLine(randomLine);

        // then get the text part from the random line
        string text = processor.GetText(randomLine);
        //then get the reference part from the random line

        //get instances of reference and scripture
        Reference reference = processor.GetReference(randomLine);
        Scripture scripture = new Scripture(reference,text);

        
        // main program
        while (true)
        {
            Console.WriteLine("Please press Enter to continue hiding words or type 'quit' to finish:");
            string userInput = Console.ReadLine();
    
            if (userInput.ToLower() == "quit")
            {
                // User typed 'quit', end the program
                Console.WriteLine("Program ends.");
                break;
            }
            //keep hiding words until all words are hidden
            else
            {
                scripture.HideRandomWords();// Hide 3 random words in the scripture
                scripture.DisplayScripture();
                if(scripture.AllWordsHidden())
                {
                    // All words are hidden, end the program
                    Console.WriteLine("All words in the scripture are hidden. Program ends.");
                    break;
                }
            }
        }     
    }
}

