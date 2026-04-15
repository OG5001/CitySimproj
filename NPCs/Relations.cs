using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class Relations
	{
		static List<Person> npc_rs = Person.NPC();
		private List<Relations> Relationships = new List<Relations>();
		private string personA;
		private string personB;
		private string relation;

		public Relations(string personA, string personB, string relation)
		{
			this.personA = personA;
			this.personB = personB;
			this.relation = relation;
		}

		internal static List<Person> Npc_rs { get => npc_rs; set => npc_rs = value; }
		public string PersonA { get => personA; set => personA = value; }
		public string PersonB { get => personB; set => personB = value; }
		public string Relation { get => relation; set => relation = value; }

		public static void RsList()
		{

		}
	}
}
