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
				Console.WriteLine("\n==== CITY BUILDER ====\n\t1. Build\n\t2. Map\n\t3. List buildings\n\t4. Exit\n\t5. Next Day");
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
						product.Calculate();
						treasury.Balance();
						break;

					default:
						Console.WriteLine("ERROR");
						break;
				}
			}
		}
		
    }
}