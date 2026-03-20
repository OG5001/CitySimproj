using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class NPCEvents : Event
	{
		private Person p;


		// Constructor
		public NPCEvents(Person p, string EventName, int eventDuration) : base(EventName, eventDuration)
        {
			this.p = p;

        }

        public override void ApplyEffect()
		{
			Deaths();
		}


		public override void RemoveEffect()
        {
            Console.WriteLine("Removed effect.");
        }


		public void Deaths()
		{
			if (p.Health == 0)
			{
				Console.WriteLine($"{p.Name} Died!");
			}

		}


		/*public override string ToString()
		{
			return base.ToString() + $" {this.health} {this.religon} {this.happiness} {this.status} {this.income}";
		}*/

    }
}
