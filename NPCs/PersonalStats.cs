using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class PersonalStats
	{
        private Random random = new Random();
		private int productivity; //0-100
		private int happiness;
		private int social;
		private int health_th; //treshold
		private int basic_needs_th;
		private int money_gain;
		private int karma;
		private int[] special; //Strength, preception, endurance, charisma, intelligence, agility, luck

        public PersonalStats()
        {
            this.productivity = random.Next(40, 61);
            this.happiness = random.Next(40, 61);
            this.social = random.Next(40, 61);
            this.health_th = random.Next(5, 16);
            this.basic_needs_th = random.Next(5, 16);
            this.money_gain = random.Next(40, 61);
            this.karma = random.Next(40, 61);
			this.special = new int[5];
			generateSpecial();
        }

        public int Productivity { get => productivity; set => productivity = value; }
		public int Happiness { get => happiness; set => happiness = value; }
		public int Social { get => social; set => social = value; }
		public int Health_th { get => health_th; set => health_th = value; }
		public int Basic_needs_th { get => basic_needs_th; set => basic_needs_th = value; }
		public int Money_gain { get => money_gain; set => money_gain = value; }
		public int Karma { get => karma; set => karma = value; }
        public int[] Special { get => special; set => special = value; }

		private void generateSpecial()
		{
			for (int i = 0; i < special.Length; i++)
			{
				int newStat = random.Next(1, 31);
				if (newStat <= 10)
				{
					special[i] = newStat;
				}
				else
				{
					special[i] = 5;
				}
			}
        }
    }
}