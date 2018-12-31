using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleInfo
{
    /// <summary>
    /// Contains methods for getting information about a triangle and validating input
    /// </summary>
    public static class TriangleChecker
    {
        private const string ERR_NEGATIVE_LENGTH = "No side can have negative length.";
        private const double FP_MARGIN = 0.00001;
        private const double RIGHT_ANGLE = Math.PI / 2;

        /// <summary>
        /// Calculates the stats of a triangle with the given side lengths.
        /// Throws an exception if the sides do not create a valid triangle (triangles with zero area are allowed).
        /// </summary>
        /// <param name="sideA">The length of side A of the triangle.</param>
        /// <param name="sideB">The length of side B of the triangle.</param>
        /// <param name="sideC">The length of side C of the triangle.</param>
        /// <returns>An object containing the triangle's stats.</returns>
        public static TriangleStats GetTriangleStats(double sideA, double sideB, double sideC)
        {
            if (sideA < 0)
                throw new ArgumentException(ERR_NEGATIVE_LENGTH, "sideA");
            if (sideB < 0)
                throw new ArgumentException(ERR_NEGATIVE_LENGTH, "sideB");
            if (sideC < 0)
                throw new ArgumentException(ERR_NEGATIVE_LENGTH, "sideC");
            if (sideC > sideA + sideB || sideA > sideB + sideC || sideB > sideC + sideA)
                throw new InvalidTriangleException("No side's length can be greater than the sum of the other two.");

            var info = new TriangleStats();

            // check side lengths
            var AeqB = sideA == sideB;
            var BeqC = sideB == sideC;
            var CeqA = sideC == sideA;
            if (AeqB && BeqC)
                info.Type = TriangleType.Equilateral;
            else if (AeqB || BeqC || CeqA)
                info.Type = TriangleType.Isosceles;
            else
                info.Type = TriangleType.Scalene;

            // check angles
            // uses cosine rule to calculate angles A and B, and subtract both from 180 degrees to find C
            var angA =  Math.Acos((Math.Pow(sideB, 2) + Math.Pow(sideC, 2) - Math.Pow(sideA, 2)) / (2 * sideB * sideC));
            var angB = Math.Acos((Math.Pow(sideA, 2) + Math.Pow(sideC, 2) - Math.Pow(sideB, 2)) / (2 * sideA * sideC));
            var angC = Math.PI - angA - angB;
            // allow a small margin of error to account for floating-point innacuracy
            if (Math.Abs(angA - RIGHT_ANGLE) < FP_MARGIN || Math.Abs(angB - RIGHT_ANGLE) < FP_MARGIN || Math.Abs(angC - RIGHT_ANGLE) < FP_MARGIN)
                info.Angle = TriangleAngle.Right;
            else if (angA > RIGHT_ANGLE || angB > RIGHT_ANGLE || angC > RIGHT_ANGLE)
                info.Angle = TriangleAngle.Obtuse;
            else
                info.Angle = TriangleAngle.Acute;

            return info;
        }

        /// <summary>
        /// Checks to see if a given keystroke would be valid given the current contents of a textbox.
        /// </summary>
        /// <param name="currentText">The text currently contained in the textbox.</param>
        /// <param name="charKey">The character entered into the textbox.</param>
        /// <returns>True if the keystroke would be valid, false otherwise.</returns>
        public static bool IsValidKeystroke(string currentText, char charKey)
        {
            if (currentText == null)
                throw new ArgumentException("currentText cannot be null", "currentText");
            
            if (!char.IsControl(charKey) && !char.IsDigit(charKey) && charKey != '.')
                return false;
            if (charKey == '.' && currentText.IndexOf('.') > -1)
                return false;
            return true;
        }

        /// <summary>
        /// Gets the name of a triangle with the given stats.
        /// </summary>
        /// <param name="stats">The stats object of the triangle.</param>
        /// <returns>The name of the triangle with the given stats.</returns>
        public static string GetTriangleName(TriangleStats stats)
        {
            var result = "";
            switch (stats.Angle)
            {
                case TriangleAngle.Acute:
                    result = "acute";
                    break;
                case TriangleAngle.Right:
                    result = "right";
                    break;
                case TriangleAngle.Obtuse:
                    result = "obtuse";
                    break;
            }
            switch (stats.Type)
            {
                case TriangleType.Equilateral:
                    // all equilateral triangles are also acute triangles, so no need to keep it in the name
                    result = "equilateral";
                    break;
                case TriangleType.Isosceles:
                    result += " isosceles";
                    break;
                case TriangleType.Scalene:
                    result += " scalene";
                    break;
            }
            return result;
        }
    }

    public struct TriangleStats
    {
        public TriangleType Type;
        public TriangleAngle Angle;
    }

    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException(string message) : base(message) { }
    }
}
