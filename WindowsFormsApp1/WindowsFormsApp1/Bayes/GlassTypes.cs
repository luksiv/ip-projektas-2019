using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApp1.Bayes
{
	class GlassTypes
	{
		public int type1 { get; set; }
		public int type2 { get; set; }
		public int type3 { get; set; }
		public int type4 { get; set; }
		public int type5 { get; set; }
		public int type6 { get; set; }
		public int type7 { get; set; }

		public GlassTypes ()
		{
			type1 = 0;
			type2 = 0;
			type3 = 0;
			type4 = 0;
			type5 = 0;
			type6 = 0;
			type7 = 0;
		}
	}

	class TypesProbabilities
	{

		public double type1Probobility { get; set; }
		public double type2Probobility { get; set; }
		public double type3Probobility { get; set; }
		public double type4Probobility { get; set; }
		public double type5Probobility { get; set; }
		public double type6Probobility { get; set; }
		public double type7Probobility { get; set; }

		public TypesProbabilities()
		{
			type1Probobility = 0;
			type2Probobility = 0;
			type3Probobility = 0;
			type4Probobility = 0;
			type5Probobility = 0;
			type6Probobility = 0;
			type7Probobility = 0;
		}

		public void changeZeros()
		{
			if (type1Probobility == 0) type1Probobility = 0.1;
			if (type2Probobility == 0) type2Probobility = 0.1;
			if (type3Probobility == 0) type3Probobility = 0.1;
			if (type4Probobility == 0) type4Probobility = 0.1;
			if (type5Probobility == 0) type5Probobility = 0.1;
			if (type6Probobility == 0) type6Probobility = 0.1;
			if (type7Probobility == 0) type7Probobility = 0.1;
		}
	}


}
