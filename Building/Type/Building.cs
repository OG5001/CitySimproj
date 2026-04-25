namespace Buildings
{
	public class Building
	{
		//Private adattagok
		private BuildingType type;

		private decimal buildingCost;
		private decimal maintenanceCost;
		private int taxIncome;

		private int maxHealth = 100;
		private int currentHealth;

		private bool isPowered;
		private bool isConnectedToWater;

		private int capacity;
		private int currentOccupancy;

		private int happinessImpact;

		private int electricityConsumption;
		private int waterConsumption;

		//Public property-k

		public BuildingType Type { get => type; protected set => type = value; }
		public decimal BuildingCost { get => buildingCost; protected set => buildingCost = value; }
		public decimal MaintenanceCost { get => maintenanceCost; protected set => maintenanceCost = value; }
		public int TaxIncome { get => taxIncome; protected set => taxIncome = value; }
		public int MaxHealth { get => maxHealth; protected set => maxHealth = value; }
		public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
		public bool IsPowered { get => isPowered; set => isPowered = value; }
		public bool IsConnectedToWater { get => isConnectedToWater; set => isConnectedToWater = value; }
		public int Capacity { get => capacity; protected set => capacity = value; }
		public int CurrentOccupancy { get => currentOccupancy; set => currentOccupancy = value; }
		public int HappinessImpact { get => happinessImpact; protected set => happinessImpact = value; }
		public int ElectricityConsumption { get => electricityConsumption; protected set => electricityConsumption = value; }
		public int WaterConsumption { get => waterConsumption; protected set => waterConsumption = value; }

        // Konstruktor
        protected Building()
		{
			this.CurrentHealth = maxHealth;
		}

		public override string ToString()
		{
			return $"Health: {CurrentHealth}, Building Cost: {BuildingCost}, Maintenance Cost: {MaintenanceCost}, Tax Income: {TaxIncome}, Capacity: {Capacity}, Happiness Impact: {HappinessImpact}, Electricity Consumption: {ElectricityConsumption}, Water Consumption: {WaterConsumption} ";
		}
    }
}
