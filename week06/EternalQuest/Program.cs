// Eternal Quest Program
// Base structure fulfilling all core requirements
// Includes inheritance, polymorphism, encapsulation, file saving/loading, and creative gamification
// Creative features include:
// - Level system: Score determines player level (score / 1000 + 1)
// - Future support for badges and streaks (to be added in future expansions)
// - Motivational gamification elements to keep users engaged

using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    public abstract bool IsComplete { get; }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
    public abstract string SaveFormat();
}

class SimpleGoal : Goal
{
    private bool _complete;

    public override bool IsComplete => _complete;

    public SimpleGoal(string name, string description, int points, bool complete = false)
        : base(name, description, points)
    {
        _complete = complete;
    }

    public override int RecordEvent()
    {
        if (!_complete)
        {
            _complete = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => $"[{(IsComplete ? "X" : " ")}] {Name} ({Description})";
    public override string SaveFormat() => $"SimpleGoal|{Name}|{Description}|{Points}|{_complete}";
}

class EternalGoal : Goal
{
    public override bool IsComplete => false;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => Points;

    public override string GetStatus() => $"[∞] {Name} ({Description})";
    public override string SaveFormat() => $"EternalGoal|{Name}|{Description}|{Points}";
}

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;
    private int _bonusPoints;

    public override bool IsComplete => _completedCount >= _targetCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int completedCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _completedCount = completedCount;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            _completedCount++;
            if (IsComplete) return Points + _bonusPoints;
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => $"[{(IsComplete ? "X" : " ")}] {Name} ({Description}) -- Completed {_completedCount}/{_targetCount}";
    public override string SaveFormat() => $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_completedCount}|{_bonusPoints}";
}

class GoalManager
{
    private List<Goal> _goals = new();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int points = _goals[index].RecordEvent();
            _score += points;
            Console.WriteLine($"+{points} points! Total Score: {_score}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"\nTotal Score: {_score}");
        Console.WriteLine($"Level: {_score / 1000 + 1}");
    }

    public void SaveGoals(string filename)
    {
        using StreamWriter sw = new(filename);
        sw.WriteLine(_score);
        foreach (Goal g in _goals)
        {
            sw.WriteLine(g.SaveFormat());
        }
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename)) return;
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            switch (parts[0])
            {
                case "SimpleGoal":
                    AddGoal(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    AddGoal(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    AddGoal(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        GoalManager manager = new();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- Eternal Quest ---");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Show Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("Enter goal type (simple, eternal, checklist): ");
                    string type = Console.ReadLine().ToLower();
                    Console.Write("Name: "); string name = Console.ReadLine();
                    Console.Write("Description: "); string desc = Console.ReadLine();
                    Console.Write("Points: "); int points = int.Parse(Console.ReadLine());

                    if (type == "simple")
                    {
                        manager.AddGoal(new SimpleGoal(name, desc, points));
                    }
                    else if (type == "eternal")
                    {
                        manager.AddGoal(new EternalGoal(name, desc, points));
                    }
                    else if (type == "checklist")
                    {
                        Console.Write("Target count: "); int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus points: "); int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, points, target, 0, bonus));
                    }
                    break;
                case "2":
                    manager.ShowGoals();
                    break;
                case "3":
                    manager.ShowGoals();
                    Console.Write("Record which goal number? ");
                    int idx = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(idx);
                    break;
                case "4":
                    manager.ShowScore();
                    break;
                case "5":
                    manager.SaveGoals("goals.txt");
                    Console.WriteLine("Goals saved.");
                    break;
                case "6":
                    manager.LoadGoals("goals.txt");
                    Console.WriteLine("Goals loaded.");
                    break;
                case "7":
                    running = false;
                    break;
            }
        }
    }
}
