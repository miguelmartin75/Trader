using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trader
{
    public partial class HealthBarUserControl : UserControl
    {
        public HealthBarUserControl()
        {
            InitializeComponent();
        }


        public void UpdateForm()
        {   
            double percentage = (double)Health.Current / Health.Max;
            this.healthProgressBar.Value = (int)(100 * percentage);
        }


        private Health health;
        public Health Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
                UpdateForm();
            }
        }
    }
}
