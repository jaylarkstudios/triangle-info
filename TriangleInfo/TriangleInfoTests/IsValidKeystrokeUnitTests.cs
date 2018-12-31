using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleInfo;

namespace TriangleInfoUnitTests
{
    [TestClass]
    public class IsValidKeystrokeUnitTests
    {
        #region Valid Input Tests
        [TestMethod]
        public void ThrowsExceptionOnNullString()
        {
            Assert.ThrowsException<ArgumentException>(() => TriangleChecker.IsValidKeystroke(null, '1'));
        }
        [TestMethod]
        public void ReturnsTrueOnNumericalInput()
        {
            var isValid = TriangleChecker.IsValidKeystroke("", '0');
            isValid &= TriangleChecker.IsValidKeystroke("", '1');
            isValid &= TriangleChecker.IsValidKeystroke("", '2');
            isValid &= TriangleChecker.IsValidKeystroke("", '3');
            isValid &= TriangleChecker.IsValidKeystroke("", '4');
            isValid &= TriangleChecker.IsValidKeystroke("", '5');
            isValid &= TriangleChecker.IsValidKeystroke("", '6');
            isValid &= TriangleChecker.IsValidKeystroke("", '7');
            isValid &= TriangleChecker.IsValidKeystroke("", '8');
            isValid &= TriangleChecker.IsValidKeystroke("", '9');

            Assert.IsTrue(isValid);
        }
        [TestMethod]
        public void ReturnsTrueOnControlCharacterInput()
        {
            var isValid = TriangleChecker.IsValidKeystroke("", (char)0x0000);
            isValid &= TriangleChecker.IsValidKeystroke("", (char)0x001F);
            isValid &= TriangleChecker.IsValidKeystroke("", (char)0x007F);
            isValid &= TriangleChecker.IsValidKeystroke("", (char)0x0080);
            isValid &= TriangleChecker.IsValidKeystroke("", (char)0x009F);

            Assert.IsTrue(isValid);
        }
        [TestMethod]
        public void ReturnsTrueOnFirstPeriod()
        {
            var isValid = TriangleChecker.IsValidKeystroke("", '.');

            Assert.IsTrue(isValid);
        }
        [TestMethod]
        public void ReturnsFalseOnFirstPeriod()
        {
            var isValid = TriangleChecker.IsValidKeystroke("0.1", '.');

            Assert.IsFalse(isValid);
        }
        [TestMethod]
        public void ReturnsFalseOnInvalidCharacterInput()
        {
            var isValid = TriangleChecker.IsValidKeystroke("", 'a');
            isValid |= TriangleChecker.IsValidKeystroke("", 'B');
            isValid |= TriangleChecker.IsValidKeystroke("", '!');
            isValid |= TriangleChecker.IsValidKeystroke("", '*');
            isValid |= TriangleChecker.IsValidKeystroke("", '-');
            isValid |= TriangleChecker.IsValidKeystroke("", '+');
            isValid |= TriangleChecker.IsValidKeystroke("", ' ');

            Assert.IsFalse(isValid);
        }
        #endregion
    }
}
