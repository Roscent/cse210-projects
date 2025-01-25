using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }
    public Fraction(int numerator)
    {
        this.numerator = numerator;
        this.denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator can not be zero.");
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }

    public int GetNumerator()
    {
        return numerator;
    }
    public void SetNumerator(int numerator)
    {
        this.numerator = numerator;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.denominator = denominator;
    }
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }
    public double GetDecimalValue()
    {
        return(double)numerator / denominator;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");
        Console.WriteLine("Roscent's first fraction program.");
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        f3.SetNumerator(2);
        f3.SetDenominator(6);

        Console.WriteLine(f3.GetFractionString() + " = " + f3.GetDecimalValue());
    }
}
