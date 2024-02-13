using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class GoalManager 
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

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

        Console.Write("Select a choice from the menu: \n");
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
                _goals.Add(new SimpleGoal(name,description,points,false));
                break;
            case 2:
                _goals.Add(new EternalGoal(name,description,points));
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplinished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());   
                _goals.Add(new CheckListGoal(name,description,points,bonus,0,target));
                break;
        }
    }


    public void ListGoalNames()//Lists the names of each of the goals,prepare for recording event
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            string stringRepresentation = _goals[i].GetStringRepresentation();
            string[] parts = stringRepresentation.Split(':');
            string goalName = parts[0];
            Console.WriteLine($"{i + 1}. {goalName}");
        }
    }


    public void ListGoalDetails()//Lists the details of each goal (including the checkbox of whether it is complete, name of the goal, short description, and in the case of check list goal, add" -- currently accomplished int/ int times" )
    {
        System.Console.WriteLine("Starting to Display List Goal");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. { _goals[i].GetDetailString()}");
            if (_goals[i].IsComplete())
            {
                TriggerFireworksAnimation();
            }
        }
    }


    public void SaveGoals()//save the list of goals into a file
    {
        Console.Write("Enter the name of the file to save: ");
        string fileName = Console.ReadLine();
        try
        {
            using(StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_score);
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


    public void LoadGoals()//Loads the list of goals from a file
    {
        Console.Write("Enter the name of the file to load: ");
        string fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(':');
            string goalName = parts[0];
            string goalDetail = parts[1];
            string[] parts2 = goalDetail.Split('|');
            string name = parts2[0];
            string description = parts2[1];
            int points = int.Parse(parts2[2]);
            switch (goalName)
            {
                case "EternalGoal":
                    _goals.Add(new EternalGoal(name,description,points));
                    break;
                case "SimpleGoal":
                    bool isComplete = bool.Parse(parts2[3]);
                    _goals.Add(new SimpleGoal(name,description,points,isComplete));
                    break;
                case "CheckListGoal":
                    int bonus = int.Parse(parts2[3]);
                    int amountComplete = int.Parse(parts2[4]);
                    int target = int.Parse(parts2[5]);
        
                    _goals.Add(new CheckListGoal(name,description,points,bonus,amountComplete,target));
                    break;
            }
        }  
        Console.WriteLine($"Goal loaded from {fileName} successfully. ");
    }


    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish? Choose from 1,2,3: ");
        ListGoalNames();
        // get the score of that accomplished goal
        int index = int.Parse(Console.ReadLine())-1;
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
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


    public void TriggerFireworksAnimation()
    {
        Console.WriteLine(); 

        Console.WriteLine("Congratulations! Goal Complete!");
        Console.WriteLine();

        // ASCII art fireworks animation
        Console.WriteLine(@"   
            *  .  *   .      .     *          .      .   *   .
    .   *       .    *   .    *       .     .    *   .      .
        .     *       .    * .   .    .    .   *  .    .    *   .   *   .
    *   .    *  .     *     .    .    *    .    .    *    .   *   .
    .     .    *   .   *  .    .     *       .    *    .    *   .
            .   *   .    *       .    *    .     *        .    *   .
    *   .   *   .    *   .  *   .       .   *   .    *    .   *   . *   .
        .     *         .     *     .    .  *   .    *    .  *   .
    .      *    .    *   .     .    .    *     .    *    .    *   .
        .    *   .    *     .    *   .    *    .    *   .    *   .   *
    .     *   .    .   *   .    *    .   *   .    *    .   *   .
    *   .    *    .    *    .  *   .  *   .    *   .    *    . *   .
    .      .  *    .     *       .     *   .    *    .    *   .");
    
    Console.WriteLine();
    }

}