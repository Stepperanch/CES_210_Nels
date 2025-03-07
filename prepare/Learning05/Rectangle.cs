class Rectangle : Shape
{
    double _length;
    double _width;



    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
        _name = "Rectangle";
    }

    public (double lenght , double width) Getlength_andWidth()
    {
        return (_length, _width);
    }

    public void Setlength_andWidth(double length, double width)
    {
        _length = length;
        _width = width;
    }

    public override double Area()
    {
        return _length * _width;
    }
}