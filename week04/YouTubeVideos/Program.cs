using System;
using System.Collections.Generic;

class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in Comments)
        {
            Console.WriteLine($"  - {comment.Commenter}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Video video1 = new Video("C# Tutorial", "Roscent Nkemjika Ofuonye", 200);
        Video video2 = new Video("Birthday Celebration", "Roscent", 720);
        
        video1.AddComment(new Comment("Becky", "Great tutorial!"));
        video1.AddComment(new Comment("Prince", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Bliss", "I learned a lot!"));

        video2.AddComment(new Comment("Dave", "Happy Birthday!"));
        video2.AddComment(new Comment("Eve", "Mind-blowing Moment."));
        video2.AddComment(new Comment("Frank", "More Years ahead"));

        List<Video> videos = new List<Video> { video1, video2 };

        foreach (var video in videos)
        {
            video.Display();
        }
    }
}
