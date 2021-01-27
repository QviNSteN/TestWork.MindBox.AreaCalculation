using System;
using Xunit;
using TestWork.Figures.Default;
using TestWork.Data.Exceptons;

namespace TestWork.Tests
{
    public class Rectangle
    {
        [Fact]
        public void TestValueExists()
        {
            TestWork.Figures.Default.Rectangle rectangle = new Figures.Default.Rectangle(10,10);
            Assert.NotNull(rectangle.Area);
        }

        [Fact]
        public void TestValueTrue()
        {
            TestWork.Figures.Default.Rectangle rectangle = new Figures.Default.Rectangle(10, 10);
            Assert.Equal(100, rectangle.Area);
        }

        [Fact]
        public void TestValueThrowExceptionForNegativeValueRadius()
        {
            Assert.Throws<NegativeOrZeroValueException>(() => new Figures.Default.Rectangle(-1, 10));
        }
    }
}
