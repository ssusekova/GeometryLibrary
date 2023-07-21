using Library;
using System.ComponentModel;

public class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите фигуру");
        Console.WriteLine("1. Круг\n2. Треугольник\n3. Выход");
        IGeometryFigure? figure = null;

        string input = Console.ReadLine();
        bool isValid = int.TryParse(input, out int choice);
        if (isValid)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите радиус круга");
                    int radius = Int32.Parse(Console.ReadLine());
                    figure = new Circle(radius);
                    break;
                case 2:
                    Console.WriteLine("Введите стороны треугольника");
                    double a = Double.Parse(Console.ReadLine());
                    double b = Double.Parse(Console.ReadLine());
                    double c = Double.Parse(Console.ReadLine());
                    figure = new Triangle(a, b, c);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверное значение");
                    break;
            }
            Console.WriteLine("Площадь фигуры " + Convert.ToString(figure?.GetSquare()));
        }

    }
}
