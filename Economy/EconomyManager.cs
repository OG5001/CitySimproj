using CitySimproj;
namespace Buildings
{
	internal class EconomyManager
	{

		private Treasury treasury;

		public EconomyManager(Treasury t)
		{
			this.treasury = t;
		}
		public void Choice()
		{
			int buyorsell = 0;
			int item = 0;
			int amount = 0;

			Console.WriteLine("(1) Buy | (2) Sell");

			do
			{
				buyorsell = int.Parse(Console.ReadLine()!);
			}
			while (buyorsell < 0 || buyorsell > 2);
			
			Console.WriteLine("\n------- Market -------\n");
			var goods = Production.GetAllGoods();
			int num = 0;

			foreach (var good in goods) {
				num++;
				Console.WriteLine($"{num}. {good.Key.Name} - Amount: {good.Value} (Price: {good.Key.Price} Ft)");
			}

			do
			{
				item = int.Parse(Console.ReadLine()!);
			}
			while (item < 0 || item > num + 1);

			Console.WriteLine("\n-- How much? --\n");
			Console.WriteLine($"(You have {treasury} Ft)");
			
		}
	}
}
