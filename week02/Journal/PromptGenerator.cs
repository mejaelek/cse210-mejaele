using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private Dictionary<string, List<string>> promptCategories;

    public PromptGenerator()
    {
        promptCategories = new Dictionary<string, List<string>>
        {
            { "Motivational", new List<string> 
                {
                    "What is one goal you want to achieve this week?",
                    "What is something you are proud of today?",
                    "What is one challenge you overcame recently?",
                    "Who is someone that inspires you and why?",
                    "What is your biggest dream, and what steps can you take towards it?"
                } 
            },
            { "Reflection", new List<string> 
                {
                    "What was the best part of your day?",
                    "If you could relive today, what would you do differently?",
                    "What is something new you learned today?",
                    "What was a challenge you faced and how did you handle it?",
                    "Describe a recent moment that made you happy."
                } 
            },
            { "Gratitude", new List<string> 
                {
                    "What is something you are grateful for today?",
                    "Who in your life are you most thankful for, and why?",
                    "What is a simple pleasure that made you smile today?",
                    "What positive thing happened today that you want to remember?",
                    "Write about a kindness someone showed you recently."
                } 
            }
        };
    }

    public string GetRandomPrompt(string category)
    {
        if (promptCategories.ContainsKey(category))
        {
            Random rnd = new Random();
            List<string> selectedPrompts = promptCategories[category];
            return selectedPrompts[rnd.Next(selectedPrompts.Count)];
        }
        return "Invalid category. Please select from: Motivational, Reflection, or Gratitude.";
    }

    public void DisplayCategories()
    {
        Console.WriteLine("\n📂 Available Categories:");
        foreach (var category in promptCategories.Keys)
        {
            Console.WriteLine($"- {category}");
        }
    }
}
