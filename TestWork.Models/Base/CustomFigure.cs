using System;

namespace TestWork.Figures.Base
{
    public class CustomFigure : Figure
    {
        public CustomFigure(Formula _formule)
        {
            SetFormule(_formule);
        }

        /// <summary>
        /// Method for changing or assigning a formula and its parameters
        /// </summary>
        /// <param name="formule">Formula object class. All calculations are assigned to it, nothing is required from you</param>
        public void SetFormule(Formula formule)
        {
            if (formule == null)
                throw new NullReferenceException("Formula data is invalid.");

            Formula = formule;
        }
    }
}
