using Buildings;
using CitySimproj.Shared;

namespace CitySimproj.Economy; 

internal class Production(Treasury t)
{
    public record Good(string Name, decimal Price);
    
    public static class MarketRef
    {
        public static readonly Good Food = new("Food", 500);
        public static readonly Good Power = new("Power", 2500);
        public static readonly Good Water = new("Water", 1500);
        public static readonly Good Oil = new("Oil", 4000);
    }
    
    private static readonly Dictionary<Good, int> Inventory = new()
    {
        { MarketRef.Food, 500 },
        { MarketRef.Power, 500 },
        { MarketRef.Water, 500 },
        { MarketRef.Oil, 0 }
    };
    
    public static void Calculate(List<string> endMenu)
    {
        var buildings = BuildingManager.GetAllBuildings();

        foreach (var building in buildings)
        {
            Inventory[MarketRef.Power] -= building.PowerConsumption;
            Inventory[MarketRef.Water] -= building.WaterConsumption;
        }
        foreach (var (good, amount) in Inventory)
        {
            endMenu.Add($"{good.Name}: {amount}");
        }
    }
    
    public static int GetAmount(Good item)
    {
        return Inventory.GetValueOrDefault(item, 0);
    }

    public static Dictionary<Good, int> GetAllGoods()
    {
        return Inventory;
    }
    
    public void EndTurn()
    {
        var done = 0;
        var endTurn = new Menu([
            @"  _____ _        _       ",
            @" / ____| |      | |      ",
            @"| (___ | |_ __ _| |_ ___ ",
            @" \___ \| __/ _` | __/ __|",
            @" ____) | || (_| | |_\__ \",
            @"|_____/ \__\__,_|\__|___/"
        ]);
        
        List<string> endMenu = [];
        Calculate(endMenu);
        t.AddFunds(20000);
        endMenu.Add($"Balance: {t.Balance()} Ft");
        endMenu.Add("");
        endMenu.Add("Done");

        while (done != endMenu.Count - 1)
        {
            done = endTurn.DrawMenu(endMenu.ToArray());
        }
        
        Console.Clear();
    }
}