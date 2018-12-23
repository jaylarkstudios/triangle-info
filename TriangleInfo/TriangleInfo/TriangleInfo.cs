using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleInfo
{
    public static class TriangleChecker
    {
        private const double FP_MARGIN = 0.000000000001;
        private const double RIGHT_ANGLE = Math.PI / 2;

        public static TriangleInfo GetTriangleInfo(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0)
                throw new ArgumentException("All sides of the triangle must be positive in length.", "sideA");
            if (sideB <= 0)
                throw new ArgumentException("All sides of the triangle must be positive in length.", "sideB");
            if (sideC <= 0)
                throw new ArgumentException("All sides of the triangle must be positive in length.", "sideC");
            if (sideA + sideB <= sideC || sideB + sideC <= sideA || sideC + sideA <= sideB)
                throw new InvalidTriangleException("The length of each side must be less than the sum of the other two side lengths.");

            var info = new TriangleInfo();

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
    }

    public struct TriangleInfo
    {
        public TriangleType Type;
        public TriangleAngle Angle;
    }

    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException(string message) : base(message) { }
    }
}
