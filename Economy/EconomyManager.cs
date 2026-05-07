using CitySimproj.Shared;

namespace CitySimproj;
internal class EconomyManager(Treasury t)
{
	public void Choice()
	{
        Menu MainTitle = new Menu(new[]
        {
            @" _______            _ _             ",
            @"|__   __|          | (_)            ",
            @"   | |_ __ __ _  __| |_ _ __   __ _ ",
            @"   | | '__/ _` |/ _` | | '_ \ / _` |",
            @"   | | | | (_| | (_| | | | | | (_| |",
            @"   |_|_|  \__,_|\__,_|_|_| |_|\__, |",
            @"                               __/ |",
            @"                              |___/"
        });

        Menu BuyTitle= new Menu(new[]
        {
			@" ____              ",
            @"|  _ \             ",
			@"| |_) |_   _ _   _ ",
			@"|  _ <| | | | | | |",
			@"| |_) | |_| | |_| |",
			@"|____/ \__,_|\__, |",
			@"              __/ |",
			@"             |___/"
		});

		Menu SellTitle = new Menu(new[]
		{
            @"  _____      _ _ ",
			@" / ____|    | | |",
			@"|  (___  ___| | |",
			@" \___ \ / _ \ | |",
			@" ____) |  __/ | |",
			@"|_____/ \___|_|_|"
        });

        Menu AmountTitle = new Menu(new[]
        {
            @"                                      _   ",
            @"    /\                               | |  ",
            @"   /  \   _ __ ___   ___  _   _ _ __ | |_ ",
            @"  / /\ \ | '_ ` _ \ / _ \| | | | '_ \| __|",
            @" / ____ \| | | | | | (_) | |_| | | | | |_ ",
            @"/_/    \_\_| |_| |_|\___/ \__,_|_| |_|\__|"
        });

        Menu DoubleCheckTitle = new Menu(new[]
        {
            @"                                                           ___  ",
            @"    /\                                                    |__ \ ",
            @"   /  \   _ __ ___   _   _  ___  _   _   ___ _   _ _ __ ___  ) |",
            @"  / /\ \ | '__/ _ \ | | | |/ _ \| | | | / __| | | | '__/ _ \/ /",
            @" / ____ \| | |  __/ | |_| | (_) | |_| | \__ \ |_| | | |  __/_|", 
            @"/_/    \_\_|  \___|  \__, |\___/ \__,_| |___/\__,_|_|  \___(_)",
            @"                      __/ |",                                 
            @"                     |___/",
        });
    
		string[] BuyOrSell =
		{
			"Buy",
			"Sell",
			"Exit"
		};


        List<string> checkMenu = new();
        List<string> buyMenu = new();
        List<string> sellMenu = new();

        int buyorsell = MainTitle.DrawMenu(BuyOrSell);
		var go = true;
		var check = true;
		var goods = Production.GetAllGoods();
		
		// create a list to hold only the items the user sees
		List<Production.Good> availableToUser = new List<Production.Good>();

		// check for funds, goods, and exit
		if (buyorsell == 0)
		{
			// check balance
			if (t.Balance() < 500)
			{
				go = false;
				check = false;
			}
			
			foreach (var good in goods) {
				availableToUser.Add(good.Key); // Buy mode: Add everything
                buyMenu.Add($"{good.Key.Name} -- Price: {good.Key.Price} Ft (you have: {good.Value})");
            }
		}
		else if (buyorsell == 1)
		{ 
			foreach (var good in goods)
			{
				if (good.Value > 0)
				{
					availableToUser.Add(good.Key); // Sell mode: Only add if quantity > 0
                    sellMenu.Add($"{good.Key.Name} -- Price: {good.Key.Price - 200} Ft (you have: {good.Value})");
                }
			}
			go = availableToUser.Count > 0;
            check = availableToUser.Count > 0;
        }
		else // exits
		{
			go = false;
		}

		// runs if prerequisites go through
		if (go)
		{
			int item = 0;
            
			// Select goods
            if (buyorsell == 0)
            {
				item = BuyTitle.DrawMenu(buyMenu.ToArray());
            }
            else
            {
                item = SellTitle.DrawMenu(sellMenu.ToArray());
            }
		
			// get selected item
			var selectedGood = availableToUser[item];

			// if buy
			var final = 0;
			var amount = 0;
			var confirm = 0;
			if (buyorsell == 0)
			{
                int canAfford = (int)(t.Balance() / selectedGood.Price);

                amount = AmountTitle.SelectAmount(1,canAfford);
                final = (int)selectedGood.Price * amount;
			
				// double check
				checkMenu.Add($"You will pay: {final} Ft");
                checkMenu.Add("Yes");
                checkMenu.Add("No");

                while (confirm == 0)
                {
                    confirm = DoubleCheckTitle.DrawMenu(checkMenu.ToArray());
                }

                if (confirm == 1)
				{
					// Remove the items from the inventory
					Production.GetAllGoods()[selectedGood] += amount;

					// Remove money from the treasury
					t.RemoveFunds(final); 

                    Console.Clear();
					Menu.WriteCentered($"Bought {amount} {selectedGood.Name} for {final} Ft.", ConsoleColor.Green);
                    Console.ReadKey(true);
                }
			}
		
			// if sell
			if (buyorsell == 1)
			{
                int canSell = Production.GetAllGoods()[selectedGood];

                amount = AmountTitle.SelectAmount(1,canSell);
                final = (int)(selectedGood.Price - 200) * amount; // a lil bit less cuz selling

                // double check
                checkMenu.Add($"You will get: {final} Ft");
                checkMenu.Add("Yes");
                checkMenu.Add("No");

                while (confirm == 0)
                {
                   confirm = DoubleCheckTitle.DrawMenu(checkMenu.ToArray());
                }
               
                if (confirm == 1)
				{
					// Remove the items from the inventory
					Production.GetAllGoods()[selectedGood] -= amount;

					// Add the money to the treasury
					t.AddFunds(final);

                    Console.Clear();
                    Menu.WriteCentered($"Sold {amount} {selectedGood.Name} for {final} Ft.", ConsoleColor.Green);
                    Console.ReadKey(true);
                }
			}
            Console.Clear();
		}
        else
        {
            Console.Clear();
            if (!check)
            {
                string text = (buyorsell == 1
                ? "\nYou don't have enough money!"
                : "\nYou don't have any goods to sell!");

                Menu.WriteCentered(text, ConsoleColor.Red);
                Console.ReadKey(true);
            }
        }
        Console.Clear();
    }

   
}
