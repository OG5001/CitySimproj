using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class ServiceBuilding : Building
	{
		public ServiceBuilding(string name, Service type,int x, int y) : base(name, x, y)
		{
			Type = BuildingType.Service;
			MaxHealth = 100;

			DecideValues(type);
        }

		public void DecideValues(Service type)
		{
			switch (type)
			{
				case Service.CityHall:
                    BuildingCost = 50000;
                    MaintenanceCost = 2500;
                    Capacity = 50;
                    TaxIncome = 0;
                    HappinessImpact = 40;
                    ElectricityConsumption = 35;
                    WaterConsumption = 30;
                    break;
                case Service.Court:
                    BuildingCost = 25000;
                    MaintenanceCost = 2000;
                    Capacity = 200;
                    HappinessImpact = 10;
                    ElectricityConsumption = 40;
                    WaterConsumption = 30;
                    break;
                case Service.FireStation:
                    BuildingCost = 30000;
                    MaintenanceCost = 3000;
                    Capacity = 80;
                    TaxIncome = 0;
                    HappinessImpact = 35;
                    ElectricityConsumption = 45;
                    WaterConsumption = 60;
                    break;
                case Service.Hospital:
                    BuildingCost = 50000;
                    MaintenanceCost = 4000;
                    Capacity = 250;
                    TaxIncome = 0;
                    HappinessImpact = 40;
                    ElectricityConsumption = 60;
                    WaterConsumption = 50;
                    break;
                case Service.Library:
                    BuildingCost = 15000;
                    MaintenanceCost = 1000;
                    Capacity = 75;
                    TaxIncome = 0;
                    HappinessImpact = 40;
                    ElectricityConsumption = 25;
                    WaterConsumption = 10;
                    break;
                case Service.PoliceStation:
                    BuildingCost = 20000;
                    MaintenanceCost = 1500;
                    Capacity = 100;
                    TaxIncome = 0;
                    HappinessImpact = 10;
                    ElectricityConsumption = 40;
                    WaterConsumption = 25;
                    break;
                case Service.PostOffice:
                    BuildingCost = 10000;
                    MaintenanceCost = 900;
                    Capacity = 60;
                    TaxIncome = 0;
                    HappinessImpact = 10;
                    ElectricityConsumption = 15;
                    WaterConsumption = 10;
                    break;
                case Service.School:
                    BuildingCost = 35000;
                    MaintenanceCost = 1500;
                    Capacity = 400;
                    TaxIncome = 0;
                    HappinessImpact = 50;
                    ElectricityConsumption = 45;
                    WaterConsumption = 30;
                    break;
                case Service.University:
                    BuildingCost = 25000;
                    MaintenanceCost = 3000;
                    Capacity = 300;
                    TaxIncome = 0;
                    HappinessImpact = 25;
                    ElectricityConsumption = 20;
                    WaterConsumption = 20;
                    break;
                case Service.Uszoda:
                    BuildingCost = 36000;
                    MaintenanceCost = 3000;
                    Capacity = 120;
                    TaxIncome = 67;
                    HappinessImpact = 30;
                    ElectricityConsumption = 35;
                    WaterConsumption = 80;
                    break;
            }
        }
    }
}
