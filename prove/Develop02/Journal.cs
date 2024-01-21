using System;
using System.IO;
using System.Collections.Generic;
public class Journal
{
    private  List<Entry> _entries;

  //constructor for class Journal
    public Journal()
    {
        _entries = new List<Entry>();
    }
   // it has problems 
    public void AddEntry()
    {
        Entry newEntry = new Entry();
        _entries.Add(newEntry);
    }
    //it has problems
    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry._date}-Prompt: {entry.Prompt}\nResponse: {entry.Response}\n");
        }
    }
    //it works
    public void SaveToFile(string fileName)
    {
        Console.WriteLine("Saving to file...");
        try
        {
            using(StreamWriter outputFile = new StreamWriter(fileName))
            {
                List<Entry> _entries =new List<Entry>();
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date},{entry.Prompt},{entry.Response}");
                }
            }   
            Console.WriteLine($"Journal saved to {fileName} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving Journal to file: {ex.Message}");
        } 

    }
    //it works
    public void  LoadFromFile(string fileName)
    {
        Console.WriteLine("Reading from file...");
        try 
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while(!reader.EndOfStream)
                {
                    string[] entryData = reader.ReadLine().Split(",");
                    string _date = entryData[0];
                    string _prompt = entryData[1];
                    string _response = entryData[2];
                    Entry loadedEntry = new Entry();
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