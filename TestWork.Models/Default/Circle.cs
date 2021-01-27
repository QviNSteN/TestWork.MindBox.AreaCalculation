using System;
using System.Collections.Generic;
using System.Text;
using TestWork.Figures.Base;
using TestWork.Data.Exceptons;

namespace TestWork.Figures.Default
{
    public class Circle : Figure
    {
        /// <summary>
        /// Return value radius for circle, assigned when class object is created.
        /// When changed, the area value will be calculated.
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Updated radius
        /// </summary>
        /// <param name="value">New value for radius</param>
        public void NewRadius(double value)
        {
            Radius = value;
            UpdateOrCreateFormulaData();
        }

        public Circle(double _radius)
        {
            Radius = _radius;

            UpdateOrCreateFormulaData();
        }

        /// <summary>
        /// This method for calculating the area of a rectangle
        /// </summary>
        /// <param name="paramters">Its array parameters for circle</param>
        /// <returns>Area value calculation</returns>
        private double CalculateFormule(double[] paramters)
        {
            return Math.PI * Math.Pow(paramters[0], 2);
        }

        public void ChekedForCorrectDataCircle(double radius)
        {
            if (radius <= 0)
                throw new NegativeOrZeroValueException("The radius cannot be less than or equal to zero!");
        }

        /// <summary>
        /// Method for creating and updating data by formula and parameters
        /// </summary>
        private void UpdateOrCreateFormulaData()
        {
            ChekedForCorrectDataCircle(Radius);

            if (Formula != null)
                Formula.SetNewParameters(Radius);
            else
                Formula = new Formula(CalculateFormule, Radius);
        }
    }
}
