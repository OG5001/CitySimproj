using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
	class Plague : NPCEventsBlueprint
	{
		public Plague() : base("Plague", 20, 100, "A deadly plague has spread through the city, affecting the health of its inhabitants.") { }

		public override void StartEffect()
		{												
			var allNPCs = Person.NPC();
			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = rand.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					allNPCs[i].Health -= rand.Next(minDamage, maxDamage);
				}
			}
		} 

	}

	class CrimeWave : NPCEventsBlueprint
	{
		public CrimeWave() : base("Crime Wave", 10, 30, "A surge in criminal activity has swept through the city, impacting the security of its residents.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = rand.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					allNPCs[i].Ps.NetWorth -= 250;
					allNPCs[i].Health -= rand.Next(minDamage, maxDamage);
				}
			}
		}

	}

	class Festival : NPCEventsBlueprint
	{
		public Festival() : base("Festival", -10, -30, "A joyous festival has taken place in the city, boosting the morale and happiness of its residents.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = rand.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					allNPCs[i].Health -= rand.Next(minDamage, maxDamage);
					allNPCs[i].Ps.Happiness -= rand.Next(minDamage, maxDamage);
				}
			}
		}

	}

	class CharityDonation : NPCEventsBlueprint
	{
		public CharityDonation() : base("Charity Donation", -1000, -5000, "A generous donation has been made to the city's charities, providing financial relief to those in need.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = rand.Next(0, allNPCs.Count/2);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					allNPCs[i].Ps.NetWorth -= rand.Next(minDamage, maxDamage);
					allNPCs[i].Ps.Happiness -= rand.Next(minDamage, maxDamage);
				}
			}
		}

	}

	class LotteryWin : NPCEventsBlueprint
	{
		public LotteryWin() : base("Lottery Win", -1000, -5000, "A lucky resident has won the lottery, bringing unexpected wealth and prosperity to their life.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			int luckyOne = rand.Next(0, allNPCs.Count);
			allNPCs[luckyOne].Ps.NetWorth -= rand.Next(minDamage, maxDamage);
			allNPCs[luckyOne].Ps.Happiness -= rand.Next(minDamage, maxDamage);
		}

	}

	class FreeHoliday : NPCEventsBlueprint
	{
		public FreeHoliday() : base("Free Holiday", -10, -30, "The city has declared a free holiday, allowing residents to relax and enjoy their day off.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = rand.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					allNPCs[i].Health -= rand.Next(minDamage, maxDamage);
					allNPCs[i].Ps.Happiness -= rand.Next(minDamage, maxDamage);
				}
			}
		}

	}

	class MoneyRain : NPCEventsBlueprint
	{
		public MoneyRain() : base("Money Rain", -1000, -5000, "A sudden downpour of money has occurred in the city, providing a financial boost to its residents.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = rand.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					allNPCs[i].Ps.NetWorth -= rand.Next(minDamage, maxDamage);
					allNPCs[i].Ps.Happiness -= rand.Next(minDamage, maxDamage);
				}
			}
		}

	}

	class ClownParade : NPCEventsBlueprint
	{
		public ClownParade() : base("Clown Parade", -10, -30, "A whimsical clown parade has taken place in the city, bringing laughter and joy to its residents.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = rand.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					allNPCs[i].Health -= rand.Next(minDamage, maxDamage);
					allNPCs[i].Ps.Happiness -= rand.Next(minDamage, maxDamage);
				}
			}
		}

	}

	class Promotion : NPCEventsBlueprint
	{
		public Promotion() : base("Promotion", -1000, -5000, "A hardworking resident has received a promotion at work, leading to increased income and job satisfaction.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			int luckyOne = rand.Next(0, allNPCs.Count);
			allNPCs[luckyOne].Ps.NetWorth -= rand.Next(minDamage, maxDamage);
			allNPCs[luckyOne].Ps.Happiness -= rand.Next(minDamage, maxDamage);
		}

	}

	class UnemploymentSpike : NPCEventsBlueprint
	{
		public UnemploymentSpike() : base("Unemployment Spike", 10, 30, "A sudden spike in unemployment has occurred, leading to financial instability and stress for many residents.") { }

		public override void StartEffect()
		{
			var allNPCs = Person.NPC();
			if (allNPCs.Count >= 1)
			{
				int numberOfAffectedNPCs = rand.Next(0, allNPCs.Count);
				for (int i = 0; i < numberOfAffectedNPCs; i++) {
					allNPCs[i].Ps.NetWorth -= rand.Next(minDamage, maxDamage);
					allNPCs[i].Ps.Happiness -= rand.Next(minDamage, maxDamage);
				}
			}
		}

	}
}


