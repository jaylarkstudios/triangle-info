using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleInfo;

namespace TriangleInfoIntegrationTests
{
    [TestClass]
    public class TriangleInfoFormIntegrationTests
    {
        #region TextBox Tests
        [TestMethod]
        public void SideTextBoxesAllowValidPastedInput()
        {
            var form = new TriangleInfoFormForTest();

            form.SideAText = "0";
            form.SideBText = "200";
            form.SideCText = "3.14";

            Assert.AreEqual("0", form.SideAText);
            Assert.AreEqual("200", form.SideBText);
            Assert.AreEqual("3.14", form.SideCText);
        }
        [TestMethod]
        public void SideTextBoxesDontAllowInvalidPastedInput()
        {
            var form = new TriangleInfoFormForTest();

            form.SideAText = "10x";
            form.SideBText = "10a1";
            form.SideCText = "3.1.4";

            Assert.AreEqual(string.Empty, form.SideAText);
            Assert.AreEqual(string.Empty, form.SideBText);
            Assert.AreEqual(string.Empty, form.SideCText);
        }
        [TestMethod]
        public void SideTextBoxesAllowNumericInput()
        {
            var form = new TriangleInfoFormForTest();
            form.SideBText = "1";
            form.SideCText = "23";

            form.KeystrokeOnSideATextBox('4');
            form.KeystrokeOnSideBTextBox('5');
            form.KeystrokeOnSideCTextBox('6');

            Assert.AreEqual("4", form.SideAText);
            Assert.AreEqual("15", form.SideBText);
            Assert.AreEqual("236", form.SideCText);
        }
        [TestMethod]
        public void SideTextBoxesAllowFirstDecimal()
        {
            var form = new TriangleInfoFormForTest();
            form.SideBText = "1";
            form.SideCText = "23";

            form.KeystrokeOnSideATextBox('.');
            form.KeystrokeOnSideBTextBox('.');
            form.KeystrokeOnSideCTextBox('.');

            Assert.AreEqual(".", form.SideAText);
            Assert.AreEqual("1.", form.SideBText);
            Assert.AreEqual("23.", form.SideCText);
        }
        [TestMethod]
        public void SideTextBoxesDontAllowAlphaInput()
        {
            var form = new TriangleInfoFormForTest();
            form.SideBText = "1";
            form.SideCText = "23";

            form.KeystrokeOnSideATextBox('a');
            form.KeystrokeOnSideBTextBox('b');
            form.KeystrokeOnSideCTextBox('c');

            Assert.AreEqual("", form.SideAText);
            Assert.AreEqual("1", form.SideBText);
            Assert.AreEqual("23", form.SideCText);
        }
        [TestMethod]
        public void SideTextBoxesDontAllowSecondDecimal()
        {
            var form = new TriangleInfoFormForTest();
            form.SideAText = ".";
            form.SideBText = "0.1";
            form.SideCText = "2.34";

            form.KeystrokeOnSideATextBox('a');
            form.KeystrokeOnSideBTextBox('b');
            form.KeystrokeOnSideCTextBox('c');

            Assert.AreEqual(".", form.SideAText);
            Assert.AreEqual("0.1", form.SideBText);
            Assert.AreEqual("2.34", form.SideCText);
        }
        [TestMethod]
        public void SideTextBoxesWorkWithMultipleKeystrokes()
        {
            var form = new TriangleInfoFormForTest();

            form.KeystrokeOnSideATextBox('0');
            form.KeystrokeOnSideATextBox('.');
            form.KeystrokeOnSideATextBox('1');
            form.KeystrokeOnSideATextBox('x');
            form.KeystrokeOnSideATextBox('5');

            form.KeystrokeOnSideBTextBox('2');
            form.KeystrokeOnSideBTextBox('5');
            form.KeystrokeOnSideBTextBox('.');
            form.KeystrokeOnSideBTextBox('.');
            form.KeystrokeOnSideBTextBox('1');

            form.KeystrokeOnSideCTextBox('1');
            form.KeystrokeOnSideCTextBox('0');
            form.KeystrokeOnSideCTextBox('0');
            form.KeystrokeOnSideCTextBox(' ');
            form.KeystrokeOnSideCTextBox('?');

            Assert.AreEqual("0.15", form.SideAText);
            Assert.AreEqual("25.1", form.SideBText);
            Assert.AreEqual("100", form.SideCText);
        }
        #endregion

        #region Message Text Tests

        #endregion
    }

    public class TriangleInfoFormForTest : TriangleInfoForm
    {
        public string MsgInstruction { get { return INSTRUCTIONS; } }
        public string MsgInvalidInput { get { return ERR_INVALID_INPUT; } }
        public string MsgInvalidTriangle { get { return ERR_INVALID_TRIANGLE; } }
        public new string GetTriangleMessage(TriangleInfo.TriangleInfo info)
        {
            return "";
        }

        public string SideAText {
            get { return SideATextBox.Text; }
            set { SideATextBox.Text = value; }
        }
        public string SideBText
        {
            get { return SideBTextBox.Text; }
            set { SideBTextBox.Text = value; }
        }
        public string SideCText
        {
            get { return SideCTextBox.Text; }
            set { SideCTextBox.Text = value; }
        }
        public new string MessageText { get { return ""; } }

        /// <summary>
        /// Simulate a keystroke on Side A TextBox.
        /// </summary>
        /// <param name="keyChar">The character being input into the text box.</param>
        public void KeystrokeOnSideATextBox(char keyChar)
        {
            SimulateKeystroke(SideATextBox, keyChar);
        }
        /// <summary>
        /// Simulate a keystroke on Side B TextBox.
        /// </summary>
        /// <param name="keyChar">The character being input into the text box.</param>
        public void KeystrokeOnSideBTextBox(char keyChar)
        {
            SimulateKeystroke(SideBTextBox, keyChar);
        }
        /// <summary>
        /// Simulate a keystroke on Side C TextBox.
        /// </summary>
        /// <param name="keyChar">The character being input into the text box.</param>
        public void KeystrokeOnSideCTextBox(char keyChar)
        {
            SimulateKeystroke(SideCTextBox, keyChar);
        }

        private void SimulateKeystroke(System.Windows.Forms.TextBox textBox, char keyChar)
        {
            var args = new System.Windows.Forms.KeyPressEventArgs(keyChar);
            TextBox_KeyPress(textBox, args);
            if (args.Handled) return;
            textBox.Text += keyChar;
        }
    }
}
