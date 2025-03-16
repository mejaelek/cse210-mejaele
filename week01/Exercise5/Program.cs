 using System;

class Program
{
    static void Main()
    {
        // Step 1: Display welcome message
        DisplayWelcome();

        // Step 2: Get user input
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();

        // Step 3: Compute square of the number
        int squaredNumber = SquareNumber(favoriteNumber);

        // Step 4: Display the result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt for and return the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt for and return the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
                return number;

            Console.Write("Invalid input. Please enter a valid integer: ");
        }
    }

    // Function to return the square of a given number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the final result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
