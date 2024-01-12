using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        double sqrNum = SquareNumber(userNumber);
        Displayresult(userName,sqrNum);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcoem to the Program!");
    }
    static string  PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int userNumber = int.Parse(Console.ReadLine());
        return userNumber;
    }
    static double SquareNumber(int userNumber)
    {
        double sqrNum = Math.Pow(userNumber,2);
        return sqrNum;
    }
    static void Displayresult(string userName,  double sqrNum)
    {
        Console.WriteLine($"{userName}, the square of your number is {sqrNum}");
    }
}