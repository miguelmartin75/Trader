namespace Trader
{
    partial class PlayerUserControl
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
            this.healthBarUserControl = new Trader.HealthBarUserControl();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.moneyUserControl = new Trader.MoneyUserControl();
            this.PlayerInventoryUserControl = new Trader.PlayerInventoryUserControl();
            this.SuspendLayout();
            // 
            // healthBarUserControl
            // 
            this.healthBarUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.healthBarUserControl.Health = null;
            this.healthBarUserControl.Location = new System.Drawing.Point(0, 3);
            this.healthBarUserControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.healthBarUserControl.Name = "healthBarUserControl";
            this.healthBarUserControl.Size = new System.Drawing.Size(367, 32);
            this.healthBarUserControl.TabIndex = 0;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(3, 39);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(74, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Text = "Name";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // moneyUserControl
            // 
            this.moneyUserControl.Location = new System.Drawing.Point(81, 39);
            this.moneyUserControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            //this.moneyUserControl.Money = null;
            this.moneyUserControl.Name = "moneyUserControl";
            this.moneyUserControl.Size = new System.Drawing.Size(286, 24);
            this.moneyUserControl.TabIndex = 3;
            // 
            // PlayerInventoryUserControl
            // 
            this.PlayerInventoryUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //this.PlayerInventoryUserControl.Inventory = null;
            this.PlayerInventoryUserControl.Location = new System.Drawing.Point(0, 64);
            this.PlayerInventoryUserControl.Name = "PlayerInventoryUserControl";
            this.PlayerInventoryUserControl.Size = new System.Drawing.Size(370, 289);
            this.PlayerInventoryUserControl.TabIndex = 4;
            // 
            // PlayerUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlayerInventoryUserControl);
            this.Controls.Add(this.moneyUserControl);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.healthBarUserControl);
            this.Name = "PlayerUserControl";
            this.Size = new System.Drawing.Size(370, 353);
            this.Load += new System.EventHandler(this.PlayerUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HealthBarUserControl healthBarUserControl;
        private System.Windows.Forms.TextBox nameTextBox;
        private MoneyUserControl moneyUserControl;
        public PlayerInventoryUserControl PlayerInventoryUserControl;

    }
}
