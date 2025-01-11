using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        Console.WriteLine("Roscent first C# exercise");

        Console.Write("What's your first name?");
        string first = Console.ReadLine();


        Console.Write("What's your middle name?");
        string middle = Console.ReadLine();

        Console.Write("What's your last name?");
        string last = Console.ReadLine();

        Console.WriteLine($" Your name is {first} {middle} {last}.");
    }
}
