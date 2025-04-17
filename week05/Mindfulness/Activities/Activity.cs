  // File: Activities/Activity.cs
using System;
using System.Threading;
using MindfulnessApp.Utils;

namespace MindfulnessApp.Activities
{
    public abstract class Activity
    {
        protected int duration;

        public void Run()
        {
            DisplayStartingMessage();
            PerformActivity();
            DisplayEndingMessage();
        }

        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {GetType().Name}.");
            Console.WriteLine(GetDescription());
            Console.Write("Enter the duration (seconds): ");
            duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Get ready...");
            AnimationHelper.ShowSpinner(3);
        }

        protected void DisplayEndingMessage()
        {
            Console.WriteLine("\nGreat job!");
            Console.WriteLine($"You have completed {duration} seconds of the {GetType().Name}.");
            AnimationHelper.ShowSpinner(3);
        }

        protected abstract string GetDescription();
        protected abstract void PerformActivity();
    }
}
