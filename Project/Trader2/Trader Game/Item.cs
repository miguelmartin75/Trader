using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameLib;

namespace Trader
{
    public class Item : NameableObject
    {
		#region Static Data

        /// <summary>
        /// The default weight of the item
        /// </summary>
        public const int DefaultWeight = 10;

		#endregion



		#region Constructors

        public Item()
        {
        }


        public Item(string name, int value = 0, int id = 0, int weight = DefaultWeight)
            : base(name)
        {
            Value = value;
            Weight = weight;
			ID = id;
        }


        public Item(Item item)
        {
            Value = item.Value;
            Weight = item.Weight;
            ID = item.ID;
        }

		#endregion



		#region Public Properties

		/// <summary>
		/// The Item's ID number.
		/// </summary>
		public int ID
		{
			get;
			set;
		}


        /// <summary>
        /// The universal-value of the Item.
        /// </summary>
        public int Value
        { 
            get; 
            set; 
        }


        /// <summary>
        /// The weight of the Item.
        /// </summary>
        public double Weight
        {
            get;
            set;
        }

		#endregion



		#region Overridden Methods

		public override void ReadFromStream (StreamReader streamReader)
		{
			base.ReadFromStream (streamReader);

			ID = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
			Value = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
			Weight = Convert.ToDouble(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
		}


		public override void WriteToStream (StreamWriter streamWriter)
		{
			base.WriteToStream (streamWriter);

			streamWriter.WriteLine("ID=" + ID.ToString());
			streamWriter.WriteLine("Value=" + Value.ToString());
			streamWriter.WriteLine("Weight=" + Weight.ToString());
			streamWriter.Flush();
		}


		#endregion
    }
}
