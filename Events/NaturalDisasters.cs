using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Buildings;


namespace CitySimproj
{

// --- NATURAL DISASTERS ---

    class Earthquake : NaturalDisasterBlueprint
    {
        public Earthquake() : base("Earthquake")  { }

        public override void StartEffect()
        {
            // All building + random
            List<Building> allBuildings = BuildingManager.GetAllBuildings();
            Random random = new Random();

            if (allBuildings.Count == 0)
            {
                Console.WriteLine("The Earthquake shook the ground, but no buildings were there to be damaged.");
                return;
            }
            
            int maxTargets = (int)Math.Ceiling((double)allBuildings.Count / 4);
            int safeMax = Math.Max(2, maxTargets + 1);

            int randomBuildingNumber = random.Next(1, safeMax);
            int randomDamageToBuilding = random.Next(15, 45);

            // Applying effect to x amount of random buildings
            for (int i = 0; i < randomBuildingNumber; i++)
            {
                int randomIndex = random.Next(allBuildings.Count);
                Building randomBuilding = allBuildings[randomIndex];
                randomBuilding.CurrentHealth -= randomDamageToBuilding;
                Console.WriteLine($"The {randomBuilding.Name} has been damaged by {randomDamageToBuilding} due to the earthquake!");

                // If the building's health drops to 0 or below.
                if (randomBuilding.CurrentHealth <= 0)
                {
                    BuildingManager.RemoveBuilding(randomBuilding);
                    Console.WriteLine($"The {randomBuilding.Name} has been destroyed by the earthquake!");
                }
            }
        }
    }
    

}