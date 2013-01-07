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
    public partial class MainForm : Form
    {
        private static string title = "Trader";

        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            this.game.OnSceneEnded += onPlayerLostGame;

			this.game.OnPlayerEntersTheLotteryEvent += this.onLotteryEntry;
			this.game.OnPlayerIsInteruptedByEnemyEvent += this.onPlayerIsInterrupted;
			this.game.OnPlayerLosesOrGainsMoney += this.onPlayerWinsOrLosesMoney;

            this.playerUserControl.PlayerInventoryUserControl.OnUserWishesToSellItemsEvent += onUserWishesToSellItems;

            this.shopUserControl.OnUserWishesToBuyFromShopEvent += onUserWishesToBuyItems;

            loadGameFromFilepath("Resources/DefaultGame.tgf");
            InitializeGui();
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Initializes the GUI
        /// </summary>
        public void InitializeGui()
        {
            clearLocationsInGui();
            clearShopsInGui();
            
            foreach (Location location in game.AvaliableLocations)
            {
                addLocationInGui(location);
            }


            if (game.CurrentLocation != null)
            {
                addShopsInGuiForLocation(game.CurrentLocation);
            }


            shopUserControl.Shop = game.CurrentShop;
            playerUserControl.Player = game.Player;

            UpdateForm();
        }


        public void UpdateForm()
        {
            this.Text = title + (filepathToGameFile.Length == 0 ? "" : " - " + filepathToGameFile);

            locationComboBox.SelectedItem = game.CurrentLocation;
            shopComboBox.SelectedItem = game.CurrentShop;

            playerUserControl.UpdateForm();
            shopUserControl.UpdateForm();
        }


        public void SwitchLocation(Location location)
        {
            if (location == null || location == game.CurrentLocation)
            {
                return;
            }

            game.CurrentLocation = location;

            clearShopsInGui();
            addShopsInGuiForLocation(game.CurrentLocation);

            UpdateForm();
        }


        public void SwitchShop(Shop shop)
        {
            if (shop == null || shop == game.CurrentShop)
            {
                return;
            }

            game.CurrentShop = shop;
            shop.RandomizePriceList();

            this.shopUserControl.Shop = game.CurrentShop;
        }


        #endregion



        #region Private Methods

        /// <summary>
        /// Loads the game from a file
        /// </summary>
        /// <param name="filepath">The filepath to the file that you wish to load from</param>
        private void loadGameFromFilepath(string filepath)
        {
            try
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(filepath))
                {
                    game.ReadFromStream(reader);
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InitializeGui();
        }

        /// <summary>
        /// Saves the game to a file
        /// </summary>
        /// <param name="filepath">The filepath where you wish to save the game to</param>
        private void saveGameToFilepath(string filepath)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filepath))
                {
                    game.WriteToStream(writer);
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void upgradeInventory()
        {
            Money costToUpgrade = game.CalculateCostToUpgradeInventory(game.Player);

            if (MessageBox.Show("An upgrade will cost: " + costToUpgrade + ", are you sure you wish to do this?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                game.UpgradeInventory(game.Player);
            }

            UpdateForm();
        }


        /// <summary>
        /// Gets a location that is in the game, by it's name
        /// </summary>
        /// <param name="p">The name of the location</param>
        /// <returns>The appropriate location</returns>
        private Location getLocationFromName(string p)
        {
            foreach (Location location in game.AvaliableLocations)
            {
                if (location.Name == p)
                {
                    return location;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets a shop that is in the game, by it's name.
        /// </summary>
        /// <param name="p">The name of the shop</param>
        /// <returns>The appropriate shop</returns>
        private Shop getShopFromName(string p)
        {
            foreach (Shop shop in game.CurrentLocation.Shops)
            {
                if (shop.Name == p)
                {
                    return shop;
                }
            }

            return null;
        }


        /// <summary>
        /// Clears all the locations in the GUI
        /// </summary>
        private void clearLocationsInGui()
        {
            locationComboBox.Items.Clear();
            locationComboBox.Text = "";
            locationToolStripMenuItem.DropDown.Items.Clear();
        }


        /// <summary>
        /// Clears all the shops in the GUI
        /// </summary>
        private void clearShopsInGui()
        {
            shopComboBox.Items.Clear();
            shopComboBox.Text = "";
            shopToolStripMenuItem.DropDown.Items.Clear();
        }

        /// <summary>
        /// Adds a location to the GUI
        /// </summary>
        /// <param name="location">The location you wish to add</param>
        private void addLocationInGui(Location location)
        {
            locationComboBox.Items.Add(location);
            
            locationToolStripMenuItem.DropDown.Items.Add(location.Name);
            locationToolStripMenuItem.DropDown.Items[locationToolStripMenuItem.DropDown.Items.Count - 1].Click += new EventHandler(locationItemsToolStripMenuItem_Click);
        }

        /// <summary>
        /// Adds a shop to the GUI
        /// </summary>
        /// <param name="shop">The shop you wish to add</param>
        private void addShopInGui(Shop shop)
        {
            shopComboBox.Items.Add(shop);
            
            shopToolStripMenuItem.DropDown.Items.Add(shop.Name);
            shopToolStripMenuItem.DropDown.Items[shopToolStripMenuItem.DropDown.Items.Count - 1].Click += new EventHandler(shopItemsToolStripMenuItem_Click);
        }

        /// <summary>
        /// Adds the shops that are in the location to the GUI
        /// </summary>
        /// <param name="location">The location that contains the shops</param>
        private void addShopsInGuiForLocation(Location location)
        {
            foreach (Shop shop in location.Shops)
            {
                addShopInGui(shop);
            }
        }

        #endregion



        #region Events

        // Windows form events

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Restart();
            saveFileDialog.FileName = openFileDialog.FileName = "";

            UpdateForm();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                saveFileDialog.FileName = openFileDialog.FileName;
                this.loadGameFromFilepath(openFileDialog.FileName);

                UpdateForm();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.FileName.Length == 0)
            {
                saveAsToolStripMenuItem_Click(sender, e);
                UpdateForm();
            }
            else
            {
                this.saveGameToFilepath(saveFileDialog.FileName);
            }

            this.filepathToGameFile = saveFileDialog.FileName;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.saveGameToFilepath(saveFileDialog.FileName);

                UpdateForm();
            }

            this.filepathToGameFile = saveFileDialog.FileName;
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PreferencesForm prefForm = new PreferencesForm();
            prefForm.Show();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextBoxSingleForm howToPlayForm = new TextBoxSingleForm("How To Play", Properties.Resources.How_To_Play);
            howToPlayForm.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TextBoxSingleForm aboutForm = new TextBoxSingleForm("About", Properties.Resources.About);
            aboutForm.Show();
        }

        private void buyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.shopUserControl.Buy();
        }

        private void sellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.playerUserControl.PlayerInventoryUserControl.SellSelectedItems();
        }

        private void dropItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.playerUserControl.PlayerInventoryUserControl.DropSelectedItems();
        }

        // occurs from the tool strip menu
		private void locationItemsToolStripMenuItem_Click (object sender, EventArgs e)
		{
            SwitchLocation(getLocationFromName(sender.ToString()));
		}

        private void locationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Location location = locationComboBox.SelectedItem as Location;

            SwitchLocation(location);
        }

        // occurs from the tool strip menu
        private void shopItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shop shop = getShopFromName(sender.ToString());

            SwitchShop(shop);
        }

        private void shopComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Shop shop = shopComboBox.SelectedItem as Shop;
            SwitchShop(shop);
        }

        private void upgradeInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                upgradeInventory();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Custom events

        private void onUserWishesToSellItems(object sender, Item[] itemsToSell)
        {
            if (itemsToSell == null || itemsToSell.Length == 0)
            {
                return;
            }

            if (MessageBox.Show("Are you sure you want to sell your items for: " + game.PriceOf(itemsToSell, game.CurrentShop).ToString(),
                                "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
            {
                return;
            }

            game.SellToShop(game.CurrentShop, game.Player, itemsToSell);

            UpdateForm();
        }

        private void onUserWishesToBuyItems(object sender, Item[] itemsToBuy)
        {
            if (itemsToBuy == null || itemsToBuy.Length <= 0)
            {
                return;
            }

            try
            {

                if (MessageBox.Show("Are you sure you want to buy these items, it will cost you: " + game.PriceOf(itemsToBuy, game.CurrentShop).ToString(),
                                    "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                {
                    return;
                }

                game.BuyFromShop(game.CurrentShop, game.Player, itemsToBuy);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            UpdateForm();
        }

		private void onLotteryEntry(object sender, string desc)
		{
			MessageBox.Show(desc, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		private void onPlayerWinsOrLosesMoney (object sender, bool decreaseMoney, Money money, string reason)
		{
            if (money != null && money.Amount > 0)
            {
                MessageBox.Show("You " + (decreaseMoney ? "lost " : "won ") + money.ToString() + ", because: " + reason, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Luckily, you did not lose or gain any money, because: "  + reason, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
		}

		private TraderGame.EnemyInvolvement onPlayerIsInterrupted (object sender, Enemy withWho)
		{
			if (MessageBox.Show (withWho.Name + " interrupted your travelling! Do you wish to fight?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk)
			    == DialogResult.Yes) 
			{
				return TraderGame.EnemyInvolvement.Fight;
			}

			return TraderGame.EnemyInvolvement.Run;
		}


        private void onPlayerLostGame(GameLib.Scene sender)
        {
            MessageBox.Show("Unfortunately you have lost the game! Press OK to restart the game.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            game.Restart();
            UpdateForm();
        }

        
        #endregion



        #region Private Variables

        private TraderGame game = TraderGame.Instance;


        private string filepathToGameFile
        {
            get
            {
                return openFileDialog.FileName;
            }
            set
            {
                openFileDialog.FileName = saveFileDialog.FileName = value;
            }
        }
        
        #endregion
    }
}
