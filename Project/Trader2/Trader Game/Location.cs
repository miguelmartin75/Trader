using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameLib;

namespace Trader
{
    public class Location : NameableObject
    {
        #region Constructors
        // TODO: Constructors

        #endregion


        #region Public Methods

        public void AddShop(Shop shop)
        {
            shops.Add(shop);
            shop.Location = this;
        }


        public void RemoveShop(Shop shop)
        {
            shops.Remove(shop);
            shop.Location = null;
        }

        #endregion


        #region Public Propreties

        public Shop[] Shops
        {
            get
            {
                return shops.ToArray();
            }
        }

        #endregion


        #region Overidden Methods

        public override void ReadFromStream (StreamReader streamReader)
		{
			base.ReadFromStream (streamReader);

            shops.Clear();
            int amountOfShops = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
            for (int i = 0; i < amountOfShops;)
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
                        case "shop:":
                            shops.Add(StreamUtilities.Create<Shop>(new Shop(), streamReader));
                            break;
                    }
                }

                ++i;
            }
		}


        public override void WriteToStream(StreamWriter streamWriter)
		{
			base.WriteToStream (streamWriter);

            streamWriter.WriteLine("Amount Of Shops=" + Shops.Length);
            StreamUtilities.Write<Shop>(Shops, streamWriter);
		}

        #endregion


        #region Private Instance Variables

        private List<Shop> shops = new List<Shop>();

        #endregion
    }
}
