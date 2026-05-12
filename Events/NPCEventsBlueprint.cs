namespace CitySimproj.Events
{
	abstract class NPCEventsBlueprint : IEvent
    {
		protected static readonly Random random = new Random();

        public string Name { get; set; }
		public string Description { get; set; }
		public int MinDamage { get; set; }
		public int MaxDamage { get; set; }

		public NPCEventsBlueprint(string name, string description, int minDamage, int maxDamage)
		{
			Name = name;
			Description = description;
			MinDamage = minDamage;
			MaxDamage = maxDamage;
        }

        public virtual void StartEffect() 
		{
			var AllNPCs = Person.NPC();
			if (AllNPCs.Count < 1) return;

			int affected = random.Next(0, AllNPCs.Count);
			for (int i = 0; i < affected; i++)
			{
				ApplyToNPC(AllNPCs[i]);
			}
        }

		protected abstract void ApplyToNPC(Person npc);
    }
}
