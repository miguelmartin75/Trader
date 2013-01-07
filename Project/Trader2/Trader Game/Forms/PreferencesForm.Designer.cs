namespace Trader
{
    partial class PreferencesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openDefaultFileLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(2, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(344, 240);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // openDefaultFileLabel
            // 
            this.openDefaultFileLabel.AutoSize = true;
            this.openDefaultFileLabel.Location = new System.Drawing.Point(-1, 242);
            this.openDefaultFileLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.openDefaultFileLabel.Name = "openDefaultFileLabel";
            this.openDefaultFileLabel.Size = new System.Drawing.Size(164, 13);
            this.openDefaultFileLabel.TabIndex = 2;
            this.openDefaultFileLabel.TabStop = true;
            this.openDefaultFileLabel.Text = "Click to open the default save file";
            this.openDefaultFileLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.openDefaultFileLabel_LinkClicked);
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 263);
            this.Controls.Add(this.openDefaultFileLabel);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "PreferencesForm";
            this.ShowIcon = false;
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.LinkLabel openDefaultFileLabel;

    }
}