
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
        //call a method to get a lsit of word objects
        TurnTextInToList(text);
    }
    //use a method to turn text into a list of word objects
    public void TurnTextInToList(string text)
    {
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));//use Word cosntructor to add each word object into List<Word>
        }

    }
    //hide random words
    public void HideRandomWords(int numberOfWordsToHide)
{
    Random random = new Random();

    for (int i = 0; i < numberOfWordsToHide; i++)
    {
        int randomIndex = random.Next(_words.Count);
        _words[randomIndex].Hide();
    }
}


    //check if all words are hiddden
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
        Console.Write($"Scripture Reference: {_reference} ");

        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayWord());
        }

        Console.WriteLine();
    }

}