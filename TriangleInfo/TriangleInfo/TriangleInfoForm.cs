using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangleInfo
{
    public partial class TriangleInfoForm : Form
    {
        protected const string INSTRUCTIONS = "Enter the lengths of the three sides of a triangle.";
        protected const string ERR_INVALID_INPUT = "Only valid, non-negative numbers are allowed!";
        protected const string ERR_INVALID_TRIANGLE = "No side's length can be greater than the sum of the other two.";
        protected const string VALID_RESULT_TEXT = "These side lengths produce a valid {0} triangle";

        protected TextBox SideATextBox
        {
            get { return sideATextBox; }
        }
        protected TextBox SideBTextBox
        {
            get { return sideBTextBox; }
        }
        protected TextBox SideCTextBox
        {
            get { return sideCTextBox; }
        }
        protected Label MessageLabel
        {
            get { return messageText; }
        }

        private double _sideA = 0;
        private double _sideB = 0;
        private double _sideC = 0;

        public TriangleInfoForm()
        {
            InitializeComponent();
            sideATextBox.KeyPress += TextBox_KeyPress;
            sideBTextBox.KeyPress += TextBox_KeyPress;
            sideCTextBox.KeyPress += TextBox_KeyPress;
        }

        protected void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!TriangleChecker.IsValidKeystroke((sender as TextBox).Text, e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void sideATextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateTextInput(sideATextBox, out _sideA);
        }

        private void sideBTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateTextInput(sideBTextBox, out _sideB);
        }

        private void sideCTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidateTextInput(sideCTextBox, out _sideC);
        }

        private void ValidateTextInput(TextBox textBox, out double sideLength)
        {
            // Allow text boxes that are empty or that contain only a single decimal.
            if (string.IsNullOrEmpty(textBox.Text) || textBox.Text == ".")
            {
                sideLength = 0;
            }
            // If current input is not a valid number, clear text box and display invalid input error.
            else if (!double.TryParse(textBox.Text, out sideLength))
            {
                messageText.Text = ERR_INVALID_INPUT;
                // Temporarily disable events to prevent firing when clearing the text box.
                DisableTextBoxEvents();
                textBox.Clear();
                EnableTextBoxEvents();
                return;
            }

            // If any inputs are blank, display instructions.
            if (string.IsNullOrEmpty(sideATextBox.Text) || string.IsNullOrEmpty(sideBTextBox.Text) || string.IsNullOrEmpty(sideCTextBox.Text))
            {
                messageText.Text = INSTRUCTIONS;
                return;
            }

            try
            {
                var info = TriangleChecker.GetTriangleStats(_sideA, _sideB, _sideC);

                // Side lenghts make a valid triangle! Display the triangle type.
                messageText.Text = GetTriangleMessage(info);
            }
            catch (ArgumentException)
            {
                // One or more side lengths are not valid; display invalid input error.
                messageText.Text = ERR_INVALID_INPUT;
            }
            catch (InvalidTriangleException)
            {
                // Side lengths do not make a valid triangle; display invalid triangle error.
                messageText.Text = ERR_INVALID_TRIANGLE;
            }
        }

        private void DisableTextBoxEvents()
        {
            sideATextBox.TextChanged -= sideATextBox_TextChanged;
            sideBTextBox.TextChanged -= sideBTextBox_TextChanged;
            sideCTextBox.TextChanged -= sideCTextBox_TextChanged;
        }
        private void EnableTextBoxEvents()
        {
            sideATextBox.TextChanged += sideATextBox_TextChanged;
            sideBTextBox.TextChanged += sideBTextBox_TextChanged;
            sideCTextBox.TextChanged += sideCTextBox_TextChanged;
        }

        protected string GetTriangleMessage(TriangleStats info)
        {
            return string.Format(VALID_RESULT_TEXT, TriangleChecker.GetTriangleName(info));
        }
    }
}
