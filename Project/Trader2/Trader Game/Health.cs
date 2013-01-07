using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Trader
{
    public class Health : ICodeable
    {
		#region Static Data 

		/// <summary>
		/// The default minimum health.
		/// </summary>
        public const int DefaultMin = 0;


		/// <summary>
		/// The default maximum health.
		/// </summary>
        public const int DefaultMax = 100;

		#endregion



		#region Constructors

        public Health(int current = -1, int min = DefaultMin, int max = DefaultMax)
        {
            Min = min;
            Max = max;

            if (current > -1)
            {
                Current = current;
            }
            else
            {
                Current = Max;
            }
        }

		#endregion



		#region Public Properties and Variables

		/// <summary>
		/// The current amount of health.
		/// </summary>
        private int current;
        public int Current
        {
            get
            {
                return current;
            }
            set
            {
                if (value < Min)
                {
                    current = Min;
                }
                else if (value > Max)
                {
                    current = Max;
                }
                else
                {
                    current = value;
                }
            }
        }


		/// <summary>
		/// Gets or sets the maximum amount of health.
		/// </summary>
		/// <value>
		/// The max.
		/// </value>
        public int Max
        {
            get;
            set;
        }


		/// <summary>
		/// Gets or sets the minimum amount of health.
		/// </summary>
		/// <value>
		/// The minimum.
		/// </value>
        public int Min
        {
            get;
            set;
        }

		#endregion



		#region ICodeable implementation

		public void ReadFromStream (StreamReader streamReader)
		{
			Min 	= System.Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
			Max 	= System.Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
			Current = System.Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
		}


		public void WriteToStream (StreamWriter streamWriter)
		{
			streamWriter.WriteLine("Min=" + Min.ToString());
			streamWriter.WriteLine("Max=" + Max.ToString());
			streamWriter.WriteLine("Current=" + Current.ToString());
		}

		#endregion
    }
}
