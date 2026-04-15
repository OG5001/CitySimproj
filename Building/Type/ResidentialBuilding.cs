using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
    public class ResidentialBuilding : Building
    {
        public ResidentialBuilding(string name, Residential type, int x, int y): base(name, x, y)
        {
            Type = BuildingType.Residential;
			MaxHealth = 100;
			DecideValues(type);
		}

		public void DecideValues(Residential type)
		{
			switch (type)
			{
				case Residential.House:
					BuildingCost = 1000;
					MaintenanceCost = 100;
					TaxIncome = 250;
					Capacity = 10;
					HappinessImpact = 35;
					ElectricityConsumption = 10;
					WaterConsumption = 10;
					break;
				case Residential.ApartmentBlock:
					BuildingCost = 10000;
					MaintenanceCost = 500;
					TaxIncome = 2500;
					Capacity = 200;
					HappinessImpact = 20;
					ElectricityConsumption = 50;
					WaterConsumption = 50;
					break;
				case Residential.Villa:
					BuildingCost = 20000;
					MaintenanceCost = 500;
					TaxIncome = 1000;
					Capacity = 15;
					HappinessImpact = 100;
					ElectricityConsumption = 20;
					WaterConsumption = 20;
					break;
				case Residential.Hotel:
					BuildingCost = 15000;
					MaintenanceCost = 500;
					TaxIncome = 1000;
					Capacity = 400;
					HappinessImpact = 70;
					ElectricityConsumption = 60;
					WaterConsumption = 60;
					break;
				case Residential.RetirementHome:
					BuildingCost = 2000;
					MaintenanceCost = 200;
					TaxIncome = 100;
					Capacity = 50;
					HappinessImpact = 75;
					ElectricityConsumption = 20;
					WaterConsumption = 20;
					break;
				case Residential.Dormitory:
					BuildingCost = 5000;
					MaintenanceCost = 500;
					TaxIncome = 150;
					Capacity = 100;
					HappinessImpact = 50;
					ElectricityConsumption = 25;
					WaterConsumption = 25;
					break;
				case Residential.StudentHousing:
					BuildingCost = 5000;
					MaintenanceCost = 500;
					TaxIncome = 150;
					Capacity = 100;
					HappinessImpact = 50;
					ElectricityConsumption = 25;
					WaterConsumption = 25;
					break;
				case Residential.Townhouse:
					BuildingCost = 1000;
					MaintenanceCost = 75;
					TaxIncome = 200;
					Capacity = 10;
					HappinessImpact = 40;
					ElectricityConsumption = 5;
					WaterConsumption = 10;
					break;

			}
		}
		public override string ToString()
		{
			return $"Building Cost: {BuildingCost}, Maintenance Cost: {MaintenanceCost}, Tax Income: {TaxIncome}, Capacity: {Capacity}, Happiness Impact: {HappinessImpact}, Electricity Consumption: {ElectricityConsumption}, Water Consumption: {WaterConsumption} ";
		}
	}
}
