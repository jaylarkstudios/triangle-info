using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleInfo
{
    public static class TriangleInfo
    {
        public static void GetTriangleType(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0)
                throw new ArgumentException("All sides of the triangle must be positive in length.", "sideA");
            if (sideB <= 0)
                throw new ArgumentException("All sides of the triangle must be positive in length.", "sideB");
            if (sideC <= 0)
                throw new ArgumentException("All sides of the triangle must be positive in length.", "sideC");
            if (sideA + sideB < sideC || sideB + sideC < sideA || sideC + sideA < sideB)
                throw new InvalidTriangleException("No side of a triangle may be greater than the sum of the other two sides.");
        }
    }

    

    public class InvalidTriangleException : Exception
    {
        public InvalidTriangleException(string message) : base(message) { }
    }
}
