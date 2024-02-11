using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

//Exceeding:
class Program
{
   
    static void Main(string[] args)
    {
       
        while (true)
        {
            GoalManager goalManager = new GoalManager();
            goalManager.Start();
            int choice = int.Parse(Console.ReadLine());

            //use switch statements to achieve menu functionality neatly
           /* switch (choice)
            {
                case 1: //Create a goal
                    goalManager.CreateGoal();
                    break;
                case 2: //List goals
                    goalManager.ListGoalDetails();
                    break;
                case 3: //Save goals to File
                    goalManager.SaveGoals();
                    break;
                case 4://Load goals from File
                    goalManager.LoadGoals();
                    break;
                case 5://Record Event 
                    goalManager.RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                    break;
            }*/
            goalManager.CreateGoal();
            goalManager.CreateGoal();
            goalManager.CreateGoal();
            goalManager.ListGoalDetails();
            goalManager.SaveGoals();
            goalManager.LoadGoals();
            goalManager.RecordEvent();
    
        }
    }
}