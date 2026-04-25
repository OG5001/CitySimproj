using Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{

    // The Blueprint class for Natural Disasters.
    abstract class NaturalDisasterBlueprint
    {
        private string name;
        private int minDamage;
        private int maxDamage;

        public NaturalDisasterBlueprint(string name, int minDamage, int maxDamage)
        {
            this.name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public virtual void StartEffect()
        {
            var allBuildings = BuildingManager.GetAllBuildingLocations();
            Random random = new Random();
            var shuffledBuildings = allBuildings.OrderBy(_ => random.Next()).ToList(); 


            if (shuffledBuildings.Count > 1) 
            {
                int numberOfAffectedBuildings = random.Next(1, shuffledBuildings.Count); 
                for (int i = 0; i < numberOfAffectedBuildings; i++)
                {
                    shuffledBuildings[i].Building.CurrentHealth -= random.Next(minDamage, maxDamage);
                    Console.WriteLine($"{shuffledBuildings[i].Name} current health: {shuffledBuildings[i].Building.CurrentHealth}");
                }
                Console.WriteLine();
            }
        }

        // --- Explanation ---
        // Inviting all the Buildings as a var. 
        // Creating a var that is the shuffled list of the buildings.
        // If there are more than 1 building, we can apply the Natural Disaster effect. (if its 0 or 1, there will be no events.)
        // Creating a random number of buildings that will be affected by the Natural Disaster.
        // Looping through the number of affected buildings, and applying the random damage.
    }

}