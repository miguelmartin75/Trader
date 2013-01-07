using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameLib;

namespace Trader
{
    public class Player : NameableObject
    {
		#region Constructors

        public Player(string name = "Player")
            : base(name)
        {
            this.Inventory = new Inventory();
            this.Health = new Health();
        }


        public Player(string name, Location location, Money money)
            : this(name)
        {
            Location = location;
            this.money = money;
        }

		#endregion



		#region Public Properties

        /// <summary>
        /// The player's health
        /// </summary>
        public Health Health
        {
            get;
            set;
        }


        /// <summary>
        /// The location the Player is currently in.
        /// </summary>
        public Location Location
        {
            get;
            set;
        }


        /// <summary>
        /// This resembles the Player's bags.
        /// </summary>
        public Inventory Inventory
        {
            get;
            private set;
        }


        /// <summary>
        /// The player's money
        /// </summary>
        public Money Money
        {
            get
            {
                return money;
            }
        }
        private Money money = new Money();

		#endregion



		#region Overridden Methods

		public override void ReadFromStream (StreamReader streamReader)
		{
			base.ReadFromStream (streamReader);

			const int amountOfProperties = 3;
            for (int i = 0; (i < amountOfProperties) && !streamReader.EndOfStream; ) 
			{
                string line = streamReader.ReadLine();
                // If the line is a comment... or it's empty
                if (Program.IsComment(line))
                {
                    continue;
                }
                else
                {
                    switch (line.ToLower())
                    {
                        case "money:":
                            Money.ReadFromStream(streamReader);
                            break;
                        case "inventory:":
                            Inventory.ReadFromStream(streamReader);
                            break;
                        case "health:":
                            Health.ReadFromStream(streamReader);
                            break;
                        default:
                            break;
                    }
                }
                ++i;
			}
        }


        public override void WriteToStream(StreamWriter streamWriter)
        {
			base.WriteToStream(streamWriter);

            StreamUtilities.Write<Money>(Money, streamWriter);

            StreamUtilities.Write<Inventory>(Inventory, streamWriter);

            StreamUtilities.Write<Health>(Health, streamWriter);

            streamWriter.Flush();
        }

		#endregion
    }
}