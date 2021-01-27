using System;
using TestWork.Figures.Base;

namespace TestWork.Figures.Custom.Example
{
    /// <summary>
    /// The class is an example of how you can create a custom class object and calculate its area.
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// For confirmation, reference to the area.
        /// </summary>
        public double? Area => Figure?.Area;

        /// <summary>
        /// The CustomFigure class object.
        /// </summary>
        private CustomFigure Figure { get; set; }

        /// <summary>
        /// Constructor with input parameters.
        /// </summary>
        public Rectangle(double _widht, double _height)
        {
            //Assigning a delegate to the formula and its input parameters.
            //Since this is just an example, no checks have been added.
            Figure = new CustomFigure(new Formula(CalculateFormule, _widht, _height));
        }

        /// <summary>
        /// Calculation of the formula that will be passed to the delegate
        /// </summary>
        /// <param name="paramters">Its array parameters for formule</param>
        /// <returns>Area value calculation</returns>
        public double CalculateFormule(double[] paramters)
        {
            return paramters[0] * paramters[1];
        }
    }
}
