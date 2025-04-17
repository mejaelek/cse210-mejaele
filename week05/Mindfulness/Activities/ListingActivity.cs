 // File: Activities/ListingActivity.cs
using System;
using System.Collections.Generic;
using MindfulnessApp.Utils;

namespace MindfulnessApp.Activities
{
    public class ListingActivity : Activity
    {
        private List<string> prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        protected override string GetDescription() =>
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        protected override void PerformActivity()
        {
            Random rand = new();
            Console.WriteLine($"\n{prompts[rand.Next(prompts.Count)]}\n");
            AnimationHelper.Countdown(5);

            Console.WriteLine("Start listing items:");
            List<string> items = new();
            DateTime end = DateTime.Now.AddSeconds(duration);
            while (DateTime.Now < end)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }

            Console.WriteLine($"\nYou listed {items.Count} items!");
        }
    }
}