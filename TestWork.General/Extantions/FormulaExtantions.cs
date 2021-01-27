using System;
using TestWork.Data.Exceptons;

namespace TestWork.Generic.Extantions
{
    public static class DoubleExtantions
    {
        /// <summary>
        /// Checking a double type for an incorrect value for the area.
        /// </summary>
        /// <param name="result">New area value</param>
        /// <returns>Value area.</returns>
        /// <exception cref="ComputingExcepton">If error in formula or parameters</exception>
        public static double CheckedToErrorForArea(this double result)
        {
            if (Double.IsNaN(result))
                throw new ComputingExcepton("Error in formula or parameters: error in calculated!");
            if (Double.IsInfinity(result))
                throw new ComputingExcepton("Error in formula or parameters: area cannot be infinity!");
            if (result == 0)
                throw new ComputingExcepton("Error in formula or parameters: area cannot be zero!");
            if (result < 0)
                throw new ComputingExcepton("Error in the formula or parameters: the area cannot be less than zero!");
            return result;
        }
    }
}