using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class NPCEvents
	{
		private List<Person> people;

		public NPCEvents(List<Person> people)
		{
			this.people = people;
		}

		public void ApplyEffect()
		{
			Random random = new Random();
			int randomPersonIndex = random.Next(0, people.Count);

			Console.WriteLine("Applied effect.");

			// Death to all of the people in plista
			foreach (var p in people)
			{
				p.Health =0;
				Deaths(p);
			}
			Lotto(people[randomPersonIndex]);
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

		public void Lotto(Person p)
		{
			//p.Job.Salary += 10000;
		}

		/*public override string ToString()
		{
			return base.ToString() + $" {this.health} {this.religon} {this.happiness} {this.status} {this.income}";
		}*/

    }
}
