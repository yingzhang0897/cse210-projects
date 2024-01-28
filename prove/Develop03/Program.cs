using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Reference reference = new Reference("Alma", 34, 17);
        Scripture scripture = new Scripture(reference, "Therefore may God grant unto you, my brethren,that ye may begin to exercise your faith unto repentance,  that ye begin to call upon his holy name,that he would have mercy upon you;");
        scripture.GetDisplayText();
        do
        {
            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();
        } while (!scripture.AllWordsHidden());



    }
}



