using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class PersonalStats
	{
		private int productivity; //0-100
		private int happiness;
		private int social;
		private int health_th; //treshold
		private int basic_needs_th;
		private int money_gain;
		private int health;
		private int karma;
		public Random random;

		public PersonalStats()
		{
			this.productivity = random.Next(40, 61);
			this.happiness = random.Next(40, 61);
			this.social = random.Next(40, 61);
			this.health_th = random.Next(5, 16);
			this.basic_needs_th = random.Next(5, 16);
			this.money_gain = random.Next(40, 61);
			this.health = random.Next(40, 61);
			this.karma = random.Next(40, 61);
		}

		public int Productivity { get => productivity; set => productivity = value; }
		public int Happiness { get => happiness; set => happiness = value; }
		public int Social { get => social; set => social = value; }
		public int Health_th { get => health_th; set => health_th = value; }
		public int Basic_needs_th { get => basic_needs_th; set => basic_needs_th = value; }
		public int Money_gain { get => money_gain; set => money_gain = value; }
		public int Health { get => health; set => health = value; }
		public int Karma { get => karma; set => karma = value; }
	}
}