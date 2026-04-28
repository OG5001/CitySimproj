using Buildings;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace CitySimproj; 

internal class Production
{
    private static Dictionary<string, int> goods = new Dictionary<string, int>
    {
        { "food", 0 },
        { "wood", 0 },
        { "electricity", 0 },
        { "water", 0 },
        { "uranium", 0 },
        { "plutonium", 0 },
        { "stone", 0 },
        { "oil", 0 },
        { "iron", 0 },
        { "arion_sauce", 0 }
    };
    
	private Treasury treasury;

    public Production(Treasury t)
    {
        this.treasury = t;
    }
    public void Calculate()
    {
        var buildings = BuildingManager.GetAllBuildings();

        foreach (var building in buildings)
        {
            goods["electricity"] =- building.ElectricityConsumption;
            goods["water"] =- building.WaterConsumption;
        }

        Console.WriteLine($"\nElectricity: {goods["electricity"]}");
        Console.WriteLine($"Water: {goods["water"]}");


        if (goods["electricity"] > 0)
        {
            int cmd = 0;
            Console.WriteLine("\n(1) Sell excess electricity\t(2) Save excess electricity (for the next turn)");
            do
            {
                cmd = int.Parse(Console.ReadLine()!);
            }
            while (cmd < 0 || cmd > 2);

            if (cmd == 1)
            {
                treasury.AddMoney(goods["electricity"]);
                goods["electricity"] = 0;
            }
        }


    }

	public static Dictionary<string, int> GetAllGoods()
	{
		return goods;
	}
}