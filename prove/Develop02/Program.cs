using System;
using System.IO;
using System.Collections.Generic;

class Program
{
   
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("\nPlease choose one of the following choices: \n1. Write\n2. Display\n3. Save\n4. Load\n5. Quit");
            Console.Write("\nWhat would you like to do? ");
            int choice = int.Parse(Console.ReadLine());

            //use switch statements to achieve menu functionality neatly
            switch (choice)
            {
                case 1: //it works
                    string[] prompts = 
                    {"Who was the most interesting person I interacted with today?",
                        "What was the best part of my day?",
                        "How did I see the hand of the Lord in my life today?",
                        "What was the strongest emotion I felt today?",
                        "If I had one thing I could do over today, what would it be?"
                    };
                    Random random = new Random();
                    string _prompt = prompts[random.Next(prompts.Length)];
                    Console.WriteLine($"Prompt: {_prompt}");
                    string _response = Console.ReadLine();
                    journal.AddEntry();
                    break;
                case 2: //not working
                    Console.WriteLine("Displaying the Journal:\n");
                    journal.DisplayJournal();
                    break;
                case 3: //works
                    Console.WriteLine("Enter a filename to save the Journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                case 4://works
                    Console.WriteLine("Enter a filename to load the Journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                case 5://works
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
        }
        
    }
}