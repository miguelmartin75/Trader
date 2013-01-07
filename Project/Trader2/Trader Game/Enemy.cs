using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GameLib;

namespace Trader
{
    public class Enemy : NameableObject
    {
		public int DamageAmount
		{
			get;
			set;
		}


		public override void ReadFromStream (StreamReader streamReader)
		{
			base.ReadFromStream(streamReader);

			DamageAmount = Convert.ToInt32(StringUtilities.GrabVariableFromString(streamReader.ReadLine(), '='));
		}


		public override void WriteToStream (StreamWriter streamWriter)
		{
			base.WriteToStream(streamWriter);

			streamWriter.WriteLine("Damage Amount=" + DamageAmount.ToString());
		}
    }
}
