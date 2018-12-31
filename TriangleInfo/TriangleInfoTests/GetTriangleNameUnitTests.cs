using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleInfo;

namespace TriangleInfoUnitTests
{
    [TestClass]
    public class GetTriangleNameUnitTests
    {
        [TestMethod]
        public void AcuteAngleReturnsCorrectName()
        {
            var info = new TriangleStats()
            {
                Angle = TriangleAngle.Acute,
                Type = TriangleType.Scalene
            };

            var result = TriangleChecker.GetTriangleName(info);

            Assert.AreEqual("acute scalene", result);
        }
        [TestMethod]
        public void RightAngleReturnsCorrectName()
        {
            var info = new TriangleStats()
            {
                Angle = TriangleAngle.Right,
                Type = TriangleType.Scalene
            };

            var result = TriangleChecker.GetTriangleName(info);

            Assert.AreEqual("right scalene", result);
        }
        [TestMethod]
        public void ObtuseAngleReturnsCorrectName()
        {
            var info = new TriangleStats()
            {
                Angle = TriangleAngle.Obtuse,
                Type = TriangleType.Scalene
            };

            var result = TriangleChecker.GetTriangleName(info);

            Assert.AreEqual("obtuse scalene", result);
        }
        [TestMethod]
        public void ScaleneTriangleReturnsCorrectName()
        {
            var info = new TriangleStats()
            {
                Angle = TriangleAngle.Acute,
                Type = TriangleType.Scalene
            };

            var result = TriangleChecker.GetTriangleName(info);

            Assert.AreEqual("acute scalene", result);
        }
        [TestMethod]
        public void IsoscelesTriangleReturnsCorrectName()
        {
            var info = new TriangleStats()
            {
                Angle = TriangleAngle.Acute,
                Type = TriangleType.Isosceles
            };

            var result = TriangleChecker.GetTriangleName(info);

            Assert.AreEqual("acute isosceles", result);
        }
        [TestMethod]
        public void EquilateralTriangleReturnsCorrectName()
        {
            var info = new TriangleStats()
            {
                Angle = TriangleAngle.Acute,
                Type = TriangleType.Equilateral
            };

            var result = TriangleChecker.GetTriangleName(info);

            Assert.AreEqual("equilateral", result);
        }
    }
}
