using System;
using TestWork.Data.Enums;
using TestWork.Generic.Extantions;

namespace TestWork.Figures.Base
{
    public abstract class Figure
    {
        /// <summary>
        /// Pointer to the current status of the calculation. If Edited is set, recalculation of the value is required.
        /// </summary>
        private FigureEditEnum? IsFigureEdited => Formula?.NewVersionFormule;

        /// <summary>
        /// Object "Formula". Designed for all calculations. Contains methods for recalculating and changing values.
        /// </summary>
        protected Formula Formula { get; set; }

        private double? area;
        public double? Area
        {
            protected set
            {
                area = value;
            }
            get
            {
                if (IsFigureEdited == FigureEditEnum.Edited)
                {
                    Area = Formula.CalculateArea().CheckedToErrorForArea();
                    Formula.NewVersionFormule = FigureEditEnum.NewOrNewVersion;
                }
                return area;
            }
        }
    }
}