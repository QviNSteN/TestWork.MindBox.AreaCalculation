using System;
namespace TestWork.Data.Exceptons
{
    public class NegativeOrZeroValueException : Exception
    {
        public NegativeOrZeroValueException(string message) : base(message) { }
    }
}
