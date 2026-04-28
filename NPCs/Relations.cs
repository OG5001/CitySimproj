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
		static int maxFriends = 3;

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

		public static List<Relations> RsList(List<Person> people)
		{
			List<Relations> result = new List<Relations>();

			for (int i = 0; i < people.Count; i++)
			{
				for (int j = i + 1; j < people.Count; j++)
				{
					var a = people[i];
					var b = people[j];

					string aSurname = a.Name.Split(' ')[1];
					string bSurname = b.Name.Split(' ')[1];

					if (aSurname == bSurname && Math.Abs(a.Age - b.Age) <= 5)
					{
						result.Add(new Relations(
							a.Name,
							b.Name,
							"Házastárs"
						));
					}
					else if (Math.Abs(a.Age - b.Age) <= 3)
					{
						if (a.Friends.Count < maxFriends &&
							b.Friends.Count < maxFriends &&
							!a.Friends.Contains(b))
						{
							a.Friends.Add(b);
							b.Friends.Add(a);

							result.Add(new Relations(a.Name, b.Name, "Barát"));
						}
					}
				}
			}

			return result;
		}
	}
}