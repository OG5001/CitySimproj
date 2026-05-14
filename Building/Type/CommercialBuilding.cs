using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class CommercialBuilding : Building
	{
		public CommercialBuilding(string name, Commercial type, int x, int y) : base()
		{

			Type = BuildingType.Commercial;
			MaxHealth = 100;
			DecideValues(type);
		}

		public void DecideValues(Commercial type)
		{
			switch (type)
			{
				case Commercial.Shop:
					BuildingCost = 6000;
					MaintenanceCost = 250;
					TaxIncome = 300;
					Capacity = 10;
					HappinessImpact = 25;
					PowerConsumption = 10;
					WaterConsumption = 10;
					break;
				case Commercial.Supermarket:
					BuildingCost = 18000;
					MaintenanceCost = 1000;
					TaxIncome = 1200;
					Capacity = 100;
					HappinessImpact = 45;
					PowerConsumption = 20;
					WaterConsumption = 20;
					break;
				case Commercial.ShoppingMall:
					BuildingCost = 45000;
					MaintenanceCost = 2000;
					TaxIncome = 2500;
					Capacity = 300;
					HappinessImpact = 100;
					PowerConsumption = 30;
					WaterConsumption = 25;
					break;
				case Commercial.Restaurant:
					BuildingCost = 14000;
					MaintenanceCost = 700;
					TaxIncome = 800;
					Capacity = 50;
					HappinessImpact = 90;
					PowerConsumption = 25;
					WaterConsumption = 25;
					break;
				case Commercial.Cafe:
					BuildingCost = 9000;
					MaintenanceCost = 600;
					TaxIncome = 750;
					Capacity = 30;
					HappinessImpact = 75;
					PowerConsumption = 20;
					WaterConsumption = 25;
					break;
				case Commercial.OfficeBuilding:
					BuildingCost = 35000;
					MaintenanceCost = 2000;
					TaxIncome = 2500;
					Capacity = 100;
					HappinessImpact = -10;
					PowerConsumption = 30;
					WaterConsumption = 20;
					break;
				case Commercial.Bank:
					BuildingCost = 30000;
					MaintenanceCost = 1000;
					TaxIncome = 2000;
					Capacity = 80;
					HappinessImpact = 10;
					PowerConsumption = 20;
					WaterConsumption = 10;
					break;
				case Commercial.Cinema:
					BuildingCost = 22000;
					MaintenanceCost = 800;
					TaxIncome = 1000;
					Capacity = 90;
					HappinessImpact = 100;
					PowerConsumption = 25;
					WaterConsumption = 15;
					break;
			}
		}
	}
}
