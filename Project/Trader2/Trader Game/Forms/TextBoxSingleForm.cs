using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trader
{
    public partial class TextBoxSingleForm : Form
    {
        public TextBoxSingleForm()
        {
            InitializeComponent();
        }


        public TextBoxSingleForm(string title, string textToDisplay)
            : this()
        {
            this.Text = title;
            this.TextToDisplay = textToDisplay;
        }


        public string TextToDisplay
        {
            set
            {
                displayTextBox.Text = value;
            }
            get
            {
                return displayTextBox.Text;
            }
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
