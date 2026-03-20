using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class Database
	{
		private List<NPCEvents> npcEvents;
		private List<BuildingEvents> buildingEvents;
		private List<EconomicEvents> economicEvents;
		
		private Random random;

		public Database()
		{
			npcEvents = new List<NPCEvents>();
			buildingEvents = new List<BuildingEvents>();
			economicEvents = new List<EconomicEvents>();
		}

		internal List<NPCEvents> NpcEvents { get => npcEvents; set => npcEvents = value; }
		internal List<BuildingEvents> BuildingEvents { get => buildingEvents; set => buildingEvents = value; }
		internal List<EconomicEvents> EconomicEvents { get => economicEvents; set => economicEvents = value; }

		// Add 
		public void NPCAdd(NPCEvents npc)
		{
			npcEvents.Add(npc);
		}
		public void BuildingAdd(BuildingEvents building)
		{
			buildingEvents.Add(building);
		}
		public void EconomicAdd(EconomicEvents economic)
		{
			economicEvents.Add(economic);
		}


		// Delete
		public void NPCRemove(NPCEvents npc)
		{
			npcEvents.Remove(npc);
		}
		public void BuildingRemove(BuildingEvents building)
		{
			buildingEvents.Remove(building);
		}
		public void EconomicRemove(EconomicEvents economic)
		{
			economicEvents.Remove(economic);
		}


		public void UpdateAllNPC()
		{
			foreach (var npcEv in npcEvents)
			{
				npcEv.ApplyEffect();
			}
		}

		// Kiiratas
		public void Kiiratas()
		{
			foreach (var npc in NpcEvents)
			{
				Console.WriteLine(npc);
			}
		}
	}
}
