public class Fraction
{

    private int _numerator;
    private int _denominator;

    public Fraction(int WholeNumber)
    {
        _numerator = WholeNumber;
        _denominator = 1;
    }
    public Fraction(int Numerator, int Denominator)
    {
        _numerator = Numerator;
        _denominator = Denominator;
    }
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Functions that have to do with manipulating the fraction without changing its value
    private int GCD(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        return GCD(b, a % b);
    }
    public void Simplify()
    {
        int gcd = GCD(_numerator, _denominator);
        _numerator = _numerator / gcd;
        _denominator = _denominator / gcd;
    }

    // Functions that have to do with manualy changing or retrieving the values of the fraction
    public int GetNumerator()
    {
        return _numerator;
    }
    public int GetDenominator()
    {
        return _denominator;
    }
    public void SetNumerator(int Numerator)
    {
        _numerator = Numerator;
    }
    public void SetDenominator(int Denominator)
    {
        _denominator = Denominator;
    }

    // Functions that have to do with retriving the value of the fraction as a whole
    public string GetFractionString()
    {
        return _numerator + "/" + _denominator;
    }
    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }

    // Functions that have to do with changing the value of the fraction by adding, subtracting, multiplying or dividing antoher fraction
    public Fraction Add(Fraction OtherFraction)
    {
        int newNumerator = _numerator * OtherFraction.GetDenominator() + OtherFraction.GetNumerator() * _denominator;
        int newDenominator = _denominator * OtherFraction.GetDenominator();
        Fraction newFraction = new Fraction(newNumerator, newDenominator);
        newFraction.Simplify();
        return newFraction;
    }
    public Fraction Subtract(Fraction OtherFraction)
    {
        int newNumerator = _numerator * OtherFraction.GetDenominator() - OtherFraction.GetNumerator() * _denominator;
        int newDenominator = _denominator * OtherFraction.GetDenominator();
        Fraction newFraction = new Fraction(newNumerator, newDenominator);
        newFraction.Simplify();
        return newFraction;
    }
    public Fraction Multiply(Fraction OtherFraction)
    {
        int newNumerator = _numerator * OtherFraction.GetNumerator();
        int newDenominator = _denominator * OtherFraction.GetDenominator();
        Fraction newFraction = new Fraction(newNumerator, newDenominator);
        newFraction.Simplify();
        return newFraction;
    }
    public Fraction Divide(Fraction OtherFraction)
    {
        int newNumerator = _numerator * OtherFraction.GetDenominator();
        int newDenominator = _denominator * OtherFraction.GetNumerator();
        Fraction newFraction = new Fraction(newNumerator, newDenominator);
        newFraction.Simplify();
        return newFraction;
    }

    // Functions that have to do with changing the value of the fraction by adding, subtracting, multiplying or dividing a whole number
    public Fraction Add(int WholeNumber)
    {
        Fraction newFraction = new Fraction(WholeNumber);
        return Add(newFraction);
    }
    public Fraction Subtract(int WholeNumber)
    {
        Fraction newFraction = new Fraction(WholeNumber);
        return Subtract(newFraction);
    }
    public Fraction Multiply(int WholeNumber)
    {
        Fraction newFraction = new Fraction(WholeNumber);
        return Multiply(newFraction);
    }
    public Fraction Divide(int WholeNumber)
    {
        Fraction newFraction = new Fraction(WholeNumber);
        return Divide(newFraction);
    }

    // Functions that have to do with desplaying the fraction
    public void Display()
    {
        Console.WriteLine(GetFractionString());
    }
    public void DisplayDecimal()
    {
        Console.WriteLine(GetDecimalValue());
    }
}