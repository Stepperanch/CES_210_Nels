using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Circle("Red", 2.5));
        shapes.Add(new Rectangle("Blue", 2.5, 3.5));
        shapes.Add(new Square("Green", 2.5));

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.Print());
        }
    }
}