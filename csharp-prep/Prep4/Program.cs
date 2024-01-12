using System;
using System.Collections.Generic;
using System.Linq;




class Program
{
    static void Main(string[] args)
    {
        int userNumber = -1;
        List<int> userNumbers = new List<int>();
        while (userNumber != 0)
        { 
            Console.Write("Enter a number, type 0 to quit: ");
            userNumber = int.Parse(Console.ReadLine());
            if (userNumber != 0)
            {
                userNumbers.Add(userNumber);
            }
        }
        //sum
        int sum = userNumbers.Sum();
        Console.WriteLine($"The sum is: {sum}");
        //average
        float average = (float)sum/userNumbers.Count;
        Console.WriteLine($"The average is: {average}");
        //max
        int max = userNumbers[0];
        foreach (int i in userNumbers)
        {
            if (i > max)
            {
                max = i;
            }
        }
        Console.WriteLine($"The max number is: {max}");
        //stretch
        userNumbers.Sort();
        foreach( int i in userNumbers)
        {
            Console.WriteLine(i);
        }
       
    }

    
}