namespace Buildings
{
	internal class Program
	{
		static void Main(string[] args)
		{
			BuildingManager manager = new BuildingManager();

			bool running = true;

			while (running)
			{
				Console.WriteLine("\n==== CITY BUILDER ====\n\t1. Épület építés\n\t2. Térkép megjelenítés\n\t3. Épületek listázása\n\t4. Kilépés");
				int choice = int.Parse(Console.ReadLine());

				switch (choice)
				{
					case 1:
						manager.Menu();
						break;

					case 2:
						BuildingManager.Draw();
						break;

					case 3:
						BuildingManager.Kiiratas();
						break;

					case 4:
						running = false;
						break;

					default:
						Console.WriteLine("Hibás");
						break;
				}
			}
		}
		/*static void Main(string[] args)
        {
            //List<Building> buildings = new List<Building>();
            //buildings.Add(new ResidentialBuilding("Lakóház1", 5, 10));
            //Console.WriteLine(buildings);
            ResidentialBuilding h1 = new ResidentialBuilding("Ház1", 10, 20);
            ResidentialBuilding h2 = new ResidentialBuilding("Ház2", 10, 20);
            ResidentialBuilding h3 = new ResidentialBuilding("Ház3", 5, 10);
            ResidentialBuilding h4 = new ResidentialBuilding("Ház4", 10, 20);
            ResidentialBuilding h5 = new ResidentialBuilding("Ház5", 0, 0);

            bool siker1 = Building.Add(h1);
            Console.WriteLine($"Hozzáadva h1: {siker1}");

            bool siker2 = Building.Remove(h2);
            Console.WriteLine($"törölve h2: {siker2}");

            bool siker3 = Building.Remove(h3);
            Console.WriteLine($"törölve h3: {siker3}");

            bool siker4 = Building.Add(h3);
            Console.WriteLine($"Hozzáadva h1: {siker4}");

            bool siker5 = Building.Add(h4);
            Console.WriteLine($"Hozzáadva h1: {siker5}");

            bool siker6 = Building.Add(h5);
            Console.WriteLine($"Hozzáadva h1: {siker6}");

            Building.Draw();
            Building.Kiiratas();
            //BuildingManager manager = new BuildingManager();
            // manager.Menu();
        }*/
	}
}