using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal abstract class Event
	{
		protected string name;
		protected int duration;

		// Constructor
		public Event(string name, int duration)
		{
			this.name = name;
			this.duration = duration;;
		}





		// Effect of the Event
		public abstract void ApplyEffect();
		public abstract void RemoveEffect();


		// To string method
		public override string ToString()
		{
			return $"{this.name} {this.duration}";
		}
	}
}
