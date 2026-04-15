using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class BuildingEvents : Event
	{
		private int durability;
		private int occupancy;

		// Constructor
		public BuildingEvents(string name, int duration, int durabilty, int occupancy) : base(name, duration)
		{
			this.durability = durabilty;
			this.occupancy = occupancy;
		}

		// The effect of the Event
		public override void ApplyEffect()
		{
			Console.WriteLine("Applied effect.");
		}

		public override void RemoveEffect()
		{
			Console.WriteLine("Removed effect.");
		}

		// To string method
		public override string ToString()
		{
			return base.ToString() + $"{this.durability} {this.occupancy}";
		}
	}
}
