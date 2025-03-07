class Shape
{
    protected string _color;

    protected string _name = "Shape";

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    public virtual double Area()
    {
        return 0;
    }

    public string Print()
    {
        return $"Name: {_name}, Color: {_color}, Area: {Area()}";
    }
}