using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class NPCEvents
	{
		private Person p;

		// Constructor
		public NPCEvents(Person p)
		{
			this.p = p;
		}

		public void ApplyEffect(List<Person> plista)
		{

			Console.WriteLine("Applied effect.");

			// Death to all of the people in plista
			foreach (var p in plista)
			{
				Deaths(p);
			}
		}

		public void RemoveEffect()
        {
            Console.WriteLine("Removed effect.");
        }

		// Death Event
		public void Deaths(Person p)
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
