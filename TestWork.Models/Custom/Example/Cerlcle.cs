using System;
using TestWork.Figures.Base;

namespace TestWork.Figures.Custom.Example
{
    public class Cerlcle
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
        public Cerlcle(double round)
        {
            //Assigning a delegate to the formula and its input parameters.
            //Since this is just an example, no checks have been added.
            Figure = new CustomFigure(new Formula(CalculateFormule, round));
        }

        /// <summary>
        /// Calculation of the formula that will be passed to the delegate
        /// </summary>
        /// <param name="paramters">Its array parameters for formule</param>
        /// <returns>Area value calculation</returns>
        public double CalculateFormule(double[] paramters)
        {
            return  Math.PI * Math.Pow(paramters[0], 2);
        }
    }
}
