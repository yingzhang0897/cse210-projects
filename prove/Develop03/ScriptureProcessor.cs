
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class ScriptureProcessor
{

    public string GetLineFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        Random random = new Random();
        int randomIndex = random.Next(lines.Length);
        string randomLine = lines[randomIndex];
        return randomLine;
    }
    public string GetText(string randomLine)
    {
        string[] parts = randomLine.Split(')');
        // Extract reference and text
        //string referencePart = parts[0].Trim('(', ' ');
        string textPart = parts[1].Trim();
        return textPart;
    }

    public Reference GetReference(string randomLine)
    {
        string[] parts = randomLine.Split(')');
        // Extract reference and text
        string referencePart = parts[0].Trim('(', ' ');
        //string textPart = parts[1].Trim();

        // Extract book, chapter, and verse
        string[] referenceParts = referencePart.Split(' ');

        // Extract book
        string book = referenceParts[0];

        // Extract chapterVerse part
        string chapterVerse = referenceParts[1];

        int chapter;

        // Split the chapterVerse into chapter and verse
        string[] chapterVerseParts = chapterVerse.Split(':');
        chapter = int.Parse(chapterVerseParts[0]);

        int startVerse ;
        int endVerse;

        // Check if the chapterVerse part contains a range
        if (chapterVerseParts[1].Contains('-'))
        {
            // If it's a range (e.g., Alma 34:22-23), extract start and end verses
            string[] verseRange = chapterVerseParts[1].Split('-');
            startVerse = int.Parse(verseRange[0]);
            endVerse = int.Parse(verseRange[1]);

            // Create a Reference object for verse range
            Reference referenceLong = new Reference(book, chapter, startVerse, endVerse);
            return referenceLong;
        }
        else
        {
            // If it's a single verse (e.g., Alma 34:19), parse it directly
            startVerse = int.Parse(chapterVerseParts[1]);

            // Create a Reference object for a single verse
            Reference referenceShort = new Reference(book, chapter, startVerse);
            return referenceShort;
        }
    }
    
}
