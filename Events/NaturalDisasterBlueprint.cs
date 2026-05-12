using Buildings;
using CitySimproj.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj.Events
{
    abstract class NaturalDisasterBlueprint : EventBlueprint
    {
        private static readonly Random random = new Random();

        public NaturalDisasterBlueprint(string name, int minDamage, int maxDamage, string description) : base(name, description)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public override void StartEffect()
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