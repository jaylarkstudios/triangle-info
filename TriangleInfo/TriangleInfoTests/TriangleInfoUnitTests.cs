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
        public void GetTriangleType_ThrowsExceptionOnNegativeSideA()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleInfo.TriangleInfo.GetTriangleType(-1, 1, 1));
        }
        [TestMethod]
        public void GetTriangleType_ThrowsExceptionOnNegativeSideB()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleInfo.TriangleInfo.GetTriangleType(1, -1, 1));
        }
        [TestMethod]
        public void GetTriangleType_ThrowsExceptionOnNegativeSideC()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleInfo.TriangleInfo.GetTriangleType(1, 1, -1));
        }
        [TestMethod]
        public void GetTriangleType_ThrowsExceptionOnZeroSideA()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleInfo.TriangleInfo.GetTriangleType(0, 1, 1));
        }
        [TestMethod]
        public void GetTriangleType_ThrowsExceptionOnZeroSideB()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleInfo.TriangleInfo.GetTriangleType(1, 0, 1));
        }
        [TestMethod]
        public void GetTriangleType_ThrowsExceptionOnZeroSideC()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleInfo.TriangleInfo.GetTriangleType(1, 1, 0));
        }
        #endregion
    }
}
