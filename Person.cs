using CitySimproj;
using static CitySimproj.Npclib;

namespace CitySimproj
{
	internal class Person
	{
		private static Random random = new Random();

		protected string name;
		protected int id;
		protected int age;
		protected bool sex;
		private List<Traits> traits;
		private Race race;
		protected int health;
		private PersonalStats ps;

		public string Name { get => name; set => name = value; }
		public int Age { get => age; set => age = value; }
		public bool Sex { get => sex; set => sex = value; }
		public int Id { get => id; set => id = value; }
		public Race Race { get => race; set => race = value; }

		public int Health { get => health; set => health = value; }
		internal List<Traits> Traits { get => new List<Traits>(); set => traits = value; }
		internal PersonalStats Ps { get => ps; set => ps = value; }

		public Person(int id)
		{
			this.id = id;
			this.health = 100; //Health mindig 100-on indul.

			Npclib lib = new Npclib();

			this.sex = random.Next(2) == 0; //Random sex
			this.age = random.Next(18, 80); //Random age

			string surname = lib.surnames[random.Next(lib.surnames.Length)]; //Random surnames

			string firstname = sex
				? lib.male_fornames[random.Next(lib.male_fornames.Length)] //Sex alapján férfi vagy női keresztnév
				: lib.female_fornames[random.Next(lib.female_fornames.Length)];

			this.name = firstname + " " + surname;

			this.race = (Race)random.Next(Enum.GetValues(typeof(Race)).Length); //Random race
			this.traits = new List<Traits>();
			this.ps = new PersonalStats();
			AddTraits();
			StatsCalculator();
		}

		public static List<Person> NPC()
		{
			List<Person> plist = new List<Person>();
			for (int i = 0; i < 10; i++)
			{
				Person p = new Person(i);
				Console.WriteLine(p);
				plist.Add(p);
			}
			return plist;
		}

		public void AddTraits()
		{
			for (int i = 0; i < random.Next(1, 6); i++)
			{
				Npclib.Traits t = (Traits)random.Next(Enum.GetValues(typeof(Traits)).Length);
				if (!(this.traits.Contains(t)))
				{
					this.traits.Add(t);
				}
			}
		}

		public void StatsCalculator()
		{
			for (int i = 0;i < this.traits.Count();i++)
			{
				switch (this.traits[i])
				{
					// Productivity
					case Npclib.Traits.Hardworking:
						this.ps.Productivity += 10;
						break;
					case Npclib.Traits.Diligent:
						this.ps.Productivity += 5;
						break;
					case Npclib.Traits.Sluggish:
						//this.ps.Productivity -= 5;
						break;
					case Npclib.Traits.Lazy:
						this.ps.Productivity -= 10;
						break;

					// Happiness + Social
					case Npclib.Traits.Optimistic:
						this.ps.Happiness += 10;
						this.ps.Social += 5;
						break;
					case Npclib.Traits.Positive:
						this.ps.Happiness += 5;
						this.ps.Social += 5;
						break;
					case Npclib.Traits.Pessimistic:
						this.ps.Happiness -= 5;
						this.ps.Social -= 5;
						break;
					case Npclib.Traits.Depressive:
						this.ps.Happiness -= 10;
						this.ps.Karma += 5;
						break;

					// Social
					case Npclib.Traits.Extroverted:
						this.ps.Social += 10;
						break;
					case Npclib.Traits.Friendly:
						this.ps.Social += 5;
						break;
					case Npclib.Traits.Introverted:
						this.ps.Social -= 5;
						break;
					case Npclib.Traits.Reserved:
						this.ps.Social -= 10;
						break;

					// Health threshold
					case Npclib.Traits.Immune:
						this.ps.Health_th += 10;
						break;
					case Npclib.Traits.Sickly:
						this.ps.Health_th -= 10;
						break;

					// Karma
					case Npclib.Traits.Clumsy:
					case Npclib.Traits.AccidentProne:
						this.ps.Karma += 10;
						break;

					// Basic needs threshold
					case Npclib.Traits.Ascetic:
						this.ps.Basic_needs_th += 10;
						break;
					case Npclib.Traits.Lavish:
						this.ps.Basic_needs_th -= 10;
						break;

					// Money gain
					case Npclib.Traits.Greedy:
						this.ps.Money_gain -= 5;
						break;
					case Npclib.Traits.Generous:
						this.ps.Money_gain += 5;
						break;

					// Karma (behavior)
					case Npclib.Traits.Hateful:
						this.ps.Karma += 10;
						break;
					case Npclib.Traits.Peaceful:
						this.ps.Karma -= 10;
						break;
				}
				
			}
		}

		public override string ToString()
		{
			string t = "";
			foreach (var item in this.traits)
			{
				t += Enum.GetName(item) + ", ";
			}
			return $"Name: {this.name}, Age: {this.age}, ID: {this.id} {(this.sex ? "male" : "female")}, Race: {this.race}, Health: {this.health}, Traits: {t}";
		}
	}
}
