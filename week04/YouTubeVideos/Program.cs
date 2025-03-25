 using System;
using System.Collections.Generic;

// Comment class to store comment details
class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}

// Video class to store video details and associated comments
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.Author}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

// Main program
class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        // Creating video instances
        Video video1 = new Video("Introduction to C#", "Tech Guru", 600);
        Video video2 = new Video("Advanced C# Concepts", "Code Master", 1200);
        Video video3 = new Video("C# for Beginners", "Dev Ninja", 900);

        // Adding comments to video1
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "I learned a lot."));

        // Adding comments to video2
        video2.AddComment(new Comment("Dave", "Well presented!"));
        video2.AddComment(new Comment("Emma", "Can you make a video on LINQ?"));
        video2.AddComment(new Comment("Frank", "Excellent content!"));

        // Adding comments to video3
        video3.AddComment(new Comment("George", "Very clear explanation."));
        video3.AddComment(new Comment("Hannah", "This is exactly what I needed."));
        video3.AddComment(new Comment("Ian", "Great work!"));

        // Adding videos to list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Displaying videos and their comments
        foreach (var video in videos)
        {
            video.Display();
        }
    }
}
