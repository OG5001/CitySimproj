using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class CommercialBuilding : Building
	{
		public CommercialBuilding(string name, Commercial type, int x, int y) : base(name, x, y)
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
					BuildingCost = 5000;
					MaintenanceCost = 250;
					TaxIncome = 300;
					Capacity = 10;
					HappinessImpact = 25;
					ElectricityConsumption = 10;
					WaterConsumption = 10;
					break;
				case Commercial.Supermarket:
					BuildingCost = 15000;
					MaintenanceCost = 1000;
					TaxIncome = 1200;
					Capacity = 100;
					HappinessImpact = 45;
					ElectricityConsumption = 30;
					WaterConsumption = 20;
					break;
				case Commercial.ShoppingMall:
					BuildingCost = 25000;
					MaintenanceCost = 2000;
					TaxIncome = 2500;
					Capacity = 300;
					HappinessImpact = 100;
					ElectricityConsumption = 120;
					WaterConsumption = 90;
					break;
				case Commercial.Restaurant:
					BuildingCost = 7500;
					MaintenanceCost = 700;
					TaxIncome = 800;
					Capacity = 50;
					HappinessImpact = 90;
					ElectricityConsumption = 45;
					WaterConsumption = 50;
					break;
				case Commercial.Cafe:
					BuildingCost = 5000;
					MaintenanceCost = 600;
					TaxIncome = 750;
					Capacity = 30;
					HappinessImpact = 75;
					ElectricityConsumption = 30;
					WaterConsumption = 35;
					break;
				case Commercial.OfficeBuilding:
					BuildingCost = 20000;
					MaintenanceCost = 2000;
					TaxIncome = 2500;
					Capacity = 100;
					HappinessImpact = -10;
					ElectricityConsumption = 80;
					WaterConsumption = 70;
					break;
				case Commercial.Bank:
					BuildingCost = 15000;
					MaintenanceCost = 1000;
					TaxIncome = 2000;
					Capacity = 80;
					HappinessImpact = 10;
					ElectricityConsumption = 30;
					WaterConsumption = 20;
					break;
				case Commercial.Cinema:
					BuildingCost = 10000;
					MaintenanceCost = 800;
					TaxIncome = 1000;
					Capacity = 90;
					HappinessImpact = 100;
					ElectricityConsumption = 50;
					WaterConsumption = 25;
					break;
			}
		}
		public override string ToString()
		{
			return $"Building Cost: {BuildingCost}, Maintenance Cost: {MaintenanceCost}, Tax Income: {TaxIncome}, Capacity: {Capacity}, Happiness Impact: {HappinessImpact}, Electricity Consumption: {ElectricityConsumption}, Water Consumption: {WaterConsumption} ";
		}
	}
}
