using System;
using TestWork.Data.Exceptons;
using TestWork.Data.Enums;

namespace TestWork.Figures.Base
{
    public class Formula
    {
        /// <summary>
        /// A system pointer to the status of the formula change.
        /// </summary>
        internal FigureEditEnum NewVersionFormule { get; set; } = FigureEditEnum.NewOrNewVersion;

        private double[] paramsFunctios;

        /// <summary>
        /// It is parameters for calculated formula.
        /// </summary>
        private double[] ParamsFunction
        {
            get { return paramsFunctios; }
            set
            {
                if (paramsFunctios != null && paramsFunctios.Length != value.Length)
                    throw new ComputingExcepton("Change the formula for this or provide parameters for the previous formula.");

                NewVersionFormule = FigureEditEnum.Edited;
                paramsFunctios = value;
            }
        }

        private Func<double[], double> function;

        /// <summary>
        /// It is formula for calculated.
        /// </summary>
        private Func<double[], double> Function
        {
            get { return function; }
            set
            {
                NewVersionFormule = FigureEditEnum.Edited;
                function = value;
            }
        }

        public Formula(Func<double[], double> _function, params double[] _params)
        {
            if (_function == null)
                throw new ArgumentNullException("The function for the calculated area is null.");

            if (_params == null)
                throw new ArgumentNullException("The function parameters for the calculated area are null.");

            Function = _function;
            ParamsFunction = _params;
        }

        /// <summary>
        /// Change the input parameters for a formula
        /// </summary>
        /// <param name="parameters">Parameters for the assigned formula</param>
        public void SetNewParameters(params double[] parameters)
        {
            paramsFunctios = parameters;
        }

        /// <summary>
        /// Change the input parameters for a formula
        /// </summary>
        /// <param name="parameters">Parameters for the assigned formula</param>
        public void SetNewFormule(Func<double[], double> _function)
        {
            Function = _function;
        }

        /// <summary>
        /// Calculate the new area value using the given formula
        /// </summary>
        /// <returns>New area value</returns>
        /// <exception cref="Exception">In case of any error in the formula or in case of incorrect parameters</exception>
        public double CalculateArea()
        {
            double result = 0;

            try
            {
                result = Function(ParamsFunction);
            }
            catch (Exception e)
            {
                throw new Exception($"Incorrect formula or parameters." +
                    $"System error for analytic: {e.Message}");
            }

            return result;
        }
    }
}
