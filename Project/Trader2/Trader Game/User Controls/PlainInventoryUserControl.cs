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
    public partial class PlainInventoryUserControl : UserControl, GameLib.IFormUpdateable
    {
        #region Constructors

        public PlainInventoryUserControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Public Methods

        public void UpdateForm()
        {
            if (Inventory == null)
            {
                return;
            }
            

            foreach (ItemUserControl itemUserControl in ItemUserContols)
            {
                int amount = Inventory.CountDuplicateItems(itemUserControl.Item);
                itemUserControl.Amount = amount;

                itemUserControl.UpdateForm();
            }
        }

        #endregion



        #region Public Properties

        public ItemUserControl[] SelectedControls
        {
            get
            {
                List<ItemUserControl> items = new List<ItemUserControl>();

                foreach (ItemUserControl userControl in itemUserControls)
                {
                    if (userControl.IsSelected)
                    {
                        items.Add(userControl);
                    }
                }

                return items.ToArray();
            }
        }


        public ItemUserControl[] ItemUserContols
        {
            get
            {
                return itemUserControls.ToArray();
            }
        }


        public Inventory Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;

                this.itemUserControls.Clear();
                this.itemsTableLayoutPanel.Controls.Clear();
                if (Inventory == null)
                {
                    return;
                }

                // add all the items to the data grid view.
                foreach (Item item in Inventory.ItemsWithoutDuplicates)
                {
                    ItemUserControl itemUserControl = new ItemUserControl(item);

                    this.itemsTableLayoutPanel.Controls.Add(itemUserControl);
                    this.itemUserControls.Add(itemUserControl);
                }

                UpdateForm();
            }
        }

        #endregion



        #region Private Instance Variables

        private List<ItemUserControl> itemUserControls = new List<ItemUserControl>();

        private Inventory inventory;

        #endregion
    }
}
