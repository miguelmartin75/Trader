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
    public partial class PlayerUserControl : UserControl
    {
        #region Constructors

        public PlayerUserControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Public Methods

        public void UpdateForm()
        {
            if (player == null)
            {
                this.nameTextBox.Text = "Name";
                return;
            }

            this.nameTextBox.Text                           = Player.Name;
            this.healthBarUserControl.UpdateForm();
            this.moneyUserControl.UpdateForm();
            this.PlayerInventoryUserControl.UpdateForm();
        }

        #endregion



        #region Public Properties

        public Inventory SelectedItems
        {
            get
            {
                return this.PlayerInventoryUserControl.SelectedItems;
            }
        }


        public Player Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
                if (player != null)
                {
                    this.healthBarUserControl.Health = player.Health;
                    this.PlayerInventoryUserControl.Inventory = player.Inventory;
                    this.moneyUserControl.Money = player.Money;
                }

                UpdateForm();
            }
        }

        #endregion



        #region Events

        private void PlayerUserControl_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }


        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            player.Name = (sender as TextBox).Text;
        }

        #endregion



        #region Private Variables

        private Player player;

        #endregion
    }
}
