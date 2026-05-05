namespace CitySimproj;
internal class EconomyManager(Treasury t)
{
	public void Choice()
	{
		var buyorsell = 0;
		var check = true;

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
			// check balance
			if (t.Balance() < 500)
			{
				check = false;
			}
			
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
					num++; // the sell price is a little bit less compared to buying
					Console.WriteLine($"({num}) {good.Key.Name} -- Price: {good.Key.Price - 200} Ft (you have: {good.Value})");
				}
			}
			check = availableToUser.Count > 0;
		}

		// runs on buy, only runs on sell if player has smth to sell
		if (check)
		{
			var item = 0;
			do
			{
				item = int.Parse(Console.ReadLine()!);
			}
			while (item < 0 || item > num + 1);
		
			// get selected item
			var selectedGood = availableToUser[item - 1];

			// if buy
			var final = 0;
			var amount = 0;
			var confirm = 0;
			if (buyorsell == 1)
			{
				var canAfford = (int)(t.Balance() / selectedGood.Price);
				Console.WriteLine($"\n-- How much? (1 - {canAfford}) --\n");
				Console.WriteLine(t);
		
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
					t.RemoveFunds(final); 

					Console.WriteLine($"Bought {amount} {selectedGood.Name} for {final} Ft.");
				}
			}
		
			// if sell
			if (buyorsell == 2)
			{
				int canSell = Production.GetAllGoods()[selectedGood];
				Console.WriteLine($"\n-- How much? (1 - {canSell}) --\n");
				Console.WriteLine(t);
		
				do
				{
					amount = int.Parse(Console.ReadLine()!);
				}
				while (amount < 0 || amount > canSell);
				final = (int)(selectedGood.Price - 200) * amount; // a lil bit less cuz selling
			
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
					t.AddFunds(final); 

					Console.WriteLine($"Sold {amount} {selectedGood.Name} for {final} Ft.");
				}
			}
		}
		else
		{
			Console.WriteLine(buyorsell == 1
				? "\nYou don't have enough money!"
				: "\nYou don't have any goods to sell!");
		}
	}
}
