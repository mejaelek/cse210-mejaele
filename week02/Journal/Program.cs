 using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("\n📖 Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Write an entry using voice");
            Console.WriteLine("3. Display journal");
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Load journal from file");
            Console.WriteLine("6. Exit");
            Console.Write("\nEnter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.WriteEntryWithVoice();
                    break;
                case "3":
                    journal.DisplayJournal();
                    break;
                case "4":
                    journal.SaveJournal();
                    break;
                case "5":
                    journal.LoadJournal();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }
}

