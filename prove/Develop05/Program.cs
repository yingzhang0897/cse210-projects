using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

//Exceeding:1. use "cases" instead of if statements in the main program
//2. use try/catch in the SaveToFile and LoadFromFile Function in Journal.cs
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
           // switch (choice)
            //{
               // case 1: //Create a goal

                  goalManager.CreateGoal();
                  goalManager.ListGoalNames();
                  goalManager.ListGoalDetails();
                  goalManager.SaveGoals();
                  //goalManager.LoadGoals();
                  //goalManager.RecordEvent();

                  /*  break;
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
    
        }
      //testing simpleGoal
        // SimpleGoal simpleGoal= new SimpleGoal("dance","dance 30 min",30);
        // Console.WriteLine(simpleGoal.IsComplete());
        //  Console.WriteLine(simpleGoal.RecordEvent());
        // Console.WriteLine(simpleGoal.IsComplete());
        // Console.WriteLine(simpleGoal.GetDetailString());
        // Console.WriteLine(simpleGoal.GetStringRepresentation());

        //testing eternalGoal
        // EternalGoal eternalGoal= new EternalGoal("apply gospel","everyday",30);
        // Console.WriteLine(eternalGoal.IsComplete());
        // Console.WriteLine(eternalGoal.RecordEvent());
        // Console.WriteLine(eternalGoal.IsComplete());
        // Console.WriteLine(eternalGoal.GetDetailString());
        // Console.WriteLine(eternalGoal.GetStringRepresentation());

         //testing checklistGoal
        // CheckListGoal checkListGoal= new CheckListGoal("go to temple","regularly",30,50,3);

        // Console.WriteLine(checkListGoal.RecordEvent());
        // Console.WriteLine(checkListGoal.IsComplete());
        // Console.WriteLine(checkListGoal.RecordEvent());
        // Console.WriteLine(checkListGoal.IsComplete());
        // Console.WriteLine(checkListGoal.RecordEvent());
        // Console.WriteLine(checkListGoal.IsComplete());
       
        // Console.WriteLine(checkListGoal.GetDetailString());
        // Console.WriteLine(checkListGoal.GetStringRepresentation());
    }
}