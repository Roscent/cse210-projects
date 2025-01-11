using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Console.WriteLine("Roscent third C# exercise");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 5);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("Guess a number.");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("lower");
            }
            else
            {
                Console.WriteLine("Your guess is correct!");
            }
        }

    }
}