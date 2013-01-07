namespace Trader
{
    partial class ItemUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemPictureBox = new System.Windows.Forms.PictureBox();
            this.selectCheckBox = new System.Windows.Forms.CheckBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.weightLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // itemPictureBox
            // 
            this.itemPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.itemPictureBox.Location = new System.Drawing.Point(4, 4);
            this.itemPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.itemPictureBox.Name = "itemPictureBox";
            this.itemPictureBox.Size = new System.Drawing.Size(65, 66);
            this.itemPictureBox.TabIndex = 1;
            this.itemPictureBox.TabStop = false;
            // 
            // selectCheckBox
            // 
            this.selectCheckBox.AutoSize = true;
            this.selectCheckBox.Location = new System.Drawing.Point(79, 4);
            this.selectCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.selectCheckBox.Name = "selectCheckBox";
            this.selectCheckBox.Size = new System.Drawing.Size(67, 21);
            this.selectCheckBox.TabIndex = 2;
            this.selectCheckBox.Text = "Name";
            this.selectCheckBox.UseVisualStyleBackColor = true;
            this.selectCheckBox.CheckedChanged += new System.EventHandler(this.selectCheckBox_CheckedChanged);
            // 
            // valueLabel
            // 
            this.valueLabel.AutoSize = true;
            this.valueLabel.Location = new System.Drawing.Point(76, 25);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(48, 17);
            this.valueLabel.TabIndex = 3;
            this.valueLabel.Text = "Value:";
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Location = new System.Drawing.Point(76, 42);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(56, 17);
            this.weightLabel.TabIndex = 5;
            this.weightLabel.Text = "Weight:";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(76, 59);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(60, 17);
            this.amountLabel.TabIndex = 6;
            this.amountLabel.Text = "Amount:";
            // 
            // amountNumericUpDown
            // 
            this.amountNumericUpDown.Location = new System.Drawing.Point(79, 80);
            this.amountNumericUpDown.Name = "amountNumericUpDown";
            this.amountNumericUpDown.Size = new System.Drawing.Size(67, 22);
            this.amountNumericUpDown.TabIndex = 7;
            this.amountNumericUpDown.ValueChanged += new System.EventHandler(this.amountNumericUpDown_ValueChanged);
            // 
            // ItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.amountNumericUpDown);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.valueLabel);
            this.Controls.Add(this.selectCheckBox);
            this.Controls.Add(this.itemPictureBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ItemUserControl";
            this.Size = new System.Drawing.Size(196, 104);
            ((System.ComponentModel.ISupportInitialize)(this.itemPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox itemPictureBox;
        private System.Windows.Forms.CheckBox selectCheckBox;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.NumericUpDown amountNumericUpDown;
    }
}
