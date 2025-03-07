class Square : Shape
{
    double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
        _name = "Square";
    }

    public double GetSide()
    {
        return _side;
    }

    public void SetSide(double side)
    {
        _side = side;
    }

    public override double Area()
    {
        return _side * _side;
    }
}