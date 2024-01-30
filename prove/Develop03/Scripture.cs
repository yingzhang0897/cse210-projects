
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
    //hide random words from existing visible words
    public void HideRandomWords()
    {
        Random random = new Random();
        int index1 = random.Next(_words.Count);
        int index2 = random.Next(_words.Count);
        //make sure two indexes are different
       do
       {
        _words[index1].Hide();
        _words[index2].Hide();
       } while(index2 != index1);
        
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
    public void GetDisplayText()
    {
        Console.Clear();
        Console.WriteLine($"{_reference.GetDisplayText()}\n");
        foreach (Word w in _words)
        {
            Console.WriteLine(w.GetDisplayText()+ " ");
        }
        Console.WriteLine("\n");
    }
}