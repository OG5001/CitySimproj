using EsemenykezelesOOP;
using static EsemenykezelesOOP.Npclib;

namespace EsemenykezelesOOP
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

		public Person(int id, int age, bool sex, int health)
		{
			this.id = id;
			this.age = age;
			this.sex = sex;
			this.health = health;

			Npclib lib = new Npclib();

			string surname = lib.surnames[random.Next(lib.surnames.Length)];

			string firstname = sex
				? lib.male_fornames[random.Next(lib.male_fornames.Length)]
				: lib.female_fornames[random.Next(lib.female_fornames.Length)];

			this.name = firstname + " " + surname;

			this.race = (Race)random.Next(Enum.GetValues(typeof(Race)).Length);
			this.traits = (Traits)random.Next(Enum.GetValues(typeof(Traits)).Length);
			Health = health;
		}

		public override string ToString()
		{
			return $"Name: {this.name}, Age: {this.age}, ID: {this.id} {(this.sex ? "male" : "female")}, Race: {this.race}, Health: {this.health}, Traits: {this.traits}";
		}
	}
}