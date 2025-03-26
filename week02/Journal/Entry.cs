using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; }

    public Entry(string prompt, string response, string mood)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public override string ToString()
    {
        return $"📅 Date: {Date}\n💬 Prompt: {Prompt}\n✍ Response: {Response}\n😊 Mood: {Mood}\n";
    }
}
 