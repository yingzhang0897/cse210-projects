using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!!!");
        DateTime dateTime = DateTime.Now;
        string shortDateString = dateTime.ToShortDateString();
        Console.WriteLine(shortDateString);
       

    }
}