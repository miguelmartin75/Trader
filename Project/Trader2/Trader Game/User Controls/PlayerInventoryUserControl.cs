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
    public partial class PlayerInventoryUserControl : UserControl, GameLib.IFormUpdateable
    {
        #region  Constructors

        public PlayerInventoryUserControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Updates the form
        /// </summary>
        public void UpdateForm()
        {
            capacityLabel.Text = Inventory.Weight.ToString() + "/" + Inventory.MaxWeight.ToString();
            double ratio = (double)Inventory.Weight / Inventory.MaxWeight;

            capacityProgressBar.Value = (int)(ratio * 100);

            plainInventoryUserControl.Inventory = Inventory;

            foreach (ItemUserControl itemUserControl in plainInventoryUserControl.ItemUserContols)
            {
                itemUserControl.Amount = Inventory.CountDuplicateItems(itemUserControl.Item);
            }
        }


        /// <summary>
        /// Drops the selected items
        /// </summary>
        public void DropSelectedItems()
        {
            if (SelectedItems.Items.Length <= 0)
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to drop your items?",
                                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
            {
                return;
            }


            foreach (Item item in SelectedItems.Items)
            {
                inventory.Remove(item);
            }

            UpdateForm();
        }


        /// <summary>
        /// Sells the selected items
        /// </summary>
        public void SellSelectedItems()
        {
            if (SelectedItems.Items.Length > 0)
            {
                if (OnUserWishesToSellItemsEvent != null)
                {
                    OnUserWishesToSellItemsEvent(this, SelectedItems.Items);
                }

                UpdateForm();
            }
        }


        #endregion



        #region Public Properties

        private Inventory inventory;

        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
                UpdateForm();
            }
        }


        public Inventory SelectedItems
        {
            get
            {
                Inventory inventory = new Inventory();
                foreach (ItemUserControl item in plainInventoryUserControl.SelectedControls)
                {
                    for (int i = 0; i < item.AmountOfItemsUserHasSelected; ++i)
                    {
                        inventory.Add(item.Item);
                    }
                }

                return inventory;
            }
        }

        #endregion



        #region Events

        public delegate void OnUserWishesToSellItems(object sender, Item[] itemsToSell);

        public event OnUserWishesToSellItems OnUserWishesToSellItemsEvent;


        // Drops items
        private void dropButton_Click(object sender, EventArgs e)
        {
            DropSelectedItems();
        }

        // Sells items
        private void sellButton_Click(object sender, EventArgs e)
        {
            SellSelectedItems();
        }

        #endregion
    }
}
