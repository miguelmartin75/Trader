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
    public partial class ShopUserControl : UserControl, GameLib.IFormUpdateable
    {
        #region Constructors

        public ShopUserControl()
        {
            InitializeComponent();

            this.moneyUserControl.Money = new Money();
        }


        #endregion



        #region Public Methods

        public void UpdateForm()
        {
            if (shop == null)
            {
                this.nameLabel.Text = "Name";
                this.moneyUserControl.Money.Amount = 0;
                this.plainInventoryUserControl.Inventory = null;
                return;
            }

            this.nameLabel.Text = shop.Name;
            this.moneyUserControl.Money.Amount = PriceOfSelectedItems.Amount;
            this.moneyUserControl.UpdateForm();
            this.plainInventoryUserControl.UpdateForm();


            // Price list
            priceTextBox.Text = "";
            foreach (Item item in shop.ItemsToSell.ItemsWithoutDuplicates)
            {
                priceTextBox.Text += item.Name + " - " + shop.PriceOf(item).ToString() + Environment.NewLine;
            }
        }


        public void Buy()
        {
            if (OnUserWishesToBuyFromShopEvent != null)
            {
                List<Item> items = new List<Item>();
                foreach (ItemUserControl userControl in plainInventoryUserControl.SelectedControls)
                {
                    for (int i = 0; i < userControl.AmountOfItemsUserHasSelected; ++i)
                        items.Add(userControl.Item);
                }

                OnUserWishesToBuyFromShopEvent(this, items.ToArray());
            }
        }

        #endregion



        #region Public Properties

        private Shop shop;
        /// <summary>
        /// The shop that the Shop User Control
        /// is showing at the current time.
        /// </summary>
        public Shop Shop
        {
            get
            {
                return shop;
            }
            set
            {
                shop = value;

                if (shop != null)
                {
                    plainInventoryUserControl.Inventory = shop.ItemsToSell;

                    foreach (ItemUserControl userControl in plainInventoryUserControl.ItemUserContols)
                    {
                        userControl.OnUserChangesItemAmountEvent += userControl_OnUserChangesItemAmountEvent;
                        userControl.OnSelectedEvent += userControl_OnUserSelectedItemEvent;

                        userControl.Amount = plainInventoryUserControl.Inventory.CountDuplicateItems(userControl.Item);
                    }
                }
                UpdateForm();
            }
        }


        /// <summary>
        /// Resembles the price of all the selected items in the Shop.
        /// </summary>
        public Money PriceOfSelectedItems
        {
            get
            {
                Money price = new Money();
                ItemUserControl[] itemsSelected = this.plainInventoryUserControl.SelectedControls;

                foreach (ItemUserControl control in itemsSelected)
                {
                    price.Amount += Shop.PriceOf(control.Item).Amount * control.AmountOfItemsUserHasSelected;
                }

                return price;
            }
        }


        #endregion



        #region Events

        public delegate void OnUserWishesToBuyFromShop(object sender, Item[] itemsToBuy);

        public event OnUserWishesToBuyFromShop OnUserWishesToBuyFromShopEvent;


        private void ShopUserControl_Load(object sender, EventArgs e)
        {
            UpdateForm();
        }


        private void buyButton_Click(object sender, EventArgs e)
        {
            Buy();
        }


        void userControl_OnUserChangesItemAmountEvent(object sender, Item item, int newAmount)
        {
            UpdateForm();
        }


        void userControl_OnUserSelectedItemEvent(object sender, bool isSelected)
        {
            UpdateForm();
        }

        #endregion
    }
}
