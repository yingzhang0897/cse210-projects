using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //read scriptures from a file
        string filePath = "sources.txt";
        string[] lines = File.ReadAllLines(filePath);
        Random random = new Random();
        int randomIndex = random.Next(lines.Length);
        string randomLine = lines[randomIndex];

        //parse random line into book, chapter, startVerse, endVerse, text by the 1st space and 2nd space
        int firstSpaceIndex = randomLine.IndexOf(" ");
        int secondSpaceIndex = randomLine.IndexOf(" ",firstSpaceIndex + 1);
        string book = randomLine.Substring(0,firstSpaceIndex);
        int chapter = int.Parse(randomLine.Substring(firstSpaceIndex +1 , 2));
        int startVerse = int.Parse(randomLine.Substring(firstSpaceIndex + 4, 2));
        //int endVerse = int.Parse(randomLine.Substring(firstSpaceIndex + 6, 2));
        string text = randomLine.Substring(secondSpaceIndex + 1);

        Console.WriteLine(randomLine);
        
        do
        {
            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }
            Reference reference = new Reference(book,chapter,startVerse);
           // Reference reference2 = new Reference(book,chapter, startVerse,endVerse);
            Scripture scripture = new Scripture(reference,text);
            scripture.HideRandomWords();
        } while (!randomLine.Contains(" "));



    }
}



