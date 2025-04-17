 // File: Utils/AnimationHelper.cs
using System;
using System.Threading;

namespace MindfulnessApp.Utils
{
    public static class AnimationHelper
    {
        public static void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            for (int i = 0; i < seconds * 4; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }

        public static void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}