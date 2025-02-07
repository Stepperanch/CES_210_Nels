using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Desplaying fractions:"); // Displaying fractions

        Fraction f1 = new Fraction(1, 2);
        Fraction f2 = new Fraction(1, 3);
        Fraction f3 = new Fraction(1, 4);
        Fraction f4 = new Fraction(2, 4);

        Console.WriteLine("f1: " + f1.GetFractionString() + " = " + f1.GetDecimalValue());
        Console.WriteLine("f2: " + f2.GetFractionString() + " = " + f2.GetDecimalValue());
        Console.WriteLine("f3: " + f3.GetFractionString() + " = " + f3.GetDecimalValue());
        Console.WriteLine("f4: " + f4.GetFractionString() + " = " + f4.GetDecimalValue());
        Console.WriteLine();

        Console.WriteLine("Simplifying fractions:");    // Simplifying fractions
        f4.Simplify();
        Console.WriteLine("f4 simplified: " + f4.GetFractionString() + " = " + f4.GetDecimalValue());
        Console.WriteLine();

        Console.WriteLine("Changing fractions:");   // Changing fractions
        f4.SetNumerator(3);
        f4.SetDenominator(18);
        Console.WriteLine("f4 changed: " + f4.GetFractionString() + " = " + f4.GetDecimalValue());
        Console.WriteLine();

        Console.WriteLine("Simplifying fractions:");    // Simplifying fractions
        f4.Simplify();
        Console.WriteLine("f4 changed and simplified: " + f4.GetFractionString() + " = " + f4.GetDecimalValue());
        Console.WriteLine();

        Console.WriteLine("Performing operations with 2 Fractions:");   // Performing operations with 2 Fractions
        Fraction f5 = f1.Add(f2);
        Fraction f6 = f1.Subtract(f2);
        Fraction f7 = f1.Multiply(f2); 
        Fraction f8 = f1.Divide(f2);
        
        Console.WriteLine("f1 + f2 = f5: " + f5.GetFractionString() + " = " + f5.GetDecimalValue());
        Console.WriteLine("f1 - f2 = f6: " + f6.GetFractionString() + " = " + f6.GetDecimalValue());
        Console.WriteLine("f1 * f2 = f7: " + f7.GetFractionString() + " = " + f7.GetDecimalValue());
        Console.WriteLine("f1 / f2 = f8: " + f8.GetFractionString() + " = " + f8.GetDecimalValue());
        Console.WriteLine();

        Console.WriteLine("Performing operations with a Fraction and an integer:");  // Performing operations with a Fraction and an integer
        Fraction f9 = f1.Add(4);
        Fraction f10 = f1.Subtract(4);
        Fraction f11 = f1.Multiply(4);
        Fraction f12 = f1.Divide(4);

        Console.WriteLine("f1 + 4 = f9: " + f9.GetFractionString() + " = " + f9.GetDecimalValue());
        Console.WriteLine("f1 - 4 = f10: " + f10.GetFractionString() + " = " + f10.GetDecimalValue());
        Console.WriteLine("f1 * 4 = f11: " + f11.GetFractionString() + " = " + f11.GetDecimalValue());
        Console.WriteLine("f1 / 4 = f12: " + f12.GetFractionString() + " = " + f12.GetDecimalValue());

    }
}