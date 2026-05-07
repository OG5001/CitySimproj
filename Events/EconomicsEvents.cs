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

    class PowerPlantMalfunction : EconomicsEventsBlueprint 
    {
        public PowerPlantMalfunction() : base("PowerPlant Malfunctioning", "A malfunction in the power plant has stopped electricity generation.") { }
        public override void StartEffect()
        {
            var electricitySum = BuildingManager.GetAllBuildings()
                .Where(b => b.PowerConsumption < 0).ToList()
                .Sum(b => b.PowerConsumption);

            Production.GetAllGoods()[Production.MarketRef.Power] += electricitySum;
        }
    }
}