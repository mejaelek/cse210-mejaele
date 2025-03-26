 using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        bool playAgain = true;

        while (playAgain) // Loop for replaying the game
        {
            int magicNumber = random.Next(1, 101); // Generate random number between 1 and 100
            int guess = -1; // Initialize guess with an invalid value
            int guessCount = 0; // Counter for guesses

            Console.WriteLine("\nWelcome to 'Guess My Number' game!");
            Console.WriteLine("I have selected a magic number between 1 and 100.");
            
            // Loop until the user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                
                // Validate user input
                if (!int.TryParse(input, out guess) || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                    continue; // Skip to the next iteration
                }

                guessCount++; // Increment guess counter

                // Check if the guess is correct
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"\n🎉 You guessed it! The magic number was {magicNumber}.");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("\nDo you want to play again? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();
            playAgain = response == "yes"; // Continue only if the user says "yes"
        }

        Console.WriteLine("\nThanks for playing! Goodbye. 👋");
    }
}
