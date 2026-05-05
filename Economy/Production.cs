using Buildings;

namespace CitySimproj; 

internal class Production
{
    public record Good(string Name, decimal Price);
    
    public static class MarketRef
    {
        public static readonly Good Food = new("Food", 10);
        public static readonly Good Power = new("Power", 25);
        public static readonly Good Water = new("Water", 5);
        public static readonly Good Oil = new("Oil", 100);
    }
    
    private static Dictionary<Good, int> _inventory = new()
    {
        { MarketRef.Food, 0 },
        { MarketRef.Power, 0 },
        { MarketRef.Water, 0 },
        { MarketRef.Oil, 0 }
    };
    
    public void Calculate()
    {
        var buildings = BuildingManager.GetAllBuildings();

        foreach (var building in buildings)
        {
            _inventory[MarketRef.Power] -= building.PowerConsumption;
            _inventory[MarketRef.Water] -= building.WaterConsumption;
        }

        Console.WriteLine($"\nPower: {_inventory[MarketRef.Power]}");
        Console.WriteLine($"Water: {_inventory[MarketRef.Water]}");
    }
    
    public int GetAmount(Good item)
    {
        return _inventory.TryGetValue(item, out int amount) ? amount : 0;
    }

    public static Dictionary<Good, int> GetAllGoods()
    {
        return _inventory;
    }
}