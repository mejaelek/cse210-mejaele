 using System;

class Program
{
    static void Main()
    {
        // Step 1: Get user input
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        
        // Convert input to integer
        int gradePercentage;
        if (!int.TryParse(input, out gradePercentage) || gradePercentage < 0 || gradePercentage > 100)
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
            return;
        }

        string letter = ""; // To store letter grade
        string sign = "";   // To store + or -

        // Step 2: Determine letter grade
        if (gradePercentage >= 90)
            letter = "A";
        else if (gradePercentage >= 80)
            letter = "B";
        else if (gradePercentage >= 70)
            letter = "C";
        else if (gradePercentage >= 60)
            letter = "D";
        else
            letter = "F";

        // Step 3: Determine + or - sign
        int lastDigit = gradePercentage % 10;
        if (lastDigit >= 7)
            sign = "+";
        else if (lastDigit < 3)
            sign = "-";

        // Step 4: Handle A and F exceptions
        if (letter == "A" && sign == "+")  // No A+
            sign = "";
        if (letter == "F")  // No F+ or F-
            sign = "";

        // Step 5: Print final result
        Console.WriteLine($"\nYour final grade is: {letter}{sign}");

        // Step 6: Pass or fail message
        if (gradePercentage >= 70)
            Console.WriteLine("Congratulations! You passed the course. 🎉");
        else
            Console.WriteLine("Keep working hard! You'll do better next time. 💪");
    }
}
