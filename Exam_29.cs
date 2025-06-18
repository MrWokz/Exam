using System;
using System.Collections.Generic;

public interface IDrawable
{
    void Draw();
}

public abstract class Shape : IDrawable
{
    public abstract double CalculateArea();
    public abstract void Draw();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a Circle with radius {Radius}");
    }
}

public class Square : Shape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public override double CalculateArea()
    {
        return Side * Side;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a Square with side {Side}");
    }
}

public class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }

    public Triangle(double b, double h)
    {
        Base = b;
        Height = h;
    }

    public override double CalculateArea()
    {
        return 0.5 * Base * Height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a Triangle with base {Base} and height {Height}");
    }
}

public class Program
{
    public static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5),
            new Square(4),
            new Triangle(3, 6)
        };

        foreach (Shape shape in shapes)
        {
            shape.Draw();
            Console.WriteLine($"Area: {shape.CalculateArea()}\n");
        }
    }
}
