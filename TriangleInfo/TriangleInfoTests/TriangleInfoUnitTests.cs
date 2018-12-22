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
    }
}
