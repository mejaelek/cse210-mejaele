using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Recognition;

public class Journal
{
    private List<Entry> entries = new List<Entry>();
    private PromptGenerator promptGenerator = new PromptGenerator(); // Use dynamic prompts

    public void WriteEntry()
    {
        promptGenerator.DisplayCategories();
        Console.Write("\nSelect a category for your prompt: ");
        string category = Console.ReadLine();

        string prompt = promptGenerator.GetRandomPrompt(category);
        Console.WriteLine($"Prompt: {prompt}");

        if (prompt.StartsWith("Invalid"))
        {
            Console.WriteLine("Please enter a valid category.\n");
            return;
        }

        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Console.WriteLine("Select your mood: (Happy, Sad, Excited, Angry, Calm, Anxious)");
        string mood = Console.ReadLine();

        entries.Add(new Entry(prompt, response, mood));
        Console.WriteLine("Entry added with mood tracking!\n");
    }

    public void WriteEntryWithVoice()
    {
        promptGenerator.DisplayCategories();
        Console.Write("\nSelect a category for your prompt: ");
        string category = Console.ReadLine();

        string prompt = promptGenerator.GetRandomPrompt(category);
        Console.WriteLine($"Prompt: {prompt}");

        if (prompt.StartsWith("Invalid"))
        {
            Console.WriteLine("Please enter a valid category.\n");
            return;
        }

        SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
        recognizer.SetInputToDefaultAudioDevice();
        recognizer.LoadGrammar(new DictationGrammar());

        Console.WriteLine("Speak now...");
        string response = "";
        recognizer.SpeechRecognized += (s, e) => response = e.Result.Text;
        recognizer.Recognize();

        Console.WriteLine($"Recognized Speech: {response}");
        Console.WriteLine("Select your mood: (Happy, Sad, Excited, Angry, Calm, Anxious)");
        string mood = Console.ReadLine();

        entries.Add(new Entry(prompt, response, mood));
        Console.WriteLine("Entry added using voice input!\n");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        Console.WriteLine("\n📝 Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveJournal()
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Mood}|{entry.Prompt}|{entry.Response}");
            }
        }

        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadJournal()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!\n");
            return;
        }

        entries.Clear();
        foreach (var line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split('|');
            if (parts.Length == 4)
            {
                entries.Add(new Entry(parts[2], parts[3], parts[1]));
            }
        }

        Console.WriteLine("Journal loaded successfully!\n");
    }
}

