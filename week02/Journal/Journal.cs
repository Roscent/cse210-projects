using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;
    private static readonly List<string> prompts = new List<string>
    {
        "What is your name?",
        "Who did you meet today?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "Who did you share the gospel and testimonies with today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void WriteNewEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        entries.Add(new Entry(prompt, response));
        Console.WriteLine("Entry saved successfully.\n");
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        for (int i = 0; i < entries.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {entries[i]}");
        }
    }

    public void EditEntry()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No entries to edit.\n");
            return;
        }

        DisplayJournal();
        Console.Write("Enter the number of the entry you want to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= entries.Count)
        {
            Console.WriteLine($"Editing Entry {index}:");
            Console.WriteLine(entries[index - 1]);

            Console.Write("Enter your new response: ");
            string newResponse = Console.ReadLine();

            entries[index - 1].Response = newResponse;
            Console.WriteLine("Entry updated successfully.\n");
        }
        else
        {
            Console.WriteLine("Invalid entry number. Please try again.\n");
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.\n");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load the journal: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string response = parts[2];
                entries.Add(new Entry(prompt, response) { Date = date });
            }
        }
        Console.WriteLine("Journal loaded successfully.\n");
    }
}
