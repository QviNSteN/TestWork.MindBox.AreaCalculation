using System;
using Xunit;
using TestWork.Figures.Default;
using TestWork.Data.Exceptons;
using TestWork.Data.Enums;

namespace TestWork.Tests
{
    public class Triangle
    {
        [Fact]
        public void TestValueExists()
        {
            TestWork.Figures.Default.Triangle triangle = new Figures.Default.Triangle(10, 10, 10);
            Assert.NotNull(triangle.Area);
        }

        [Fact]
        public void TestValueTrue()
        {
            TestWork.Figures.Default.Triangle triangle = new Figures.Default.Triangle(10, 10, 10);
            Assert.Equal(43.30127018922193, triangle.Area);
        }

        [Fact]
        public void TestValueThrowExceptionForNegativeValueSides()
        {
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(-10, 10, 10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(10, -10, 10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(10, 10, -10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(-10, -10, 10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(-10, 10, -10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(10, -10, -10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(-10, -10, -10));

            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(0, 10, 10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(0, -10, 10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(0, 10, -10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(-10, 0, 10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(-10, 0, -10));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(10, -10, 0));
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Triangle(-10, -10, 0));
        }

        [Fact]
        public void TestValueThrowExceptionForImpossibleExistenceTriangle()
        {
            Assert.Throws<ImpossibleExistenceException>(() => new Figures.Default.Triangle(10000, 1, 1));
        }

        [Fact]
        public void TestForCorrectTypingOfATriangles()
        {
            Assert.Equal(TriangleTypeEnums.Equilateral, (new Figures.Default.Triangle(10, 10, 10)).TriangleTypeDefinition());
            Assert.Equal(TriangleTypeEnums.Isosceles, (new Figures.Default.Triangle(10, 10, 5)).TriangleTypeDefinition());
            Assert.Equal(TriangleTypeEnums.Rectangular, (new Figures.Default.Triangle(3, 4, 5)).TriangleTypeDefinition());
            Assert.Equal(TriangleTypeEnums.Default, (new Figures.Default.Triangle(3, 4, 6)).TriangleTypeDefinition());
        }
    }
}
