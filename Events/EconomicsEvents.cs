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
    // --- ECONOMICS EVENTS ---

    class PPM : EconomicsEventsBlueprint // Power Plant Malfunctioning
    {
        public PPM() : base("PowerPlant Malfunctioning") { }
        public override void StartEffect()
        {
            int electricityLoss = 0;
            // Get this turns electry generation.
            var allElectricityProvider = BuildingManager.GetAllBuildings().Where(b => b.ElectricityConsumption < 0).ToList();
            foreach (var b in allElectricityProvider)
            {
               electricityLoss += b.ElectricityConsumption;
            }

            // Adding extra electricity at the end of the round to simulate the effect.
            Production.GetAllGoods()["electricity"] += electricityLoss;

        }
    }

    // Explanation


}