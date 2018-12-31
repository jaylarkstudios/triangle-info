using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleInfo;

namespace TriangleInfoUnitTests
{
    [TestClass]
    public class GetTriangleInfoUnitTests
    {
        #region Valid Input Tests
        [TestMethod]
        public void ThrowsExceptionOnNegativeSideA()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleStats(-1, 1, 1));
        }
        [TestMethod]
        public void ThrowsExceptionOnNegativeSideB()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleStats(1, -1, 1));
        }
        [TestMethod]
        public void ThrowsExceptionOnNegativeSideC()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleStats(1, 1, -1));
        }
        #endregion

        #region Valid Triangle Tests
        [TestMethod]
        public void ThrowsExceptionOnAGreaterThanBC()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleStats(3, 1, 1));
        }
        [TestMethod]
        public void ThrowsExceptionOnBGreaterThanCA()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleStats(1, 3, 1));
        }
        [TestMethod]
        public void ThrowsExceptionOnCGreaterThanAB()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleStats(1, 1, 3));
        }
        #endregion

        #region Triangle Type Tests
        [TestMethod]
        public void ReturnsEquilateralOnAllEqualSides()
        {
            var info = TriangleChecker.GetTriangleStats(1, 1, 1);

            Assert.AreEqual(TriangleType.Equilateral, info.Type);
        }
        [TestMethod]
        public void ReturnsIsoscelesOnABEqual()
        {
            var info = TriangleChecker.GetTriangleStats(2, 2, 1);

            Assert.AreEqual(TriangleType.Isosceles, info.Type);
        }
        [TestMethod]
        public void ReturnsIsoscelesOnBCEqual()
        {
            var info = TriangleChecker.GetTriangleStats(1, 2, 2);

            Assert.AreEqual(TriangleType.Isosceles, info.Type);
        }
        [TestMethod]
        public void ReturnsIsoscelesOnCAEqual()
        {
            var info = TriangleChecker.GetTriangleStats(2, 1, 2);

            Assert.AreEqual(TriangleType.Isosceles, info.Type);
        }
        [TestMethod]
        public void ReturnsScaleneOnNoEqualSides()
        {
            var info = TriangleChecker.GetTriangleStats(2, 3, 4);

            Assert.AreEqual(TriangleType.Scalene, info.Type);
        }
        #endregion

        #region Triangle Angle Tests
        [TestMethod]
        public void ReturnsRightOnRightAngleOppSideA()
        {
            var info1 = TriangleChecker.GetTriangleStats(5, 3, 4);
            var info2 = TriangleChecker.GetTriangleStats(5, 4, 3);

            Assert.AreEqual(TriangleAngle.Right, info1.Angle);
            Assert.AreEqual(TriangleAngle.Right, info2.Angle);
        }
        [TestMethod]
        public void ReturnsRightOnRightAngleOppSideB()
        {
            var info1 = TriangleChecker.GetTriangleStats(3, 5, 4);
            var info2 = TriangleChecker.GetTriangleStats(4, 5, 3);

            Assert.AreEqual(TriangleAngle.Right, info1.Angle);
            Assert.AreEqual(TriangleAngle.Right, info2.Angle);
        }
        [TestMethod]
        public void ReturnsRightOnRightAngleOppSideC()
        {
            var info1 = TriangleChecker.GetTriangleStats(3, 4, 5);
            var info2 = TriangleChecker.GetTriangleStats(4, 3, 5);

            Assert.AreEqual(TriangleAngle.Right, info1.Angle);
            Assert.AreEqual(TriangleAngle.Right, info2.Angle);
        }
        [TestMethod]
        public void ReturnsObtuseOnObtuseAngleOppSideA()
        {
            var info1 = TriangleChecker.GetTriangleStats(6, 3, 4);
            var info2 = TriangleChecker.GetTriangleStats(6, 4, 3);

            Assert.AreEqual(TriangleAngle.Obtuse, info1.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info2.Angle);
        }
        [TestMethod]
        public void ReturnsObtuseOnObtuseAngleOppSideB()
        {
            var info1 = TriangleChecker.GetTriangleStats(3, 6, 4);
            var info2 = TriangleChecker.GetTriangleStats(4, 6, 3);

            Assert.AreEqual(TriangleAngle.Obtuse, info1.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info2.Angle);
        }
        [TestMethod]
        public void ReturnsObtuseOnObtuseAngleOppSideC()
        {
            var info1 = TriangleChecker.GetTriangleStats(3, 4, 6);
            var info2 = TriangleChecker.GetTriangleStats(4, 3, 6);

            Assert.AreEqual(TriangleAngle.Obtuse, info1.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info2.Angle);
        }
        [TestMethod]
        public void ReturnsAcuteOnAllAnglesLessThan90()
        {
            var info = TriangleChecker.GetTriangleStats(3, 3, 2);

            Assert.AreEqual(TriangleAngle.Acute, info.Angle);
        }
        #endregion

        #region Unusual Size Precision Tests
        // These tests are designed to ensure correct triangle info is returned even for triangles of very large/small sides/angles
        [TestMethod]
        public void ReturnsObtuseOnLargeObtuseAngle()
        {
            // the obtuse angle is roughly 179.5 degrees (triangle is almost flat)

            var info1 = TriangleChecker.GetTriangleStats(20, 10.0001, 10.0001);
            var info2 = TriangleChecker.GetTriangleStats(10.0001, 20, 10.0001);
            var info3 = TriangleChecker.GetTriangleStats(10.0001, 10.0001, 20);

            Assert.AreEqual(TriangleAngle.Obtuse, info1.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info2.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info3.Angle);
        }
        [TestMethod]
        public void ReturnsAcuteOnVeryCloseToRightAngle()
        {
            // two of the angles are roughly 89.999 degrees, making the third almost zero
            var info1 = TriangleChecker.GetTriangleStats(1, 30000, 30000);
            var info2 = TriangleChecker.GetTriangleStats(30000, 1, 30000);
            var info3 = TriangleChecker.GetTriangleStats(30000, 30000, 1);

            Assert.AreEqual(TriangleAngle.Acute, info1.Angle);
            Assert.AreEqual(TriangleAngle.Acute, info2.Angle);
            Assert.AreEqual(TriangleAngle.Acute, info3.Angle);
        }
        [TestMethod]
        public void ReturnsRightOnLargeDiffBetweenLegs()
        {
            // One angle is 90 degrees, one is very close to 90, and one is very close to zero
            var info1 = TriangleChecker.GetTriangleStats(30000.00002, 30000, 1);
            var info2 = TriangleChecker.GetTriangleStats(1, 30000.00002, 30000);
            var info3 = TriangleChecker.GetTriangleStats(30000, 1, 30000.00002);

            Assert.AreEqual(TriangleAngle.Right, info1.Angle);
            Assert.AreEqual(TriangleAngle.Right, info2.Angle);
            Assert.AreEqual(TriangleAngle.Right, info3.Angle);
        }
        [TestMethod]
        public void ReturnsObtuseWhenTwoLegsEqualThird()
        {
            var info1 = TriangleChecker.GetTriangleStats(2, 1, 1);
            var info2 = TriangleChecker.GetTriangleStats(1, 2, 1);
            var info3 = TriangleChecker.GetTriangleStats(1, 1, 2);

            Assert.AreEqual(TriangleAngle.Obtuse, info1.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info2.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info3.Angle);
        }
        [TestMethod]
        public void ReturnsAcuteWhenOneLegIsZero()
        {
            var info1 = TriangleChecker.GetTriangleStats(0, 1, 1);
            var info2 = TriangleChecker.GetTriangleStats(1, 0, 1);
            var info3 = TriangleChecker.GetTriangleStats(1, 1, 0);

            Assert.AreEqual(TriangleAngle.Acute, info1.Angle);
            Assert.AreEqual(TriangleAngle.Acute, info2.Angle);
            Assert.AreEqual(TriangleAngle.Acute, info3.Angle);
        }
        #endregion
    }
}
