using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
	class Plague : NPCEventsBlueprint
	{
		public Plague() : base("Plague", "A deadly plague has spread through the city, affecting the health of its inhabitants.",0,101) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Health = Math.Max(0, npc.Health - random.Next(MinDamage, MaxDamage));
        }
		public override void StartEffect() { }

	}

	class CrimeWave : NPCEventsBlueprint
	{
		public CrimeWave() : base("Crime Wave", "A surge in criminal activity has swept through the city, impacting the security of its residents.",10,30) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Health = Math.Max(0, npc.Health - random.Next(MinDamage, MaxDamage));
			npc.Ps.NetWorth = Math.Max(0, npc.Ps.NetWorth - 250);
        }
        public override void StartEffect() { }

    }

	class Festival : NPCEventsBlueprint
	{
		public Festival() : base("Festival", "A joyous festival has taken place in the city, boosting the morale and happiness of its residents.", -10, -30) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Health = random.Next(MinDamage, MaxDamage);
            npc.Ps.Happiness -= random.Next(MinDamage, MaxDamage);
        }
        public override void StartEffect() { }

    }

	class CharityDonation : NPCEventsBlueprint
	{
		public CharityDonation() : base("Charity Donation", "A generous donation has been made to the city's charities, providing financial relief to those in need.", -1000, -5000) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Ps.NetWorth -= random.Next(MinDamage, MaxDamage);
            npc.Ps.Happiness -= random.Next(MinDamage, MaxDamage);
        }
        public override void StartEffect() { }

    }

	class LotteryWin : NPCEventsBlueprint
	{
		public LotteryWin() : base("Lottery Win", "A lucky resident has won the lottery, bringing unexpected wealth and prosperity to their life.", -1000, -5000) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Ps.NetWorth -= random.Next(MinDamage, MaxDamage);
            npc.Ps.Happiness -= random.Next(MinDamage, MaxDamage);
        }
        public override void StartEffect() { }

    }

	class FreeHoliday : NPCEventsBlueprint
	{
		public FreeHoliday() : base("Free Holiday", "The city has declared a free holiday, allowing residents to relax and enjoy their day off.", -10, -30) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Health -= random.Next(MinDamage, MaxDamage);
            npc.Ps.Happiness -= random.Next(MinDamage, MaxDamage);
        }
        public override void StartEffect() { }

    }

	class MoneyRain : NPCEventsBlueprint
	{
		public MoneyRain() : base("Money Rain", "A sudden downpour of money has occurred in the city, providing a financial boost to its residents.", -1000, -5000) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Ps.NetWorth -= random.Next(MinDamage, MaxDamage);
            npc.Ps.Happiness -= random.Next(MinDamage, MaxDamage);
        }
        public override void StartEffect() { }

    }

	class ClownParade : NPCEventsBlueprint
	{
		public ClownParade() : base("Clown Parade", "A whimsical clown parade has taken place in the city, bringing laughter and joy to its residents.", -10, -30) { }

        protected override void ApplyToNPC(Person npc)
        {
			npc.Health -= random.Next(MinDamage, MaxDamage);
            npc.Ps.Happiness -= random.Next(MinDamage, MaxDamage);
        }
        public override void StartEffect() { }

    }

	class Promotion : NPCEventsBlueprint
	{
		public Promotion() : base("Promotion", "A hardworking resident has received a promotion at work, leading to increased income and job satisfaction.", -1000, -5000) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Ps.NetWorth -= random.Next(MinDamage, MaxDamage);
            npc.Ps.Happiness -= random.Next(MinDamage, MaxDamage);
        }
        public override void StartEffect() { }

    }

	class UnemploymentSpike : NPCEventsBlueprint
	{
		public UnemploymentSpike() : base("Unemployment Spike", "A sudden spike in unemployment has occurred, leading to financial instability and stress for many residents.", 10, 30) { }

        protected override void ApplyToNPC(Person npc)
        {
            npc.Ps.NetWorth = Math.Max(0, npc.Ps.NetWorth - random.Next(MinDamage, MaxDamage));
            npc.Ps.Happiness = Math.Max(0, npc.Ps.Happiness - random.Next(MinDamage, MaxDamage));
        }
        public override void StartEffect() { }

    }
}


