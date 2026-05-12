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
        private int minDamage;
        private int maxDamage;

        public NaturalDisasterBlueprint(string name, string description, int minDamage, int maxDamage) : base(name, description)
        {
            this.MinDamage = minDamage;
            this.MaxDamage = maxDamage;
        }

        public int MinDamage { get => minDamage; set => minDamage = value; }
        public int MaxDamage { get => maxDamage; set => maxDamage = value; }

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