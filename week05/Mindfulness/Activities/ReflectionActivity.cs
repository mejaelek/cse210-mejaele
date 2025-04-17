 // File: Activities/ReflectionActivity.cs
using System;
using System.Collections.Generic;
using MindfulnessApp.Utils;

namespace MindfulnessApp.Activities
{
    public class ReflectionActivity : Activity
    {
        private List<string> prompts = new()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        protected override string GetDescription() =>
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        protected override void PerformActivity()
        {
            Random rand = new();
            Console.WriteLine($"\n{prompts[rand.Next(prompts.Count)]}\n");
            AnimationHelper.ShowSpinner(5);

            int interval = 5;
            for (int time = 0; time < duration; time += interval)
            {
                Console.WriteLine($"> {questions[rand.Next(questions.Count)]}");
                AnimationHelper.ShowSpinner(interval);
            }
        }
    }
}