using System;
using System.Collections.Generic;
using System.Text;
using TestWork.Figures.Base;
using TestWork.Data.Exceptons;

namespace TestWork.Figures.Default
{
    public class Rectangle : Figure
    {
        /// <summary>
        /// Return value width for rectangle, assigned when class object is created.
        /// When changed, the area value will be calculated.
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Updated width
        /// </summary>
        /// <param name="value">New value for width</param>
        public void NewWidth(double value)
        {
            Width = value;
            UpdateOrCreateFormulaData();
        }

        /// <summary>
        /// Return value height for rectangle, assigned when class object is created.
        /// When changed, the area value will be calculated.
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Updated height
        /// </summary>
        /// <param name="value">New value for height</param>
        public void NewHeight(double value)
        {
            Height = value;
            UpdateOrCreateFormulaData();
        }

        public Rectangle(double _widht, double _height)
        {
            Width = _widht;
            Height = _height;

            UpdateOrCreateFormulaData();
        }

        /// <summary>
        /// This method for calculating the area of a rectangle
        /// </summary>
        /// <param name="paramters">Its array parameters for formule</param>
        /// <returns>Area value calculation</returns>
        private double CalculateFormule(double[] paramters)
        {
            return paramters[0] * paramters[1];
        }

        public void ChekedForCorrectDataRectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new NegativeOrZeroValueException("The sides of the rectangle must not be less than or equal to zero!");
        }

        /// <summary>
        /// Method for creating and updating data by formula and parameters
        /// </summary>
        private void UpdateOrCreateFormulaData()
        {
            ChekedForCorrectDataRectangle(Width, Height);

            if (Formula != null)
                Formula.SetNewParameters(Width, Height);
            else
                Formula = new Formula(CalculateFormule, Width, Height);
        }
    }
}
