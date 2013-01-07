using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;


namespace Trader
{
	public class TraderGame : GameLib.Scene, ICodeable
    {
        private static TraderGame instance;
        public static TraderGame Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TraderGame();
                }

                return instance;
            }
        }


		/// <summary>
		/// The images that are used in the game.
		/// </summary>
		public Dictionary<int, Image> ImageCache = new Dictionary<int, Image>();


		public const string BaseDirectory = "Resources/Images/";


        #region Constructors

        /// <summary>
        /// Private, since this class is a singleton.
        /// </summary>
        private TraderGame ()
        {
            this.Player.Name = "Name";
            this.Player.Money.Amount = 100.0;
		}

        #endregion



        #region Public Methods

        public void BuyFromShop(Shop shop, Player player, Item[] itemsToBuy)
        {
            Money price = PriceOf(itemsToBuy, shop);

            if (player.Money.Amount < price.Amount)
            {
                throw new Exception("You only have: " + player.Money.ToString() + ", the items you wish to buy cost: " + PriceOf(itemsToBuy, shop).ToString());
            }

            if (!player.Inventory.CanHold(itemsToBuy))
            {
                throw new Exception("You cannot hold the items that you wish to purchase!");
            }


            foreach (Item item in itemsToBuy)
            {
                Money priceOfItem = shop.PriceOf(item);

                player.Money.Amount -= priceOfItem.Amount;
                player.Inventory.Add(item);

                shop.Remove(item);
            }
        }


        public Money PriceOf(Item[] items, Shop shop)
        {
            Money money = new Money();
            for(int i = 0; i < items.Length; ++i)
            {
                money.Amount += shop.PriceOf(items[i]).Amount;
            }

            return money;
        }
        // TOOD

        public void SellToShop(Shop shop, Player player, Item[] itemsToSell)
        {
            for(int i = 0; i < itemsToSell.Length; ++i)
            {
                Item item = itemsToSell[i];

                player.Money.Amount += shop.PriceOf(item).Amount;
                player.Inventory.Remove(item);

                shop.Add(item);
            }
        }


        public void Add(Location location)
        {
            locations.Add(location);
        }


        public void Remove(Location location)
        {
            locations.Remove(location);
        }

        public void Add(Item item)
        {
            items.Add(item);
        }

        public void Remove(Item item)
        {
            items.Remove(item);
        }


        public Money CalculateCostToUpgradeInventory(Player player)
        {
            return new Money(preferences.BaseBagUpgradePrice);
        }

        public void UpgradeInventory(Player player)
        {
            Money price = CalculateCostToUpgradeInventory(player);
            if (price.Amount > player.Money.Amount)
            {
                throw new System.Exception("Upgrade costs: " + price.ToString() + ", you have: " + player.Money.ToString());
            }

            // upgrade the inventory
            player.Inventory.MaxWeight += 5;
            player.Money.Amount -= price.Amount;

            preferences.BaseBagUpgradePrice += (int)(preferences.BaseBagUpgradePrice * preferences.BagUpgradePricePercentageIncrease / 100.0);
        }


        #endregion



        #region Events

        public enum EnemyInvolvement
        {
            Null,
            Run,
            Fight
        }


        public enum LottoOptions
        {
            LoseCredits,
            WinCredits,
            NothingHappens
        }


        public delegate EnemyInvolvement PlayerEnemyDelegate(object sender, Enemy withWho);


        public delegate void PlayerLottoDelegate(object sender, string desc);


        public delegate void PlayerMoneyDelegate(object sender, bool decreaseMoney, Money money, string reason);



        /// <summary>
        /// An event that occurs when a player wins or loses money
        /// </summary>
        public event PlayerMoneyDelegate OnPlayerLosesOrGainsMoney;


        /// <summary>
        /// An event occurs when the player gets in the lottery.
        /// </summary>
        public event PlayerLottoDelegate OnPlayerEntersTheLotteryEvent;


        /// <summary>
        /// An event occurs when a player is interupted by an enemy.
        /// </summary>
        public event PlayerEnemyDelegate OnPlayerIsInteruptedByEnemyEvent;

        #endregion



        #region Public Properties

        private int amountOfItemsPerShop = 3;
        public int AmountOfItemsPerShop
        {
            get
            {
                return amountOfItemsPerShop;
            }
            set
            {
                amountOfItemsPerShop = value;
            }
        }


        /// <summary>
        /// The current location the player is in
        /// </summary>
        public Location CurrentLocation
        {
            set
            {
                if (value == null)
                {
                    return;
                }

                if (!locations.Contains(value))
                {
                    locations.Add(value);
                }

                Player.Location = value;

                if (value.Shops != null && value.Shops.Length > 0)
                {
                    CurrentShop = value.Shops[0];
                }
                else
                {
                    CurrentShop = null;
                }

                Update();
            }
            get
            {
                return Player.Location;
            }
        }


        /// <summary>
        /// The avaliable locations within the game
        /// </summary>
        public Location[] AvaliableLocations
        {
            get
            {
                return locations.ToArray();
            }
        }


        public Shop CurrentShop
        {
            get;
            set;
        }


        /// <summary>
        /// The player in the game
        /// </summary>
        public Player Player
        {
            get
            {
                return player;
            }
        }


        /// <summary>
        /// The preferences of the game.
        /// </summary>
        public GamePreferences Preferences
        {
            get
            {
                return preferences;
            }
            set
            {
                preferences = value;
            }
        }

        #endregion



        #region Overidden Methods

        public override void Initialize ()
		{
			base.Initialize ();

            this.Player.Location = locations[0];
            if (CurrentLocation.Shops != null && CurrentLocation.Shops.Length > 0)
            {
                this.CurrentShop = CurrentLocation.Shops[0];
            }

			this.Player.Health.Current = this.Player.Health.Max;

            if (this.Player.Money.Amount <= this.Preferences.DefaultMoney.Amount)
            {
                this.Player.Money.Amount = this.Preferences.DefaultMoney.Amount;
            }

			// add all the items to the shops
			// but, we require 3 items per shop.
			foreach (Location location in locations) 
			{
				foreach (Shop shop in location.Shops) 
				{
                    shop.ItemsToSell.Clear();

                    List<Item> itemsToAdd = new List<Item>();

                    for (int i = 0; i < AmountOfItemsPerShop; ++i)
                    {
                        Item itemToAdd = null;
                        while (itemsToAdd.Contains(itemToAdd) || itemToAdd == null)
                        {
                            itemToAdd = items[random.Next(items.Count)];
                        }

                        itemsToAdd.Add(itemToAdd);
                    }

                    foreach(Item item in itemsToAdd)
                    {
                        for (int j = 0; j < random.Next(100) + 1; ++j)
                        {
                            shop.Add(itemsToAdd[random.Next(itemsToAdd.Count)]);
                        }
                    }
				}
			}


            ImageCache.Clear();
			// Load item images into play
			foreach (Item item in items) 
			{
                string filepath = BaseDirectory + "Item" + item.ID.ToString() + ".png";

                if (!File.Exists(filepath))
                {
                    System.Windows.Forms.MessageBox.Show("\"" + filepath + "\"" + " does not exsist", "Warning", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                }

                Bitmap bitmap = new Bitmap(filepath);

				ImageCache.Add(item.ID, bitmap);
			}
		}


		public override void Update ()
		{
			base.Update();


            // if the player has NO money
            // or has NO health left, we'll end the game
            if (Player.Money.Amount <= 0 || Player.Health.Current <= Player.Health.Min)
            {
                IsSceneOver = true;
            }


            /*
                 There must be a chance of two random events :
                 - Lottery / Stumble upon a wallet / ticket in a raffle etc etc
                 - Attacked by bandits / robbers / unicorns etc etc
            */

            // 0 indicates no random event
            // 1 indicates the lottery
            // 2 indicates bandits
            int randomEvent = random.Next(3);

            switch (randomEvent)
            {
                case 0:
                    /* do nothing */
                    break;
                case 1:
                    lotteryEvent();
                    break;
                case 2:
                    enemyEvent();
                    break;
            }
		}

        #endregion



        #region Private Methods

        private void enemyEvent()
        {
            if (OnPlayerIsInteruptedByEnemyEvent == null || enemies.Count <= 0)
            {
                return;
            }

            Enemy enemy = enemies[random.Next(enemies.Count)];
            bool userWishesToFight = OnPlayerIsInteruptedByEnemyEvent(this, enemy) == EnemyInvolvement.Fight;


            /*
                You can stay at fight and have a 50% chance to win
                   : if you win you gain a randomized loot reward
                   : if you lose you lose all but 10 credits.
                You can run with 75% chance to lose half your credits.
             */
            

            if (userWishesToFight)
            {
                bool playerWonFight = (random.Next(2) == 1);
                if (playerWonFight)
                {
                    Money randomMoneyAmount = generateRandomMoneyAmount();
                    player.Money.Amount += randomMoneyAmount.Amount;

                    if(this.OnPlayerLosesOrGainsMoney != null)
                        this.OnPlayerLosesOrGainsMoney(this, false, randomMoneyAmount, "You won against the enemy: " + enemy.Name);
                }
                else
                {
                    Money moneyLost = new Money(player.Money.Amount - 10);

                    player.Money.Amount -= Math.Abs(moneyLost.Amount);
                    player.Health.Current-= enemy.DamageAmount;

                    if(this.OnPlayerLosesOrGainsMoney != null)
                        this.OnPlayerLosesOrGainsMoney(this, true, moneyLost, "You lost against the enemy: " + enemy.Name);
                }
            }
            else
            {
                int randomPercentage = random.Next(100) + 1;
                if (randomPercentage <= 75)
                {
                    Money decreasedMoneyAmount = new Money(player.Money.Amount / 2.0);
                    this.player.Money.Amount -= decreasedMoneyAmount.Amount;

                    this.OnPlayerLosesOrGainsMoney(this, true, decreasedMoneyAmount, "You attempted to run away, but failed!");
                }
            }
        }


        private void lotteryEvent()
        {
            if (OnPlayerEntersTheLotteryEvent != null)
            {
                OnPlayerEntersTheLotteryEvent(this, "You entered the lottery!");
            }

            // detemines if the player won money
            int percentageToWin = random.Next(100) + 1;

            if (OnPlayerLosesOrGainsMoney != null)
            {
                /*
                   50% chance to double your money.
                   25% chance nothing happens.
                   25% chance to lose half your credits.
                 */

                Money moneyLostOrGained = null;

                LottoOptions options = LottoOptions.NothingHappens;

                // 50%
                if (percentageToWin < 50)
                {
                    options = LottoOptions.WinCredits;
                    moneyLostOrGained = new Money(player.Money.Amount / 2.0);
                    player.Money.Amount += moneyLostOrGained.Amount;
                }
                // 25%
                else if (percentageToWin < 75)
                {
                    options = LottoOptions.LoseCredits;
                    moneyLostOrGained = new Money(player.Money.Amount / 2.0);
                    player.Money.Amount -= moneyLostOrGained.Amount;
                }
                // 25%
                else
                {
                    options = LottoOptions.NothingHappens;
                }


                this.OnPlayerLosesOrGainsMoney
                    (
                    this,
                    options != LottoOptions.WinCredits,
                    moneyLostOrGained, 
                    options == LottoOptions.WinCredits ? "You won the lottery!" : "You lost the lottery!"
                    );
            }
        }


        private Money generateRandomMoneyAmount()
        {
            return new Money(random.NextDouble() * Player.Money.Amount);
        }

        #endregion



        #region ICodeable Interface Implementation

        public void ReadFromStream(StreamReader streamReader)
        {
            items.Clear();
            enemies.Clear();
            locations.Clear();

            for (; !streamReader.EndOfStream; )
            {
                string line = streamReader.ReadLine();

                if (Program.IsComment(line))
                {
                    continue;
                }
                else
                {
                    switch (line.ToLower())
                    {
                        case "gamepreferences:":
                            Preferences.ReadFromStream(streamReader);
                            break;
                        case "player:":
                            Player.ReadFromStream(streamReader);
                            break;
                        case "enemy:":
                            enemies.Add(StreamUtilities.Create<Enemy>(new Enemy(), streamReader));
                            break;
                        case "item:":
                            items.Add(StreamUtilities.Create<Item>(new Item(), streamReader));
                            break;
                        case "location:":
                            locations.Add(StreamUtilities.Create<Location>(new Location(), streamReader));
                            break;
                        default:
                            break;
                    }
                }
            }

            this.Initialize();
        }

        public void WriteToStream(StreamWriter streamWriter)
        {
            // preferences
            StreamUtilities.Write<GamePreferences>(preferences, streamWriter);

            // player
            StreamUtilities.Write<Player>(player, streamWriter);

            // locations
            StreamUtilities.Write<Location>(locations.ToArray(), streamWriter);

            // items
            StreamUtilities.Write<Item>(items.ToArray(), streamWriter);

            // enemies
            StreamUtilities.Write<Enemy>(enemies.ToArray(), streamWriter);

            streamWriter.Flush();
        }

        #endregion



        #region Private Variables

        /// <summary>
        /// The player in the game.
        /// </summary>
        private Player player = new Player();


		/// <summary>
		/// The locations that are in the game.
		/// </summary>
		private List<Location> locations = new List<Location>();


        /// <summary>
        /// All the enemies within the game.
        /// </summary>
        private List<Enemy> enemies = new List<Enemy>();


        /// <summary>
        /// All the item's within the game.
        /// </summary>
        private List<Item> items = new List<Item>();


        /// <summary>
        /// The preferences of the game.
        /// </summary>
        private GamePreferences preferences = new GamePreferences();


        private static Random random = new Random();

		#endregion
    }
}

