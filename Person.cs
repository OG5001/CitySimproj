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
		private Traits traits;
		private Race race;
		protected int health;

		public string Name { get => name; set => name = value; }
		public int Age { get => age; set => age = value; }
		public bool Sex { get => sex; set => sex = value; }
		public int Id { get => id; set => id = value; }
		public Traits Traits { get => traits; set => traits = value; }
		public Race Race { get => race; set => race = value; }

		public int Health { get => health; set => health = value; }

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
			this.traits = (Traits)random.Next(Enum.GetValues(typeof(Traits)).Length); //Random trait (egyenlőre 1)
		}
		public static void NPC()
		{
			for (int i = 0; i < 10; i++)
			{
				Person p = new Person(i);
				Console.WriteLine(p);
			}
		}
		public override string ToString()
		{
			return $"Name: {this.name}, Age: {this.age}, ID: {this.id} {(this.sex ? "male" : "female")}, Race: {this.race}, Health: {this.health}, Traits: {this.traits}";
		}
	}
}
