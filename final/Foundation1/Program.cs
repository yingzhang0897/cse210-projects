//The abstraction is displayed in 3 class:
//class Comment: be responsible for all the comments info;
//class Video: be responsible for all the videos info and include a list<Comment>;
//program.cs: create a list<Video> and set values into each video object and each comment object;

using System;
using System.Collections.Generic;

public class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string commenterName, string commentText)
    {
        _commenterName= commenterName;
        _commentText = commentText;
    }
    public string GetName()
    {
        return _commenterName;
    }
    public string GetText()
    {
        return _commentText;
    }
}

public class Video
{
    private  string _title;
    private  string _author;
    private  int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments= new List<Comment>();
    }

    public void AddComment(string commenterName, string commentText)
    {
        _comments.Add(new Comment(commenterName,commentText));
    }

    public int GetNumComments()
    {
        return _comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("Title: " + _title);
        Console.WriteLine("Author: " +_author);
        Console.WriteLine("Length: " + _length+ " seconds");
        Console.WriteLine("Number of comments: " + GetNumComments());
        Console.WriteLine("Comments:");
        foreach (Comment comment in _comments)
        {
            Console.WriteLine("  - " + comment.GetName() + ": " + comment.GetText());
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating videos
        List<Video> videos = new List<Video>
        {
            new Video("Video 1", "Author 1", 120),
            new Video("Video 2", "Author 2", 180),
            new Video("Video 3", "Author 3", 150)
        };

        // Adding comments to videos
        videos[0].AddComment("User1", "Great video!");
        videos[0].AddComment("User2", "Very informative.");
        videos[0].AddComment("User3", "Boring.");


        videos[1].AddComment("User4", "Awesome content!");
        videos[1].AddComment("User5", "I enjoyed watching it.");
        videos[1].AddComment("User6", "I didn't like it.");

        videos[2].AddComment("User7", "I am touched by this video!");
        videos[2].AddComment("User8", "Who is here 2024?");
        videos[2].AddComment("User9", "Thanks for making this video!");

        // Displaying video information
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}
