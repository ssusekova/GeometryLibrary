using System;
using Library;
using NUnit.Framework;

namespace UnitTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroRadiusTest()
        {
            Assert.Catch<ArgumentException>(() => new Circle(0d));
        }


        [Test]
        public void NegativeRadiusTest()
        {
            Assert.Catch<ArgumentException>(() => new Circle(-1d));
        }


        [Test]
        public void LessMinRadiusTest()
        {
            Assert.Catch<ArgumentException>(() => new Circle(Circle._minRadius - IGeometryFigure.Eps));
        }


        [Test]
        public void GetSquareForCircleTest()
        {
            var radius = 5;
            var circle = new Circle(radius);
            var expectedValue = Math.PI * Math.Pow(radius, 2d);

            var square = circle.GetSquare();

            Assert.Less(Math.Abs(square - expectedValue), IGeometryFigure.Eps);
        }

        // For Triangle

        [TestCase(-1, 1, 1)]
        [TestCase(1, -1, 1)]
        [TestCase(1, 1, -1)]
        [TestCase(0, 0, 0)]
        public void InitTriangleWithErrorTest(double a, double b, double c)
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
        }

        [Test]
        public void InitTriangleTest()
        {
            double a = 3d, b = 4d, c = 5d;

            var triangle = new Triangle(a, b, c);

            Assert.NotNull(triangle);
            Assert.Less(Math.Abs(triangle.SideA - a), IGeometryFigure.Eps);
            Assert.Less(Math.Abs(triangle.SideB - b), IGeometryFigure.Eps);
            Assert.Less(Math.Abs(triangle.SideC - c), IGeometryFigure.Eps);
        }

        [Test]
        public void GetSquareForTriangleTest()
        {
            double a = 3d, b = 4d, c = 5d;
            double result = 6d;
            var triangle = new Triangle(a, b, c);

            var square = triangle?.GetSquare();

            Assert.NotNull(square);
            Assert.Less(Math.Abs(square.Value - result), IGeometryFigure.Eps);
        }

        [Test]
        public void InitNotTriangleTest()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => new Triangle(1, 1, 4));
        }

        [TestCase(3, 4, 3, ExpectedResult = false)]
        [TestCase(3, 4, 5 + 2e-7, ExpectedResult = false)]
        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(3, 4, 5.000000001, ExpectedResult = false)]
        public bool NotRightTriangle(double a, double b, double c)
        {
            var triangle = new Triangle(a, b, c);

            var isRight = triangle.IsRightTriangle;

            return isRight;
        }
    }
}