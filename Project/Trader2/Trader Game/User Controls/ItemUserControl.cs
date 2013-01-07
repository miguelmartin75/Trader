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
    public partial class ItemUserControl : UserControl, GameLib.IFormUpdateable
    {
        #region Constructors

        public ItemUserControl()
        {
            InitializeComponent();
        }
        
        public ItemUserControl(Item item)
        {
            InitializeComponent();

            Item = item;
        }

        #endregion



        #region Public Methods

        public void UpdateForm()
        {
            if (Item == null)
            {
                return;
            }

            this.selectCheckBox.Text    = Item.Name;
            this.valueLabel.Text        = "Value: " + Item.Value.ToString();
            this.weightLabel.Text       = "Weight: " + Item.Weight.ToString();
            this.amountLabel.Text       = "Amount: " + Amount.ToString();
            this.amountNumericUpDown.Maximum = Amount;

            if (TraderGame.Instance.ImageCache.ContainsKey(this.Item.ID))
            {
                this.itemPictureBox.BackgroundImage = TraderGame.Instance.ImageCache[this.Item.ID];
            }
        }

        #endregion



        #region Public Properties

        /// <summary>
        /// The amount of items that this user control resembles
        /// </summary>
        public int Amount
        {
            get;
            set;
        }


        public int AmountOfItemsUserHasSelected
        {
            get
            {
                return (int)amountNumericUpDown.Value;
            }

            set
            {
                amountNumericUpDown.Value = value;
            }
        }


        public bool IsSelected
        {
            get
            {
                return this.selectCheckBox.Checked;
            }
            set
            {
                this.selectCheckBox.Checked = value;
            }
        }


        /// <summary>
        /// Resembles the Item the user control is viewing.
        /// </summary>
        public Item Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
                UpdateForm();
            }
        }


		public Image Image 
		{
			get 
			{
				return this.itemPictureBox.BackgroundImage;
			}
			set 
			{
				this.itemPictureBox.BackgroundImage = value;
			}
		}


        #endregion


        #region Events

        public delegate void OnUserChangesItemAmount(object sender, Item item, int newAmount);

        public event OnUserChangesItemAmount OnUserChangesItemAmountEvent;

        public delegate void OnSelected(object sender, bool isSelected);

        public event OnSelected OnSelectedEvent;

        private void amountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (OnUserChangesItemAmountEvent != null)
            {
                OnUserChangesItemAmountEvent(sender, this.Item, (int)this.amountNumericUpDown.Value);
            }
        }


        private void selectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OnSelectedEvent != null)
            {
                OnSelectedEvent(sender, this.selectCheckBox.Checked);
            }
        }

        #endregion


        #region Private Variables

        private Item item;

        #endregion
    }
}
