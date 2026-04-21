using CitySimproj;

namespace Buildings
{
	internal class Program
	{
        static void Main(string[] args)
		{
			BuildingManager manager = new BuildingManager();
			EventManager eventManager = new EventManager();
			Treasury treasury = new Treasury();
            Production product = new Production(treasury);
            manager.DefaultSetUp();

            bool running = true;

            while (running)
			{
				Console.WriteLine("\n==== CITY BUILDER ====\n\t1. Épület építés\n\t2. Térkép megjelenítés\n\t3. Épületek listázása\n\t4. Kilépés\n\t5. Következő nap");
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
					case 5:
						eventManager.Chance();
						break;

					default:
						Console.WriteLine("Hibás");
						break;
				}

				product.Calculate();
				treasury.Balance();
			}
		}
		
    }
}