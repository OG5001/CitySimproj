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

		public NPCEventsBlueprint(string name, int minDamage, int maxDamage)
		{
			this.name = name;
			this.minDamage = minDamage;
			this.maxDamage = maxDamage;
		}

		public virtual void StartEffect()
		{
			var allNPCs = Person.NPC();
			Random random = new Random();
			var shuffledNPCs = allNPCs.OrderBy(_ => random.Next()).ToList();

			if (shuffledNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = random.Next(0, shuffledNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					shuffledNPCs[i].Health -= random.Next(minDamage, maxDamage);
					Console.WriteLine($"{shuffledNPCs[i].Name} current health: {shuffledNPCs[i].Health}");
				}
				Console.WriteLine();

			}
		}
	}
}
