using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Trader
{
    /// <summary>
    /// Resembles Money
    /// </summary>
    public class Money : ICodeable
    {
        /// <summary>
        /// The amount of cents in a dollar
        /// </summary>
        public const int AmountOfCentsInADollar = 100;



        #region Constructors

        public Money(double amount = 0.0)
        {
            Amount = amount;
        }


        public Money(int dollars, int cents)
        {
            Dollars = dollars;
            Cents = cents;
        }

        #endregion



        #region Public Properties

        public double Amount
        {
            get
            {
                return amount;
                /*
                 * double temp = Dollars;
                temp += Cents / 100.0;

                return temp;
                 */
            }
            set
            {
                /*
                Dollars = (int)value;

                // go up two decimals, since we only need two...
                Cents = (int)((((int)(value)) - value) * 100.0);
                 */
                amount = value;
            }
        }


        public int Dollars
        {
            get
            {
                return (int)Amount;
            }
            set
            {
                // TODO
                //dollars = value;
            }
        }


        public int Cents
        {
            get
            {
                return (int)((((int)(Amount)) - Amount) * 100.0); ;
            }
            set
            {
                /*
                if (value >= AmountOfCentsInADollar)
                {
                    ++Dollars;
                    Cents = value - AmountOfCentsInADollar;
                }
                else
                {
                    cents = value;
                }
                 */
            }
        }

        #endregion



        #region Overridden Methods

        public override string ToString()
        {
            return Amount.ToString("C");
        }

        #endregion



        #region ICodeable implementation

        public void ReadFromStream(StreamReader streamReader)
        {
            Amount = Convert.ToDouble(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
        }


        public void WriteToStream(StreamWriter streamWriter)
        {
            // TODO, check if this writes out correctly
            streamWriter.WriteLine("Amount=" + Amount.ToString("0.00"));
        }

        #endregion



        #region Private Instance Variables

        private double amount;

        #endregion
    }
}
