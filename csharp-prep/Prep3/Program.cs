using System;


class Program
{
   
    static void Main(string[] args)
    {
       
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);
       // stretch challenge
        string playAgain = "yes";
        while (playAgain.ToLower() == "yes")
        {
            int guess = -1;
            int guessCount = 0;

            //loop until the user get the magic number
            while (guess != magicNumber)
            {
                Console.Write("Guess a number from 1 to 100: ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
            
            //check if the guess is correct
                if (guess == magicNumber)
                {
                    Console.WriteLine("\nYou guessed it! You used " + guessCount + " guesses!");
                }else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher!");
                }else 
                {
                    Console.WriteLine("Lower!");
                }
            }
            //ask the user whether they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string answer = Console.ReadLine();

            if (answer.ToLower() != "yes")
            {
                Console.WriteLine("\nSee you next time!");
            }
        }   
        
    }
}