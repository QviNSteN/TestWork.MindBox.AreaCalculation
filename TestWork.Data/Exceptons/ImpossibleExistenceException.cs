using System;
namespace TestWork.Data.Exceptons
{
    public class ImpossibleExistenceException : Exception
    {
        public ImpossibleExistenceException(string message) : base(message) { }
    }
}
