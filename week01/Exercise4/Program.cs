 using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Step 1: Collect user input
        while (true)
        {
            Console.Write("Enter number: ");
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                if (num == 0) break;
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        // Check if the list is empty to avoid errors
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered. Exiting program.");
            return;
        }

        // Step 2: Compute required values
        int sum = numbers.Sum();
        double average = numbers.Average();
        int maxNumber = numbers.Max();
        
        // Step 3: Display results
        Console.WriteLine($"\nThe sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {maxNumber}");

        // Stretch Challenges
        // Find the smallest positive number
        int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        if (smallestPositive > 0) Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Sort and display the sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers) Console.WriteLine(num);
    }
}
