using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Trader
{
    public class Inventory : ICodeable
    {
        #region Public Static Data

        /// <summary>
        /// The default maximum amount of items in the inventory.
        /// </summary>
        public static int DefaultMaxAmountOfItems = 10;

        #endregion



        #region Constructors

        /// <summary>
        /// Sets the inventory to have default settings.
        /// </summary>
        public Inventory()
        {
            MaxWeight = DefaultMaxAmountOfItems;
        }


		/// <summary>
		/// Initializes a new instance of the <see cref="Trader.Inventory"/> class.
		/// </summary>
		/// <param name='maxCapacity'>
		/// Max capacity of the inventory.
		/// </param>
        public Inventory(int maxCapacity)
        {
            MaxWeight = maxCapacity;
        }

        #endregion



        #region Public Methods

        /// <summary>
        /// Adds an item to the inventory.
        /// </summary>
        /// <param name="item">The item you wish to add.</param>
        public void Add(Item item)
        {
            if (CanHold(item))
            {
                items.Add(item);
            }
        }


        /// <summary>
        /// Removes an item.
        /// </summary>
        /// <param name="item">The item you wish to remove.</param>
        public void Remove(Item item)
        {
            items.Remove(item);
        }


        /// <summary>
        /// Determines whether the inventory can hold the item.
        /// </summary>
        /// <param name="item">The item you wish to check for.</param>
        /// <returns>true if the inventory can hold the item.</returns>
        public bool CanHold(Item item)
        {
            // if there is enough space for the item to be added.
            // Then we can hold it.
            return (MaxWeight == -1) || (Weight + item.Weight < MaxWeight);
        }


        public double GetWeight(Item[] items)
        {
            double weight = 0;
            foreach (Item item in items)
            {
                weight += item.Weight;
            }

            return weight;
        }


        public bool CanHold(Item[] items)
        {
            return (MaxWeight == -1 || (GetWeight(items) < MaxWeight));
        }


        public int CountDuplicateItems(Item item)
        {
            return CountDuplicateItems(item.ID);
        }


        public int CountDuplicateItems(int id)
        {
            int result = 0;
            foreach (Item item in items)
            {
                if (item.ID == id)
                {
                    result++;
                }
            }

            return result;
        }


        public Item[] ItemsWithId(int id)
        {
            List<Item> temp = new List<Item>();
            foreach (Item item in items)
            {
                if (item.ID == id)
                {
                    temp.Add(item);
                }
            }

            return temp.ToArray();
        }


        /// <summary>
        /// Determines whether the inventory contains an item.
        /// </summary>
        /// <param name="item">The item you wish to check for.</param>
        /// <returns>true if the inventory does.</returns>
        public bool Contains(Item item)
        {
            return items.Contains(item);
        }


        public void Clear()
        {
            items.Clear();
        }

        #endregion



        #region Public Properties

        public int Count
        {
            get
            {
                int result = 0;
                foreach (Item item in items)
                {
                    result++;
                }

                return result;
            }
        }

        /// <summary>
        /// The weight of the bag.
        /// </summary>
        public double Weight
        {
            get
            {
                double weight = 0;

                foreach (Item item in items)
                {
                    weight += item.Weight;
                }

                return weight;
            }
        }

        /// <summary>
        /// The maximum amount of items that is allowed in the inventory.
        /// -1 implies there is a finite amount of items that can be added.
        /// </summary>
        public double MaxWeight
        {
            get;
            set;
        }

        /// <summary>
        /// The items that are in the inventory.
        /// </summary>
        public Item[] Items
        {
            get
            {
                return items.ToArray();
            }
        }


        public Item[] ItemsWithoutDuplicates
        {
            get
            {
                List<Item> temp = new List<Item>();
                foreach (Item item in items)
                {
                    bool shouldAddToList = true;
                    foreach (Item item1 in temp)
                    {
                        if (item1.ID == item.ID)
                        {
                            shouldAddToList = false;
                        }
                    }

                    if (shouldAddToList)
                    {
                        temp.Add(item);
                    }
                }


                return temp.ToArray();
            }
        }

        #endregion



        #region Private Instance Variables

        /// <summary>
        /// A list of items in the inventory.
        /// </summary>
        private List<Item> items = new List<Item>();

        #endregion



		#region ICodeable implementation

		public void ReadFromStream (StreamReader streamReader)
		{
			MaxWeight = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
			int newCapcity = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));

			items.Clear();

			for(int i = 0; i < newCapcity; ++i)
			{
				// read a line, since each item begins with "Item:"
				streamReader.ReadLine();

				// Create an item
				Item item = new Item();
				item.ReadFromStream(streamReader);

				items.Add(item);
			}
		}


		public void WriteToStream (StreamWriter streamWriter)
		{
			streamWriter.WriteLine("Max Capacity=" + MaxWeight.ToString());
			streamWriter.WriteLine("Capacity=" + Count.ToString());


			foreach (Item item in Items)
			{
				streamWriter.WriteLine("Item:");
				item.WriteToStream(streamWriter);
			}
		}

		#endregion
    }
}
