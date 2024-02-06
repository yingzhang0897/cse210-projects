
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
class Scripture
{
    protected Reference _reference;
    protected List<Word> _words = new List<Word>();
    //constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        //call a method to get a list of word objects
        TurnTextInToList(text);
    }
    //use a method to turn text into a list of word objects
    public List<Word> TurnTextInToList(string text)
    {
        // Split text by space 
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));//use Word constructor to add each word object into List<Word>
        }
        return _words;

    }
    
    // Hide three words at a time until all words are hidden
    public void HideRandomWords()
    {
        Random random = new Random();
    
        // Find three unique indices of words to hide
        HashSet<int> indicesToHide = new HashSet<int>(); // Using HashSet for faster lookup
        while (indicesToHide.Count < 3)
        {
            int randomIndex = random.Next(_words.Count);
            if (!_words[randomIndex].IsHidden()) // Ensure the word isn't already hidden
            {
                indicesToHide.Add(randomIndex); // Add the index to the set
            }
        }
        // Hide the selected words
        foreach (int index in indicesToHide)
        {
            _words[index].Hide();
        }
    
    }

    //check if all words are hidden
    public bool AllWordsHidden()
    {
       foreach(Word word in _words)
       {
            if( !word.IsHidden())
            {return false;}
       }
       return true;
        
    }
    //display scripture     
    public void DisplayScripture()
    {
        Console.Clear(); // Clear the console before displaying the scripture
        _reference.DisplayReference();

        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayWord()+ " ");
        }

        Console.WriteLine();
    }

}