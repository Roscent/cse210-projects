using System;

class Program
{
    static void Main()
    {
        Journal myJournal = new Journal();
        while (true)
        {
            Console.WriteLine("Hello! You can call me Roscent, and this is my first journal program. come on let's make memories...");
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Edit an entry");
            Console.WriteLine("4. Save journal to file");
            Console.WriteLine("5. Load journal from file");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    myJournal.WriteNewEntry();
                    break;
                case "2":
                    myJournal.DisplayJournal();
                    break;
                case "3":
                    myJournal.EditEntry();
                    break;
                case "4":
                    myJournal.SaveToFile();
                    break;
                case "5":
                    myJournal.LoadFromFile();
                    break;
                case "6":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }
}
