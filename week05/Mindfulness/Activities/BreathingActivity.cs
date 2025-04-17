 // File: Activities/BreathingActivity.cs
using System;
using MindfulnessApp.Utils;

namespace MindfulnessApp.Activities
{
    public class BreathingActivity : Activity
    {
        protected override string GetDescription() =>
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

        protected override void PerformActivity()
        {
            int interval = 5;
            for (int time = 0; time < duration; time += interval * 2)
            {
                Console.Write("\nBreathe in... ");
                AnimationHelper.Countdown(interval);
                Console.Write("Now breathe out... ");
                AnimationHelper.Countdown(interval);
            }
        }
    }
}