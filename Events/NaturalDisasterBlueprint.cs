using Buildings;

namespace CitySimproj.Events
{
    abstract class NaturalDisasterBlueprint : IEvent
    {
        private static readonly Random random = new Random();

        public string Name { get; set; }
        public string Description { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public NaturalDisasterBlueprint(string name, string description, int minDamage, int maxDamage)
        {
            Name = name;
            Description = description;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }

        public virtual void StartEffect()
        {
            var allBuildings = BuildingManager.GetAllBuildingLocations();
            var shuffledBuildings = allBuildings.OrderBy(_ => random.Next()).ToList(); 


            if (shuffledBuildings.Count > 1) 
            {
                int affected = random.Next(1, shuffledBuildings.Count); 
                for (int i = 0; i < affected; i++)
                {
                    shuffledBuildings[i].Building.CurrentHealth -= random.Next(MinDamage, MaxDamage);
                }
            }
        }
    }

}