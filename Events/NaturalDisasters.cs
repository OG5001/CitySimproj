using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            var allBuildings = BuildingManager.GetAllBuildings();
            Random random = new Random();

            if (allBuildings.Count == 0)
            {
                Console.WriteLine("The Earthquake shook the ground, but no buildings were there to be damaged.");
                return;
            }
            else if (allBuildings.Count == 1)
            {
                // Mercyful Earthquake
                Console.WriteLine("The Earthquake shook the ground, but no buildings were damaged.");
                return;
            }
            else
            {
                int randomBuildingNumber = random.Next(1, allBuildings.Count); // Affected buildings
                int randomDamageToBuilding = random.Next(15, 45); // Damage to all the affected buildings

                // Applying effect to x amount of random buildings
                for (int i = 0; i < randomBuildingNumber; i++)
                {
                    // random indexed building gets damaged by random damage
                    
                    int randomIndex = random.Next(allBuildings.Count);
                    allBuildings[randomIndex].CurrentHealth -= randomDamageToBuilding;

                    Console.WriteLine($"The { allBuildings[randomIndex].Name} has been damaged by {randomDamageToBuilding} due to the earthquake!");

                    // If the building's health drops to 0 or below.
                    if (allBuildings[randomIndex].CurrentHealth <= 0)
                    {
                        BuildingManager.RemoveBuilding(allBuildings[randomIndex]);
                        Console.WriteLine($"The {allBuildings[randomIndex].Name} has been destroyed by the earthquake!");
                        break;
                    }
                }
            } 
        }
    }
    class Tsunami : NaturalDisasterBlueprint
    {
        public Tsunami() : base("Tsunami") { }

        public override void StartEffect()
        {
            // All building + random
            var allBuildings = BuildingManager.GetAllBuildings();
            Random random = new Random();

            if (allBuildings.Count == 0)
            {
                Console.WriteLine("The Tsunami flooded the city, but no buildings were there to be damaged.");
                return;
            }
            else if (allBuildings.Count == 1)
            {
                // Mercyful Earthquake
                Console.WriteLine("The Tsunami flooded the city, but no buildings were damaged.");
                return;
            }
            else
            {
                int randomBuildingNumber = random.Next(1, allBuildings.Count); // Affected buildings
                int randomDamageToBuilding = random.Next(15, 45); // Damage to all the affected buildings

                // Applying effect to x amount of random buildings
                for (int i = 0; i < randomBuildingNumber; i++)
                {
                    // random indexed building gets damaged by random damage

                    int randomIndex = random.Next(allBuildings.Count);
                    allBuildings[randomIndex].CurrentHealth -= randomDamageToBuilding;

                    Console.WriteLine($"The {allBuildings[randomIndex].Name} has been damaged by {randomDamageToBuilding} due to the Tsunami!");

                    // If the building's health drops to 0 or below.
                    if (allBuildings[randomIndex].CurrentHealth <= 0)
                    {
                        BuildingManager.RemoveBuilding(allBuildings[randomIndex]);
                        Console.WriteLine($"The {allBuildings[randomIndex].Name} has been destroyed by the Tsunami!");
                        break;
                    }
                }
            }
        }
    }

}