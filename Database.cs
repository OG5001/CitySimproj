using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemenykezelesOOP
{
	internal class Database
	{
		private List<Person> people;
		private List<BuildingEvents> buildingEvents;
		private List<EconomicEvents> economicEvents;
		
		private Random random;

		public Database()
		{
			people = new List<Person>();
			buildingEvents = new List<BuildingEvents>();
			economicEvents = new List<EconomicEvents>();
		}

		internal List<Person> People { get => people; set => people = value; }
		internal List<BuildingEvents> BuildingEvents { get => buildingEvents; set => buildingEvents = value; }
		internal List<EconomicEvents> EconomicEvents { get => economicEvents; set => economicEvents = value; }

		// Add 
		public void NPCAdd(Person npc)
		{
			people.Add(npc);
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
		public void NPCRemove(Person npc)
		{
			people.Remove(npc);
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
			foreach (var npcEv in people)
			{
				npcEv.ApplyEffect();
			}
		}

		// Kiiratas
		public void Kiiratas()
		{
			foreach (var npc in people)
			{
				Console.WriteLine(npc);
			}
		}
	}
}
