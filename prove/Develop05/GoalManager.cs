using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class GoalManager 
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

//    public  Goal goal = 
//    {
//         _goals = goals ;
//         _score = 0;
//    }
   public void Start()//runs the menu loop
   {
       // Console.WriteLine("You have {score} points.\n");
        //design main menu
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");// for eternal goals that are never complete, but each time the user records them, they gain some value.
        Console.WriteLine("  6. Quit");

        Console.Write("Select a choice from the menu: ");
   }
   public void CreateGoal()//Asks the user for the information about a new goal. Then, creates the goal and adds it to the list
   {
        Console.WriteLine("The types of goals are: ");
        Console.WriteLine("  1.Simple Goal");
        Console.WriteLine("  2.Eternal Goal");
        Console.WriteLine("  3.CheckList Goal");
        Console.Write("What type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points of this goal? ");
        int points = int.Parse(Console.ReadLine());
        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name,description,points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name,description,points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplinished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());   
                _goals.Add(new CheckListGoal(name,description,points,bonus,target));
                break;
        }
    }
        public void ListGoalNames()//Lists the names of each of the goals,prepare for recording event
        {
            foreach (Goal goal in _goals)
            {
                string stringRepresentation = goal.GetStringRepresentation();
                string[] parts = stringRepresentation.Split(':');
                string goalName = parts[0];
                for(int i = 0;i < _goals.Count; i++)
                {
                   
                    Console.WriteLine($"{i+1}. {goalName}");
                }
            }
        }
        public void ListGoalDetails()//Lists the details of each goal (including the checkbox of whether it is complete, name of the goal, short description, and in the case of check list goal, add" -- currently accomplished int/ int times" )
        {
            System.Console.WriteLine("Starting to Display List Goal");
            foreach (Goal goal in _goals)//not working
            {
                Console.WriteLine(goal.GetDetailString());
            }
        }
        public void SaveGoals()//save the list of goals into a file
        {
           Console.Write("Enter the name of the file to save: ");
            string fileName = Console.ReadLine();
            Console.WriteLine("Saving goals to file...");
            try
            {
                using(StreamWriter outputFile = new StreamWriter(fileName))
                {
                    foreach (Goal goal in _goals)
                    {
                        outputFile.WriteLine(goal.GetStringRepresentation());
                    }  
                } 
                Console.WriteLine($"Goals saved to {fileName} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving Goals to file: {ex.Message}");
            } 
        }
        // public void LoadGoals()//Loads the list of goals from a file
        // {
        //     Console.Write("Enter the name of the file to load: ");
        //     string fileName = Console.ReadLine();
        //     string[] lines = System.IO.File.ReadAllLines(fileName);

        //         List<string> lines = new List<string>();
        //         foreach (Goal goal in _goals)
        //         {
        //             lines.Add(goal.GetStringRepresentation());
        //         }

// Now stringRepresentations contains the string representations of each goal

                        
               
            }
                
        }
            
        
        public void RecordEvent()
        {
          
            Console.WriteLine("Which goal did you accomplish?");
            Console.WriteLine("  1. SimpleGoal");
            Console.WriteLine("  2. EetrnalGoal");
            Console.WriteLine("  3. CheckListGoal");

            // get the score of that accomplished goal
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < _goals.Count)
            {
                Goal goal = _goals[index];
                int pointsEarned = goal.RecordEvent();
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            }
            else
            {
                Console.WriteLine("Please choose from 1,2,3: ");
            }

        }
        public void DisplayPlayerInfo()//Displays the players current score.
        {
            Console.WriteLine($"You now have {_score} points.");
        }
}