// Class to represent a scripture reference (e.g., "John 3:16")
class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse reference (e.g., "John 3:16")
    public Reference(string book, int chapter, int startVerse)
    {
       _book = book;
       _chapter = chapter;
       _startVerse = startVerse;
    }

    // Constructor for a verse range reference (e.g., "Proverbs 3:5-6")
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
       _book = book;
       _chapter = chapter;
       _startVerse = startVerse;
       _endVerse = endVerse;
    }

   public string GetDisplayText()
   {
        return $"{_book} {_chapter}: {_startVerse} - {_endVerse}";
   }
}

