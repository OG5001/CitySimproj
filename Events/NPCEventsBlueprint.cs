using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
	abstract class NPCEventsBlueprint
	{
		private string name;
		private int minDamage;
		private int maxDamage;
		private bool stealing;

		public NPCEventsBlueprint(string name, int minDamage, int maxDamage, bool stealing)
		{
			this.name = name;
			this.minDamage = minDamage;
			this.maxDamage = maxDamage;
			this.stealing = stealing;
		}

		public virtual void StartEffect()
		{
			var allNPCs = Person.NPC();
			Random random = new Random();
			allNPCs = allNPCs.OrderBy(_ => random.Next()).ToList();

			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = random.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					if (this.stealing == true)
					{
						allNPCs[i].Job.Salary -= 1000;
					}
					allNPCs[i].Health -= random.Next(minDamage, maxDamage);
					Console.WriteLine($"{allNPCs[i].Name} current health: {allNPCs[i].Health}");
				}
				Console.WriteLine();

			}
		}
	}
}
