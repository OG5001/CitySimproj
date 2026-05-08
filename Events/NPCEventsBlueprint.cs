using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
	abstract class NPCEventsBlueprint
	{
		protected static readonly Random rand = new Random();
		private string name;
		protected int minDamage;
		protected int maxDamage;
		//private bool stealing;
		private string description;

		public string Name => name;	
        public string Description => description;

        public NPCEventsBlueprint(string name, int minDamage, int maxDamage, /*bool stealing,*/ string description)
		{
			this.name = name;
			this.minDamage = minDamage;
			this.maxDamage = maxDamage;
			//this.stealing = stealing;
			this.description = description;
		}

		public virtual void StartEffect()
		{
			/*
			var allNPCs = Person.NPC();
			Random random = new Random();
			allNPCs = allNPCs.OrderBy(_ => random.Next()).ToList();

			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = random.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					if (this.stealing == true)
					{
						allNPCs[i].Ps.NetWorth -= 1000;
					}
					allNPCs[i].Health -= random.Next(minDamage, maxDamage);
				}
			}
			*/
		}
	}
}
