using System;

namespace Library
{
    public class Triangle : IGeometryFigure
    {
        private double MaxVal { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        /// <summary>
        /// Полупериметр
        /// </summary>
        private double HfPerimeter { get; set; }
        private double Perimeter { get; set; }

        public bool IsRightTriangle { get; }
      
        public Triangle(double sideA, double sideB, double sideC) 
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            if (SideA < IGeometryFigure.Eps) throw new ArgumentOutOfRangeException("Некорректное значение первой стороны фигуры");
            if (SideB < IGeometryFigure.Eps) throw new ArgumentOutOfRangeException("Некорректное значение второй стороны фигуры");
            if (SideC < IGeometryFigure.Eps) throw new ArgumentOutOfRangeException("Некорректное значение третьей стороны фигуры");

            Perimeter = SideA + SideB + SideC;
            MaxVal = Math.Max(SideA, Math.Max(SideB, SideC));

            if (IGeometryFigure.Eps > (Perimeter - MaxVal - MaxVal))
            {
                throw new ArgumentOutOfRangeException("Сторона треугольника не может быть больше суммы двух других сторон");
            }

            IsRightTriangle = GetIsRightTriangle();
        }

        private bool GetIsRightTriangle()
        {
            return (SideA * SideA + SideB * SideB == SideC * SideC) || (SideA * SideA + SideC * SideC == SideB * SideB) || (SideC * SideC + SideB * SideB == SideA * SideA);
        }

        public double GetSquare()
        {
            HfPerimeter = (SideA + SideB + SideC)/2d;
            return Math.Sqrt(HfPerimeter *(HfPerimeter - SideA)*(HfPerimeter - SideB)*(HfPerimeter - SideC));
        }
    }
}
