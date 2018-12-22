using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleInfo
{
    public static class TriangleChecker
    {
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
            var AeqB = sideA == sideB;
            var BeqC = sideB == sideC;
            var CeqA = sideC == sideA;
            if (AeqB && BeqC)
                info.Type = TriangleType.Equilateral;
            else if (AeqB || BeqC || CeqA)
                info.Type = TriangleType.Isosceles;
            else
                info.Type = TriangleType.Scalene;

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
