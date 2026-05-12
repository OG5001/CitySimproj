using Buildings;

namespace CitySimproj.Events
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