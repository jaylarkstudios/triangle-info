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
    public partial class Form1 : Form
    {
        private const string INSTRUCTIONS = "Enter the lengths of the three sides of a triangle.";
        private const string ERR_INVALID_INPUT = "Only valid, non-negative numbers are allowed!";
        private const string ERR_INVALID_TRIANGLE = "No side's length can be greater than the sum of the other two.";
        private const string VALID_RESULT_TEXT = "These side lengths produce a valid {0} triangle";

        private double _sideA = 0;
        private double _sideB = 0;
        private double _sideC = 0;

        public Form1()
        {
            InitializeComponent();
            sideATextBox.KeyPress += TextBox_KeyPress;
            sideBTextBox.KeyPress += TextBox_KeyPress;
            sideCTextBox.KeyPress += TextBox_KeyPress;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
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
            // If current input is not a valid number, display invalid input error.
            if (!double.TryParse(textBox.Text, out sideLength))
            {
                messageText.Text = ERR_INVALID_INPUT;
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
                var info = TriangleChecker.GetTriangleInfo(_sideA, _sideB, _sideC);

                // Side lenghts make a valid triangle! Display the triangle type.
                messageText.Text = string.Format(VALID_RESULT_TEXT, GetTriangleName(info));
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
        private string GetTriangleName(TriangleInfo info)
        {
            var result = "";
            switch (info.Angle)
            {
                case TriangleAngle.Acute:
                    result = "acute";
                    break;
                case TriangleAngle.Right:
                    result = "right";
                    break;
                case TriangleAngle.Obtuse:
                    result = "obtuse";
                    break;
            }
            switch (info.Type)
            {
                case TriangleType.Equilateral:
                    // all equilateral triangles are also acute triangles, so no need to keep it in the name
                    result = "equilateral";
                    break;
                case TriangleType.Isosceles:
                    result += " isosceles";
                    break;
                case TriangleType.Scalene:
                    result += " scalene";
                    break;
            }
            return result;
        }
    }
}
