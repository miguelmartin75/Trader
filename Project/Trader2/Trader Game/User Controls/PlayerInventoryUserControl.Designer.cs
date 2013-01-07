namespace Trader
{
    partial class PlayerInventoryUserControl
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
            System.Windows.Forms.Label label1;
            this.capacityProgressBar = new System.Windows.Forms.ProgressBar();
            this.capacityLabel = new System.Windows.Forms.Label();
            this.dropButton = new System.Windows.Forms.Button();
            this.sellButton = new System.Windows.Forms.Button();
            this.plainInventoryUserControl = new Trader.PlainInventoryUserControl();
            label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(4, 318);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 24);
            label1.TabIndex = 0;
            label1.Text = "Capacity";
            // 
            // capacityProgressBar
            // 
            this.capacityProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.capacityProgressBar.Location = new System.Drawing.Point(4, 346);
            this.capacityProgressBar.Margin = new System.Windows.Forms.Padding(4);
            this.capacityProgressBar.Name = "capacityProgressBar";
            this.capacityProgressBar.Size = new System.Drawing.Size(133, 28);
            this.capacityProgressBar.TabIndex = 1;
            // 
            // capacityLabel
            // 
            this.capacityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.capacityLabel.AutoSize = true;
            this.capacityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capacityLabel.Location = new System.Drawing.Point(145, 352);
            this.capacityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.capacityLabel.Name = "capacityLabel";
            this.capacityLabel.Size = new System.Drawing.Size(32, 20);
            this.capacityLabel.TabIndex = 2;
            this.capacityLabel.Text = "0/0";
            // 
            // dropButton
            // 
            this.dropButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dropButton.Location = new System.Drawing.Point(267, 351);
            this.dropButton.Name = "dropButton";
            this.dropButton.Size = new System.Drawing.Size(77, 25);
            this.dropButton.TabIndex = 5;
            this.dropButton.Text = "Drop";
            this.dropButton.UseVisualStyleBackColor = true;
            this.dropButton.Click += new System.EventHandler(this.dropButton_Click);
            // 
            // sellButton
            // 
            this.sellButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sellButton.Location = new System.Drawing.Point(350, 352);
            this.sellButton.Name = "sellButton";
            this.sellButton.Size = new System.Drawing.Size(75, 23);
            this.sellButton.TabIndex = 7;
            this.sellButton.Text = "Sell";
            this.sellButton.UseVisualStyleBackColor = true;
            this.sellButton.Click += new System.EventHandler(this.sellButton_Click);
            // 
            // plainInventoryUserControl
            // 
            this.plainInventoryUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plainInventoryUserControl.Inventory = null;
            this.plainInventoryUserControl.Location = new System.Drawing.Point(0, 0);
            this.plainInventoryUserControl.Name = "plainInventoryUserControl";
            this.plainInventoryUserControl.Size = new System.Drawing.Size(428, 315);
            this.plainInventoryUserControl.TabIndex = 8;
            // 
            // PlayerInventoryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.plainInventoryUserControl);
            this.Controls.Add(this.sellButton);
            this.Controls.Add(this.dropButton);
            this.Controls.Add(this.capacityLabel);
            this.Controls.Add(this.capacityProgressBar);
            this.Controls.Add(label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PlayerInventoryUserControl";
            this.Size = new System.Drawing.Size(428, 378);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar capacityProgressBar;
        private System.Windows.Forms.Label capacityLabel;
        private System.Windows.Forms.Button dropButton;
        private System.Windows.Forms.Button sellButton;
        private PlainInventoryUserControl plainInventoryUserControl;
    }
}
