using Buildings;
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
		private List<Person> npcS;
        private Dictionary<string, Building> buildingsBuilt;

        private Random random;

		public Database()
		{
			npcEvents = new List<NPCEvents>();
			buildingEvents = new List<BuildingEvents>();
			economicEvents = new List<EconomicEvents>();
			npcS = new List<Person>();
			buildingsBuilt = new Dictionary<string, Building>();
		}

		internal List<NPCEvents> NpcEvents { get => npcEvents; set => npcEvents = value; }
		internal List<BuildingEvents> BuildingEvents { get => buildingEvents; set => buildingEvents = value; }
		internal List<EconomicEvents> EconomicEvents { get => economicEvents; set => economicEvents = value; }
		internal List<Person> NpcS { get => npcS; set => npcS = value; }
        public Dictionary<string, Building> BuildingsBuilt { get => buildingsBuilt; set => buildingsBuilt = value; }


        // Add 
        public void NPCAdd(List<Person> p)
		{
			foreach (var i in p)
			{
				npcS.Add(i);
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
