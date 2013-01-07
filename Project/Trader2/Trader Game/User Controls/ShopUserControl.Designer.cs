namespace Trader
{
    partial class ShopUserControl
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
            System.Windows.Forms.Label selectedItemsPriceLabel;
            this.buyButton = new System.Windows.Forms.Button();
            this.nameLabel = new System.Windows.Forms.Label();
            this.plainInventoryUserControl = new Trader.PlainInventoryUserControl();
            this.moneyUserControl = new Trader.MoneyUserControl();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            selectedItemsPriceLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(407, 39);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(90, 24);
            label1.TabIndex = 7;
            label1.Text = "Price List:";
            // 
            // selectedItemsPriceLabel
            // 
            selectedItemsPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            selectedItemsPriceLabel.AutoSize = true;
            selectedItemsPriceLabel.Location = new System.Drawing.Point(4, 449);
            selectedItemsPriceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            selectedItemsPriceLabel.Name = "selectedItemsPriceLabel";
            selectedItemsPriceLabel.Size = new System.Drawing.Size(140, 17);
            selectedItemsPriceLabel.TabIndex = 3;
            selectedItemsPriceLabel.Text = "Selected Items Price:";
            // 
            // buyButton
            // 
            this.buyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buyButton.Location = new System.Drawing.Point(503, 443);
            this.buyButton.Margin = new System.Windows.Forms.Padding(4);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(77, 28);
            this.buyButton.TabIndex = 0;
            this.buyButton.Text = "Buy";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(0, 5);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(86, 31);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // plainInventoryUserControl
            // 
            this.plainInventoryUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plainInventoryUserControl.Inventory = null;
            this.plainInventoryUserControl.Location = new System.Drawing.Point(0, 39);
            this.plainInventoryUserControl.Name = "plainInventoryUserControl";
            this.plainInventoryUserControl.Size = new System.Drawing.Size(401, 397);
            this.plainInventoryUserControl.TabIndex = 4;
            // 
            // moneyUserControl
            // 
            this.moneyUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.moneyUserControl.Location = new System.Drawing.Point(143, 446);
            //this.moneyUserControl.Money = null;
            this.moneyUserControl.Name = "moneyUserControl";
            this.moneyUserControl.Size = new System.Drawing.Size(341, 28);
            this.moneyUserControl.TabIndex = 5;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.priceTextBox.Location = new System.Drawing.Point(408, 67);
            this.priceTextBox.Multiline = true;
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.ReadOnly = true;
            this.priceTextBox.Size = new System.Drawing.Size(172, 369);
            this.priceTextBox.TabIndex = 8;
            // 
            // ShopUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.plainInventoryUserControl);
            this.Controls.Add(this.moneyUserControl);
            this.Controls.Add(selectedItemsPriceLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.buyButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ShopUserControl";
            this.Size = new System.Drawing.Size(584, 475);
            this.Load += new System.EventHandler(this.ShopUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Label nameLabel;
        private PlainInventoryUserControl plainInventoryUserControl;
        private MoneyUserControl moneyUserControl;
        private System.Windows.Forms.TextBox priceTextBox;
    }
}
