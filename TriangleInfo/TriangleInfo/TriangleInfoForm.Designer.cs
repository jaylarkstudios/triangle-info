namespace TriangleInfo
{
    partial class TriangleInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sideATextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sideBTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sideCTextBox = new System.Windows.Forms.TextBox();
            this.messageText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sideATextBox
            // 
            this.sideATextBox.Location = new System.Drawing.Point(13, 46);
            this.sideATextBox.Name = "sideATextBox";
            this.sideATextBox.Size = new System.Drawing.Size(100, 20);
            this.sideATextBox.TabIndex = 0;
            this.sideATextBox.TextChanged += new System.EventHandler(this.sideATextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Side A Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Side B Length";
            // 
            // sideBTextBox
            // 
            this.sideBTextBox.Location = new System.Drawing.Point(119, 46);
            this.sideBTextBox.Name = "sideBTextBox";
            this.sideBTextBox.Size = new System.Drawing.Size(100, 20);
            this.sideBTextBox.TabIndex = 2;
            this.sideBTextBox.TextChanged += new System.EventHandler(this.sideBTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Side C Length";
            // 
            // sideCTextBox
            // 
            this.sideCTextBox.Location = new System.Drawing.Point(225, 46);
            this.sideCTextBox.Name = "sideCTextBox";
            this.sideCTextBox.Size = new System.Drawing.Size(100, 20);
            this.sideCTextBox.TabIndex = 4;
            this.sideCTextBox.TextChanged += new System.EventHandler(this.sideCTextBox_TextChanged);
            // 
            // messageText
            // 
            this.messageText.AutoSize = true;
            this.messageText.Location = new System.Drawing.Point(12, 98);
            this.messageText.Name = "messageText";
            this.messageText.Size = new System.Drawing.Size(232, 13);
            this.messageText.TabIndex = 6;
            this.messageText.Text = "Enter the lengths of the three sides of a triangle.";
            // 
            // TriangleInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 142);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sideCTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sideBTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sideATextBox);
            this.Name = "TriangleInfoForm";
            this.Text = "Triangle Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sideATextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sideBTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sideCTextBox;
        private System.Windows.Forms.Label messageText;
    }
}

