using System;
using System.Runtime.CompilerServices;

namespace Library
{
    public class Circle : IGeometryFigure
    {
        private double Radius { get; }
        public const double _minRadius = 1e-6;
        public Circle(double radius)
        {
            if (radius - _minRadius < IGeometryFigure.Eps) 
                throw new ArgumentException("Некорректный радиус");
            Radius = radius;
        }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2d);
        }
    }
}
