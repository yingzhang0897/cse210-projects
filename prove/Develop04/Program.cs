//finished core requirement
//creativity: Keeping track of how many activities were performed.
using System;

class Program
{
    static void Main(string[] args)
    {
        int activityCount = 0;

        while(true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflecting Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            //Console.ReadLine();
            int choice = int.Parse(Console.ReadLine());
            Activity activity = null;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity("Breathing","This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",30);
                    break;
                case 2:
                    activity = new ReflectingActivity("Reflecting","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",30);
                    break;
                case 3:
                    activity = new ListingActivity("Listing","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",30);
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
            }
            //Keeping track of how many activities were performed.
            if (activity != null)
            {
                activityCount++;
                Console.WriteLine($"\nActivity #{activityCount}\n");
                if (activity is BreathingActivity breathingActivity)
                {
                    breathingActivity.Run();
                }else if(activity is ReflectingActivity reflectingActivity)
                {
                    reflectingActivity.Run();
                }else if(activity is ListingActivity listingActivity)
                {
                    listingActivity.Run();
                }
                Console.WriteLine("\n------------------------\n");
            }

        }
    }
}