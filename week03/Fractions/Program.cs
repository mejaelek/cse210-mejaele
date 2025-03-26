using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public static class ConsoleHelper
{
    public static void ClearScreen()
    {
        Console.Clear();
    }
}

public class ScriptureReference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int? endVerse;

    public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = endVerse;
    }
}
public class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        this.hidden = false;
    }

    public void Hide()
    {
        this.hidden = true;
    }
public class Scripture
{
    private ScriptureReference reference;
    private List<Word> words;
    private Random random = new Random();

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public bool IsFullyHidden()
    {
        return words.All(word => word.hidden);
    }

    public void Display()
    {
        ConsoleHelper.ClearScreen();
        Console.WriteLine("✨ Scripture Memorization ✨");
        Console.WriteLine("---------------------------");
        Console.WriteLine(reference);
        Console.WriteLine(string.Join(" ", words));
        Console.WriteLine("---------------------------");
    }

    public void HideRandomWords(int count = 2)
    {
        var visibleWords = words.Where(w => !w.hidden).ToList();
        if (visibleWords.Any())
        {
            var wordsToHide = visibleWords.OrderBy(x => random.Next()).Take(Math.Min(count, visibleWords.Count));
            foreach (var word in wordsToHide)
            {
                word.Hide();
            }
        }
    }

private static List<Scripture> LoadScripturesFromFile(string filename)
{
    var scriptures = new List<Scripture>();
    try
    {
        foreach (var line in File.ReadAllLines(filename))
        {
            var parts = line.Split('|');
            if (parts.Length == 2)
            {
                var refText = parts[0].Trim();
                var scriptureText = parts[1].Trim();
                var lastSpace = refText.LastIndexOf(' ');
                var book = refText.Substring(0, lastSpace);
                var chapterVerse = refText.Substring(lastSpace + 1);

                if (chapterVerse.Contains(':'))
                {
                    var chapterVerses = chapterVerse.Split(':');
                    var chapter = chapterVerses[0];
                    var verses = chapterVerses[1];

                    if (verses.Contains('-'))
                    {
                        var verseParts = verses.Split('-');
                        var reference = new ScriptureReference(book, int.Parse(chapter), int.Parse(verseParts[0]), int.Parse(verseParts[1]));
                        scriptures.Add(new Scripture(reference, scriptureText));
                    }
                }
            }
        }
    }
            catch (Exception)
            {
                // Handle any potential file reading errors
            }
            return scriptures;
        }
    public static void Main(string[] args)
    {
        var scriptures = Scripture.LoadScripturesFromFile("scriptures.txt");
        if (!scriptures.Any())
        {
            Console.WriteLine("No scriptures available. Exiting program.");
            return;
        }

        var random = new Random();
        var scripture = scriptures[random.Next(scriptures.Count)];
        
        while (true)
        {
            scripture.Display();
            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            var userInput = Console.ReadLine()?.Trim().ToLower();
            
            if (userInput == "quit")
            {
                Console.WriteLine("Thank you for using the Scripture Memorizer! 🙏");
                break;
            }

            scripture.HideRandomWords();
            if (scripture.IsFullyHidden())
            {
                scripture.Display();
                Console.WriteLine("Well done! You have memorized the scripture! 🎉");
                break;
            }
        }
    }
}

}
