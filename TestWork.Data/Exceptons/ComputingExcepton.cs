using System;
namespace TestWork.Data.Exceptons
{
    public class ComputingExcepton : Exception
    {
        public ComputingExcepton(string message) : base(message) { }
    }
}
