using System;

class Program
{
    static void Main(string[] args)
    {
        // core requirements
        Console.Write("What is your grade percentage? ");
        int grade = Convert.ToInt32(Console.ReadLine());
        string letter = "";
        if (grade >= 90)
        {
            letter = "A";
        }else if (grade >= 80)
        {
            letter = "B";
        }else if (grade >= 70)
        {
            letter = "C";
        }else if (grade >= 60)
        {
            letter = "D";
        }else
        {
            letter = "F";
        }
        /* avoid display repetion with the stretch challenge
        Console.WriteLine("Your grade letter is " + letter);
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }else
        {
            Console.WriteLine("Never give up! You can do it next time!");
        }*/
        //stretch challenge
        int lastDigit = grade % 10;
        string sign = "";
        if (lastDigit >7 && letter != "A" && letter != "F")
        {
            sign = "+";
        }else if (lastDigit <3 && letter != "F")
        {
            sign = "-";
        }else 
        {
            sign = "";
        }
        Console.WriteLine("\nYour grade letter is " + letter + sign);
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }else
        {
            Console.WriteLine("Never give up! You can do it next time!");
        }



    }
}