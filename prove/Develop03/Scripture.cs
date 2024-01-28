
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    //constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        //create a fucntion for parameter text to get a lsit of words
        TurnTextInToList(text);
    }
    //use a method to turn text into a list of words
    public void TurnTextInToList(string text)
    {
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));//use Word cosntructor to create a list of Word objects
        }

    }
    //create method to hide random words from existing visible words
    public void HideRandomWords()
    {
        //creating a new list of visible word objects from list _words where isHidden is false
        var visibleWords = _words.FindAll(word => !word.IsHidden());
        if(visibleWords.Count == 0)
        {
            Environment.Exit(0);//exit the program when all words are hidden
        }
        //select from 3 or existing visible words randomly to hide
        Random random = new Random();
        int numberToHide = Math.Min(3,visibleWords.Count);
        for (int i = 0; i < visibleWords.Count; i++)
        {
            int randomIndex = random.Next(numberToHide);
            visibleWords[randomIndex].Hide();
        }
        //Display();  
    }
    //check if all words are hiddden
    public bool AllWordsHidden()
    {
        return _words.TrueForAll(word => word.IsHidden());
    }
    //display scripture
    public void GetDisplayText()
    {
        Console.Clear();
        Console.WriteLine($"{_reference.GetDisplayText()}\n");
        foreach (var word in _words)
        {
            Console.WriteLine(word.GetDisplayText()+ " ");
        }
        Console.WriteLine("\n");
    }
}