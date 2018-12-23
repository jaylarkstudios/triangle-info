using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleInfo;

namespace TriangleInfoTests
{
    [TestClass]
    public class TriangleInfoUnitTests
    {
        #region Valid Input Tests
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnNegativeSideA()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleInfo(-1, 1, 1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnNegativeSideB()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleInfo(1, -1, 1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnNegativeSideC()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleInfo(1, 1, -1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnZeroSideA()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleInfo(0, 1, 1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnZeroSideB()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleInfo(1, 0, 1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnZeroSideC()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.GetTriangleInfo(1, 1, 0));
        }
        #endregion

        #region Valid Triangle Tests
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnAGreaterThanBC()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleInfo(3, 1, 1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnBGreaterThanCA()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleInfo(1, 3, 1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnCGreaterThanAB()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleInfo(1, 1, 3));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnAEqualToBC()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleInfo(2, 1, 1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnBEqualToCA()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleInfo(1, 2, 1));
        }
        [TestMethod]
        public void GetTriangleInfo_ThrowsExceptionOnCEqualToAB()
        {
            Assert.ThrowsException<InvalidTriangleException>(() => TriangleChecker.GetTriangleInfo(1, 1, 2));
        }
        #endregion

        #region TriangleTypeTests
        [TestMethod]
        public void GetTriangleInfo_ReturnsEquilateralOnAllEqualSides()
        {
            var info = TriangleChecker.GetTriangleInfo(1, 1, 1);

            Assert.AreEqual(TriangleType.Equilateral, info.Type);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsIsoscelesOnABEqual()
        {
            var info = TriangleChecker.GetTriangleInfo(2, 2, 1);

            Assert.AreEqual(TriangleType.Isosceles, info.Type);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsIsoscelesOnBCEqual()
        {
            var info = TriangleChecker.GetTriangleInfo(1, 2, 2);

            Assert.AreEqual(TriangleType.Isosceles, info.Type);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsIsoscelesOnCAEqual()
        {
            var info = TriangleChecker.GetTriangleInfo(2, 1, 2);

            Assert.AreEqual(TriangleType.Isosceles, info.Type);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsScaleneOnNoEqualSides()
        {
            var info = TriangleChecker.GetTriangleInfo(2, 3, 4);

            Assert.AreEqual(TriangleType.Scalene, info.Type);
        }
        #endregion

        #region TriangleAngleTests
        [TestMethod]
        public void GetTriangleInfo_ReturnsRightOnRightAngleOppSideA()
        {
            var info1 = TriangleChecker.GetTriangleInfo(5, 3, 4);
            var info2 = TriangleChecker.GetTriangleInfo(5, 4, 3);

            Assert.AreEqual(TriangleAngle.Right, info1.Angle);
            Assert.AreEqual(TriangleAngle.Right, info2.Angle);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsRightOnRightAngleOppSideB()
        {
            var info1 = TriangleChecker.GetTriangleInfo(3, 5, 4);
            var info2 = TriangleChecker.GetTriangleInfo(4, 5, 3);

            Assert.AreEqual(TriangleAngle.Right, info1.Angle);
            Assert.AreEqual(TriangleAngle.Right, info2.Angle);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsRightOnRightAngleOppSideC()
        {
            var info1 = TriangleChecker.GetTriangleInfo(3, 4, 5);
            var info2 = TriangleChecker.GetTriangleInfo(4, 3, 5);

            Assert.AreEqual(TriangleAngle.Right, info1.Angle);
            Assert.AreEqual(TriangleAngle.Right, info2.Angle);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsObtuseOnObtuseAngleOppSideA()
        {
            var info1 = TriangleChecker.GetTriangleInfo(6, 3, 4);
            var info2 = TriangleChecker.GetTriangleInfo(6, 4, 3);

            Assert.AreEqual(TriangleAngle.Obtuse, info1.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info2.Angle);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsObtuseOnObtuseAngleOppSideB()
        {
            var info1 = TriangleChecker.GetTriangleInfo(3, 6, 4);
            var info2 = TriangleChecker.GetTriangleInfo(4, 6, 3);

            Assert.AreEqual(TriangleAngle.Obtuse, info1.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info2.Angle);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsObtuseOnObtuseAngleOppSideC()
        {
            var info1 = TriangleChecker.GetTriangleInfo(3, 4, 6);
            var info2 = TriangleChecker.GetTriangleInfo(4, 3, 6);

            Assert.AreEqual(TriangleAngle.Obtuse, info1.Angle);
            Assert.AreEqual(TriangleAngle.Obtuse, info2.Angle);
        }
        [TestMethod]
        public void GetTriangleInfo_ReturnsAcuteOnAllAnglesLessThan90()
        {
            var info = TriangleChecker.GetTriangleInfo(3, 3, 2);

            Assert.AreEqual(TriangleAngle.Acute, info.Angle);
        }
        #endregion
    }
}
