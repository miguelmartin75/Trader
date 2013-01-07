using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameLib;

namespace Trader
{
    /// <summary>
    /// Resembles a shop in the Trader program.
    /// </summary>
    public class Shop : NameableObject
    {
		#region Constructors

		public Shop()
		{
		}


		public Shop(string name)
            : base(name)
		{
		}

		#endregion



        #region Public Methods

        /// <summary>
        /// Determines the price of an item
        /// </summary>
        /// <param name="item">The price of the Item</param>
        /// <returns>The price of an item</returns>
        public Money PriceOf(Item item)
        {
            if (!itemPriceList.ContainsKey(item))
            {
                return new Money();
            }

            return itemPriceList[item];
        }


        public void Add(Item item)
        {
            itemsToSell.Add(item);

            if (!itemPriceList.ContainsKey(item))
            {
                itemPriceList.Add(item, GenerateNewPriceForItem(item));
            }
        }


        public void Remove(Item item)
        {
            itemsToSell.Remove(item);

            if (!itemPriceList.ContainsKey(item))
            {
                itemPriceList.Remove(item);
            }
        }


        public void RandomizePriceList()
        {
            foreach (Item item in itemsToSell.Items)
            {
                itemPriceList[item] = GenerateNewPriceForItem(item);
            }
        }


        #endregion



        #region Public Properties and Variables

        /// <summary>
		/// The minimum profit percentage.
		/// </summary>
		public int MinProfitPercentage = 10;


		/// <summary>
		/// The max profit percentage.
		/// </summary>
		public int MaxProfitPercentage = 50;

        
        /// <summary>
        /// The items the shop will sell.
        /// </summary>
		public Inventory ItemsToSell
		{
            get
            {
                return itemsToSell;
            }
		}


		/// <summary>
        /// The Location the shop is located upon.
        /// </summary>
        public Location Location
        {
            get;
            set;
        }
        
		#endregion



        #region Private Instance Variables

        /// <summary>
        /// The items that are available to sell
        /// </summary>
        private Inventory itemsToSell = new Inventory(-1);


        /// <summary>
        /// The shop's price list
        /// </summary>
        private Dictionary<Item, Money> itemPriceList = new Dictionary<Item, Money>();


        /// <summary>
        /// A random number generator
        /// </summary>
        private static Random random = new Random();


        #endregion



        #region Private Methods

        private Money GenerateNewPriceForItem(Item item)
        {
            Money money = new Money();

            double randomPercentage = 0.0;
            randomPercentage = ((random.Next(MaxProfitPercentage) + MinProfitPercentage) / 100.0);


            money.Amount = item.Value + (item.Value * randomPercentage);

            return money;
        }

        #endregion



        #region Overridden Methods

        public override void ReadFromStream (StreamReader streamReader)
		{
			base.ReadFromStream(streamReader);

			MinProfitPercentage = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
			MaxProfitPercentage = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
		}


		public override void WriteToStream (StreamWriter streamWriter)
		{
			base.WriteToStream(streamWriter);

			streamWriter.WriteLine("Min Profit Percentage=" + MinProfitPercentage.ToString());
			streamWriter.WriteLine("Max Profit Percentage=" + MaxProfitPercentage.ToString());
		}

		#endregion
    }
}
