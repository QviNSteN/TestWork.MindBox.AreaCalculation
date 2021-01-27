using System;
using System.Linq;
using TestWork.Figures.Base;
using TestWork.Data.Enums;
using TestWork.Data.Exceptons;

namespace TestWork.Figures.Default
{
    public class Triangle : Figure
    {
        /// <summary>
        /// First side for triangle.
        /// </summary>
        public double FirstSide { get; private set; }

        /// <summary>
        /// Updated first side
        /// </summary>
        /// <param name="value">New value for first side</param>
        public void NewFirstSide(double value)
        {
            FirstSide = value;
            UpdateOrCreateFormulaData();
        }

        /// <summary>
        /// Second side for triangle.
        /// </summary>
        public double SecondSide { get; private set; }

        /// <summary>
        /// Updated second side
        /// </summary>
        /// <param name="value">New value for second side</param>
        public void NewSecondSide(double value)
        {
            SecondSide = value;
            UpdateOrCreateFormulaData();
        }

        /// <summary>
        /// Third side for triangle.
        /// </summary>
        public double ThirdSide { get; private set; }

        /// <summary>
        /// Updated trhird side
        /// </summary>
        /// <param name="value">New value for trhird side</param>
        public void NewThirdSide(double value)
        {
            ThirdSide = value;
            UpdateOrCreateFormulaData();
        }

        /// <summary>
        /// Tringle type
        /// </summary>
        public TriangleTypeEnums TriangleType { get; set; }

        public Triangle(double first, double second, double third)
        {
            FirstSide = first;
            SecondSide = second;
            ThirdSide = third;

            UpdateOrCreateFormulaData();
        }

        /// <summary>
        /// Method for creating and updating data by formula and parameters
        /// </summary>
        private void UpdateOrCreateFormulaData()
        {
            ChekedForCorrectDataTriangle(FirstSide, SecondSide, ThirdSide);

            if (Formula != null)
            {
                Formula.SetNewParameters(FirstSide, SecondSide, ThirdSide);
                Formula.SetNewFormule(FromFormule());
            }
            else
                Formula = new Formula(FromFormule(), FirstSide, SecondSide, ThirdSide);
        }

        private Func<double[], double> FromFormule() =>
        TriangleTypeDefinition(FirstSide, SecondSide, ThirdSide) switch
        {
            TriangleTypeEnums.Equilateral => FormulaForEquilateral,
            TriangleTypeEnums.Rectangular => FormulaForRectangular,
            TriangleTypeEnums.Isosceles => FormulaForIsoscelesOrOther,
            TriangleTypeEnums.Default => FormulaForIsoscelesOrOther
        };

        /// <summary>
        /// Check if the given three sides can form a triangle
        /// </summary>
        public void ChekedForCorrectDataTriangle(double first, double second, double third)
        {
            if (first <= 0 || second <= 0 || third <= 0)
                throw new NegativeOrZeroValueException("The side of a triangle cannot be zero or negative!");

            if (first + second <= third || first + third <= second || third + second <= first)
                throw new ImpossibleExistenceException("Such a triangle cannot exist!");
        }

        public TriangleTypeEnums TriangleTypeDefinition()
        {
            return TriangleTypeDefinition(FirstSide, SecondSide, ThirdSide);
        }

        /// <summary>
        /// Set the type of triangle on three sides
        /// </summary>
        /// <returns>Type triangle</returns>
        public TriangleTypeEnums TriangleTypeDefinition(double first, double second, double third)
        {
            if (first == second && second == third)
                return TriangleTypeEnums.Equilateral;

            if (first == second || second == third || third == first)
                return TriangleTypeEnums.Isosceles;

            var arraySides = (new[] { first, second, third }).Select(x => Math.Pow(x, 2)).OrderBy(x => x).ToArray();

            if (arraySides[2] == arraySides[0] + arraySides[1])
                return TriangleTypeEnums.Rectangular;

            return TriangleTypeEnums.Default;
        }

        /// <summary>
        /// Formula for calculating the area of an equilateral triangle
        /// </summary>
        /// <param name="parameters">Its array parameters for formule</param>
        /// <returns>Area value calculation</returns>
        private double FormulaForEquilateral(double[] parameters)
        {
            return Math.Pow(parameters[0], 2) * Math.Sqrt(3) / 4;
        }

        /// <summary>
        /// Formula for calculating the area of an rectangular triangle
        /// </summary>
        /// <param name="parameters">Its array parameters for formule</param>
        /// <returns>Area value calculation</returns>
        private double FormulaForRectangular(double[] parameters)
        {
            parameters = parameters.OrderBy(x => x).ToArray();
            return parameters[0] * parameters[1] / 2;
        }

        /// <summary>
        /// Formula for calculating the area of an isosceles or other triangle
        /// </summary>
        /// <param name="parameters">Its array parameters for formule</param>
        /// <returns>Area value calculation</returns>
        private double FormulaForIsoscelesOrOther(double[] parameters)
        {
            var semiPerimeter = parameters.Sum() / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - parameters[0])*(semiPerimeter - parameters[1])*(semiPerimeter - parameters[2]));
        }
    }
}
