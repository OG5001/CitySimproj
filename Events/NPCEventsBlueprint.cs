using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
	abstract class NPCEventsBlueprint : EventBlueprint
    {
        protected static readonly Random random = new Random();
        private int minDamage;
        private int maxDamage;

        public NPCEventsBlueprint(string name, string description, int minDamage, int maxDamage) : base(name, description)
		{
			this.minDamage = minDamage;
			this.maxDamage = maxDamage;
		}
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public override void StartEffect()
		{
			var AllNPCs = Person.NPC();
			if (AllNPCs.Count < 1) return;

			int affected = random.Next(0, AllNPCs.Count);
			for (int i = 0; i < affected; i++)
			{
				ApplyToNPC(AllNPCs[i]);
			}
        }

		protected abstract void ApplyToNPC(Person npc);
    }
}
