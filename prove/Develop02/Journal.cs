using System;
using System.IO;
using System.Collections.Generic;
public class Journal
{
    public  List<Entry> _entries = new List<Entry>();

    //Add entry
    public void AddEntry()
    {
        
        Entry newEntry = new Entry();
        string _date = newEntry.Date();
        
        string _prompt = newEntry.Prompt();
        Console.WriteLine(_prompt);
        string _response = newEntry.Response();
        
        
       _entries.Add(newEntry);
       
    }
        
    //Display Entry
    public void DisplayEntry()

    {
        foreach (Entry entry in _entries)
        {   
            Console.WriteLine($"Date: {entry._date}-Prompt: {entry._prompt}\nResponse: {entry._response}\n");
        }
    }
    //Save to File
    public void SaveToFile(string fileName)
    {
        Console.WriteLine("Saving to file...");
        try
        {
            using(StreamWriter outputFile = new StreamWriter(fileName))
            {
                
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
                }
            }   
            Console.WriteLine($"Journal saved to {fileName} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving Journal to file: {ex.Message}");
        } 

    }
    //Load from File
    public void  LoadFromFile(string fileName)
    {
        Console.WriteLine("Reading from file...");
        try 
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while(!reader.EndOfStream)
                {
                    string[] entryData = reader.ReadLine().Split("|");
                    string date = entryData[0];
                    string prompt = entryData[1];
                    string response = entryData[2];
                    Entry loadedEntry = new Entry();
                    loadedEntry._date = date;
                    loadedEntry._prompt = prompt;
                    loadedEntry._response = response;
                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine($"Journal loaded from {fileName} successfully. ");      
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading Journal from file: {ex.Message}");
        }
      
    }
}
