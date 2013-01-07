using System;

namespace Trader
{
	public class GamePreferences : ICodeable
	{
		public int BaseBagUpgradePrice = 10;


		public int BagUpgradePricePercentageIncrease = 75;


		public int MaximumAmountOfBagSpace = 10;


        /// <summary>
        /// The default money a player will have.
        /// </summary>
        public Money DefaultMoney = new Money();



        public void ReadFromStream(System.IO.StreamReader streamReader)
        {
            BaseBagUpgradePrice = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
            BagUpgradePricePercentageIncrease = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
            MaximumAmountOfBagSpace = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));

            bool shouldContinueToRead = true;
            while (shouldContinueToRead)
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
                        case "default money:":
                        case "default_money:":
                        case "defaultmoney:":
                            DefaultMoney.ReadFromStream(streamReader);
                            shouldContinueToRead = false;
                            break;
                    }
                }
            }

        }

        public void WriteToStream(System.IO.StreamWriter streamWriter)
        {
            StreamUtilities.PrintValue<int>(BaseBagUpgradePrice, "Base Bag Upgrade Price", streamWriter);
            StreamUtilities.PrintValue<int>(BagUpgradePricePercentageIncrease, "Bag Upgrade Price Percentage Increase", streamWriter);
            StreamUtilities.PrintValue<int>(MaximumAmountOfBagSpace, "Maximum Amount Of Bag Space", streamWriter);
            StreamUtilities.Write<Money>(DefaultMoney, "Default Money", streamWriter);
        }
    }
}

