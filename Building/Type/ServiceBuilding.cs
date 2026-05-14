using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buildings
{
	internal class ServiceBuilding : Building
	{
		public ServiceBuilding(string name, Service type,int x, int y) : base()
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
                    BuildingCost = 60000;
                    MaintenanceCost = 2500;
                    Capacity = 50;
                    TaxIncome = 0;
                    HappinessImpact = 40;
                    PowerConsumption = 15;
                    WaterConsumption = 10;
                    break;
                case Service.Court:
                    BuildingCost = 40000;
                    MaintenanceCost = 2000;
                    Capacity = 200;
                    HappinessImpact = 10;
                    PowerConsumption = 25;
                    WaterConsumption = 15;
                    break;
                case Service.FireStation:
                    BuildingCost = 45000;
                    MaintenanceCost = 3000;
                    Capacity = 80;
                    TaxIncome = 0;
                    HappinessImpact = 35;
                    PowerConsumption = 25;
                    WaterConsumption = 25;
                    break;
                case Service.Hospital:
                    BuildingCost = 70000;
                    MaintenanceCost = 4000;
                    Capacity = 250;
                    TaxIncome = 0;
                    HappinessImpact = 40;
                    PowerConsumption = 25;
                    WaterConsumption = 50;
                    break;
                case Service.Library:
                    BuildingCost = 22000;
                    MaintenanceCost = 1000;
                    Capacity = 75;
                    TaxIncome = 0;
                    HappinessImpact = 40;
                    PowerConsumption = 25;
                    WaterConsumption = 10;
                    break;
                case Service.PoliceStation:
                    BuildingCost = 32000;
                    MaintenanceCost = 1500;
                    Capacity = 100;
                    TaxIncome = 0;
                    HappinessImpact = 10;
                    PowerConsumption = 20;
                    WaterConsumption = 25;
                    break;
                case Service.PostOffice:
                    BuildingCost = 12000;
                    MaintenanceCost = 900;
                    Capacity = 60;
                    TaxIncome = 0;
                    HappinessImpact = 10;
                    PowerConsumption = 15;
                    WaterConsumption = 10;
                    break;
                case Service.School:
                    BuildingCost = 50000;
                    MaintenanceCost = 1500;
                    Capacity = 400;
                    TaxIncome = 0;
                    HappinessImpact = 50;
                    PowerConsumption = 15;
                    WaterConsumption = 10;
                    break;
                case Service.University:
                    BuildingCost = 65000;
                    MaintenanceCost = 3000;
                    Capacity = 300;
                    TaxIncome = 0;
                    HappinessImpact = 25;
                    PowerConsumption = 10;
                    WaterConsumption = 10;
                    break;
                case Service.Uszoda:
                    BuildingCost = 42000;
                    MaintenanceCost = 3000;
                    Capacity = 120;
                    TaxIncome = 67;
                    HappinessImpact = 30;
                    PowerConsumption = 15;
                    WaterConsumption = 25;
                    break;
            }
        }
    }
}
