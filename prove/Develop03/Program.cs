class Program
{
    static void Main()
    {
       
        ScriptureProcessor processor = new ScriptureProcessor(); 
        string randomLine = processor.GetLineFromFile("sources.txt");//read from my local file and get a random line
        Console.WriteLine(randomLine);

        
        // Hide words until all are hidden or the user types 'quit'
        while (true)
        {
            Console.WriteLine("Please press Enter to continue hiding words or type 'quit' to finish:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                // User typed 'quit', end the program
                Environment.Exit(0);
                break;
            }

            string text = processor.GetText(randomLine);//get the text part from the random line in file
            Reference reference = processor.GetReference(randomLine);//get the reference part ffrom the random line in file
            Scripture scripture = new Scripture(reference,text);
            scripture.HideRandomWords(3);// Hide 3 random words in the scripture
            scripture.DisplayScripture();

            if (scripture.AllWordsHidden())
            {
                // All words are hidden, end the program
                Console.WriteLine("All words in the scripture are hidden. Program ends.");
                Environment.Exit(0);
                break;
            }
        }
            
    }
}

