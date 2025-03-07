class Circle : Shape
{
    double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
        _name = "Circle";
    }

    public double GetRadius()
    {
        return _radius;
    }

    public void SetRadius(double radius)
    {
        _radius = radius;
    }

    public override double Area()
    {
        return Math.PI * _radius * _radius;
    }

    public double Circumference()
    {
        return 2 * Math.PI * _radius;
    }
}