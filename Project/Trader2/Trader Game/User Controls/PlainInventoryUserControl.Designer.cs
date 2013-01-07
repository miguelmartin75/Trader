namespace Trader
{
    partial class PlainInventoryUserControl
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
            this.itemsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // itemsTableLayoutPanel
            // 
            this.itemsTableLayoutPanel.ColumnCount = 1;
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.itemsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.itemsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.itemsTableLayoutPanel.Name = "itemsTableLayoutPanel";
            this.itemsTableLayoutPanel.RowCount = 1;
            this.itemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.itemsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.itemsTableLayoutPanel.Size = new System.Drawing.Size(531, 442);
            this.itemsTableLayoutPanel.TabIndex = 0;
            // 
            // PlainInventoryUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.itemsTableLayoutPanel);
            this.Name = "PlainInventoryUserControl";
            this.Size = new System.Drawing.Size(531, 442);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel itemsTableLayoutPanel;

    }
}
