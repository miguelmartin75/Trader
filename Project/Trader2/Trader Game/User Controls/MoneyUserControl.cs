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
    public partial class MoneyUserControl : UserControl
    {
        #region Constructors

        public MoneyUserControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Public Methods

        public void UpdateForm()
        {
            moneyLabel.Text = Money.ToString();
        }

        #endregion



        #region Public Properties

        public Money Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
                UpdateForm();
            }
        }

        #endregion



        #region Private Instance Variables

        private Money money;

        #endregion
    }
}
