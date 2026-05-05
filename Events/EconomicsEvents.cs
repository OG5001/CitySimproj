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

    class PowerPlantMalfunction : EconomicsEventsBlueprint // Power Plant Malfunctioning
    {
        public PowerPlantMalfunction() : base("PowerPlant Malfunctioning") { }
        public override void StartEffect()
        {
            // Get this turns electry generation.
            var electricitySum = BuildingManager.GetAllBuildings()
                .Where(b => b.PowerConsumption < 0).ToList()
                .Sum(b => b.PowerConsumption);

            Production.GetAllGoods()[Production.MarketRef.Power] += electricitySum;
        }
    }

    // Explanation


}