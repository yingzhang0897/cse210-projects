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
                case 1: //Write Entry

                   journal.AddEntry();

                    break;
                case 2: //Display Entry
                    journal.DisplayEntry();

                    break;
                case 3: //Save to File
                
                    Console.WriteLine("Enter a filename to save the Journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    break;
                case 4://Load from File
                    Console.WriteLine("Enter a filename to load the Journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName);
                    break;
                case 5://Exit program
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