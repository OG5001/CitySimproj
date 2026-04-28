using Buildings;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace CitySimproj; 

internal class Production
{
    private int electricity = 0;
    private int water = 0;
    private Treasury treasury;

    public Production(Treasury t)
    {
        this.treasury = t;
    }
    public void Calculate()
    {
        var buildings = BuildingManager.GetAllBuildings();
        EventManager eventsManager = new EventManager();
        int allEProv = 0; // Event Managernek kell


        foreach (var building in buildings)
        {
            if (building.ElectricityConsumption < 0)
            {
                allEProv += building.ElectricityConsumption;
            }
            electricity = electricity - building.ElectricityConsumption;
            water = water - building.WaterConsumption;
        }


        Console.WriteLine($"\nElectricity: {electricity}");
        Console.WriteLine($"Water: {water}");


        if (electricity > 0)
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
                treasury.AddMoney(electricity);
                electricity = 0;
            }
        }

    }
}