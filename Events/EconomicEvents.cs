using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class EconomicEvents : Event
	{
		private int taxes;
		private int foreignTrade;
		private int bonds;
		private int inflation;


		// Constructor
		public EconomicEvents(string name, int duration, int taxes, int foreignTrade, int bonds, int inflation) : base(name, duration)
		{
			this.taxes = taxes;
			this.foreignTrade = foreignTrade;
			this.bonds = bonds;
			this.inflation = inflation;
		}


		// Apply + Removing the effect
		public override void ApplyEffect()
		{
			Console.WriteLine("Applied effects.");
		}

		public override void RemoveEffect()
		{
			Console.WriteLine("Removed effects");
		}
	}
}
