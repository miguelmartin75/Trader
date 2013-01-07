using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Trader
{
    public partial class PreferencesForm : Form
    {
        public static string FilepathToDefaultGameSave = "Resources\\DefaultGame.tgf";

        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void openDefaultFileLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(FilepathToDefaultGameSave);
        }
    }
}
