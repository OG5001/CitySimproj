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
			int final = 0;
			int amount = 0;
			int confirm = 0;
			bool check = true;

			Console.WriteLine("(1) Buy | (2) Sell");

			do
			{
				buyorsell = int.Parse(Console.ReadLine()!);
			}
			while (buyorsell < 0 || buyorsell > 2);
			
			Console.WriteLine("\n------- Market -------\n");
			var goods = Production.GetAllGoods();
			int num = 0;

			// Menu based on choice
			// create a list to hold only the items the user sees
			List<Production.Good> availableToUser = new List<Production.Good>();

			if (buyorsell == 1)
			{
				foreach (var good in goods) {
					availableToUser.Add(good.Key); // Buy mode: Add everything
					num++;
					Console.WriteLine($"({num}) {good.Key.Name} -- Price: {good.Key.Price} Ft (you have: {good.Value})");
				}
			}
			else
			{
				foreach (var good in goods)
				{
					if (good.Value > 0)
					{
						availableToUser.Add(good.Key); // Sell mode: Only add if quantity > 0
						num++;
						Console.WriteLine($"({num}) {good.Key.Name} -- Price: {good.Key.Price} Ft (you have: {good.Value})");
					}
				}
				check = availableToUser.Count > 0;
			}

			// runs on buy, only runs on sell if player has smth to sell
			if (check)
			{
				do
				{
					item = int.Parse(Console.ReadLine()!);
				}
				while (item < 0 || item > num + 1);
			
				// get selected item
				var selectedGood = availableToUser[item - 1];

				// if buy
				if (buyorsell == 1)
				{
					var canAfford = (int)(treasury.Balance() / selectedGood.Price);
					Console.WriteLine($"\n-- How much? (1 - {canAfford}) --\n");
					Console.WriteLine(treasury);
			
					do
					{
						amount = int.Parse(Console.ReadLine()!);
					}
					while (amount < 0 || amount > canAfford);
					final = (int)selectedGood.Price * amount;
				
					// double check
					Console.WriteLine($"Are you sure? (1/2)\nYou will pay: {final} Ft");
				
					do
					{
						confirm = int.Parse(Console.ReadLine()!);
					}
					while (confirm < 0 || confirm > 2);

					if (confirm == 1)
					{
						// Remove the items from the inventory
						Production.GetAllGoods()[selectedGood] += amount;

						// Remove money from the treasury
						treasury.RemoveFunds(final); 

						Console.WriteLine($"Bought {amount} {selectedGood.Name} for {final} Ft.");
					}
				}
			
				// if sell
				if (buyorsell == 2)
				{
					int canSell = Production.GetAllGoods()[selectedGood];
					Console.WriteLine($"\n-- How much? (1 - {canSell}) --\n");
					Console.WriteLine(treasury);
			
					do
					{
						amount = int.Parse(Console.ReadLine()!);
					}
					while (amount < 0 || amount > canSell);
					final = (int)selectedGood.Price * amount;
				
					// double check
					Console.WriteLine($"Are you sure? (1/2)\nYou will get: {final} Ft");
				
					do
					{
						confirm = int.Parse(Console.ReadLine()!);
					}
					while (confirm < 0 || confirm > 2);

					if (confirm == 1)
					{
						// Remove the items from the inventory
						Production.GetAllGoods()[selectedGood] -= amount;

						// Add the money to the treasury
						treasury.AddFunds(final); 

						Console.WriteLine($"Sold {amount} {selectedGood.Name} for {final} Ft.");
					}
				}
			}
			else
			{
				Console.WriteLine("You don't have any goods to sell.");
			}
		}
	}
}
