using System;
using Xunit;
using TestWork.Figures.Default;
using TestWork.Data.Exceptons;

namespace TestWork.Tests
{
    public class Circle
    {
        [Fact]
        public void TestValueExists()
        {
            TestWork.Figures.Default.Circle circle = new Figures.Default.Circle(10);
            Assert.NotNull(circle.Area);
        }

        [Fact]
        public void TestValueTrue()
        {
            TestWork.Figures.Default.Circle circle = new Figures.Default.Circle(10);
            Assert.Equal(314.1592653589793, circle.Area);
        }

        [Fact]
        public void TestValueThrowExceptionForNegativeValueRadius()
        {
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Circle(-1));
        }
    }
}
