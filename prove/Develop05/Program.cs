//finished core requirement
//creativity: Keeping track of how many activities were performed.
using System;

class Program
{
    static void Main(string[] args)
    {
       
       
        while(true)
        {
            Console.WriteLine("You have {} points.");
             //design main menu
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");// for eternal goals that are never complete, but each time the user records them, they gain some value.
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            int choice = int.Parse(Console.ReadLine());

            // Declare a list called _goals containing instances of the base class Goal
            List<Goal> _goals = new List<Goal>();
            // Add some instances of the derived classes to the list
            _goals.Add(new SimpleGoal("Learn C#", new DateTime(2023, 12, 31)));
            _goals.Add(new EternalGoal("Be happy"));
            _goals.Add(new CheckListGoal("Travel the world", new List<string> { "Visit Japan", "See the Eiffel Tower", "Go to Disneyland" }));
            // Show a loop iterating over the _goals list calling Display on each Goal
            foreach (Goal goal in _goals)
            {   
                goal.Display();  
                Console.WriteLine();
            }
           
            //Activity activity = null;
            switch (choice)
            {
                case 1:
                   
                    break;
                case 2:
                   
                    break;
                case 3:
                  
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    
                    Environment.Exit(0);
                    break;
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
            
            /*if (activity != null)
            {
                if (activity is BreathingActivity breathingActivity)
                {
                    breathingActivity.Run();
                    breathingActivityCount++;

                }else if(activity is ReflectingActivity reflectingActivity)
                {
                    reflectingActivity.Run();
                    reflectingActivityCount++;
                }else if(activity is ListingActivity listingActivity)
                {
                    listingActivity.Run();
                    listingActivityCount++;
                }
                Console.WriteLine("\n------------------------\n");
            }*/

        }
    }
}