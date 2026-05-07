namespace CitySimproj;
internal class EconomyManager(Treasury t)
{
	public void Choice()
	{
        string[] MainTitle =
		{
			@" _______            _ _             ",
			@"|__   __|          | (_)            ",
			@"   | |_ __ __ _  __| |_ _ __   __ _ ",
			@"   | | '__/ _` |/ _` | | '_ \ / _` |",
			@"   | | | | (_| | (_| | | | | | (_| |",
			@"   |_|_|  \__,_|\__,_|_|_| |_|\__, |",
			@"                               __/ |",
			@"                              |___/"
		};

		string[] BuyTitle =
		{
			@" ____              ",
			@"|  _ \             ",
			@"| |_) |_   _ _   _ ",
			@"|  _ <| | | | | | |",
			@"| |_) | |_| | |_| |",
			@"|____/ \__,_|\__, |",
			@"              __/ |",
			@"             |___/"
		};

		string[] SellTitle =
		{
            @"  _____      _ _ ",
			@" / ____|    | | |",
			@"|  (___  ___| | |",
			@" \___ \ / _ \ | |",
			@" ____) |  __/ | |",
			@"|_____/ \___|_|_|"
        };

        string[] AmountTitle =
        {
            @"                                      _   ",
            @"    /\                               | |  ",
            @"   /  \   _ __ ___   ___  _   _ _ __ | |_ ",
            @"  / /\ \ | '_ ` _ \ / _ \| | | | '_ \| __|",
            @" / ____ \| | | | | | (_) | |_| | | | | |_ ",
            @"/_/    \_\_| |_| |_|\___/ \__,_|_| |_|\__|"
        };

        string[] DoubleCheckTitle =
        {
            @"                                                           ___  ",
            @"    /\                                                    |__ \ ",
            @"   /  \   _ __ ___   _   _  ___  _   _   ___ _   _ _ __ ___  ) |",
            @"  / /\ \ | '__/ _ \ | | | |/ _ \| | | | / __| | | | '__/ _ \/ /",
            @" / ____ \| | |  __/ | |_| | (_) | |_| | \__ \ |_| | | |  __/_|", 
            @"/_/    \_\_|  \___|  \__, |\___/ \__,_| |___/\__,_|_|  \___(_)",
            @"                      __/ |",                                 
            @"                     |___/",
        };
    
		string[] BuyOrSell =
		{
			"Buy",
			"Sell",
			"Exit"
		};


        List<string> checkMenu = new();
        List<string> buyMenu = new();
        List<string> sellMenu = new();

        int buyorsell = DrawMenu(MainTitle, BuyOrSell);
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

		// runs on buy, only runs on sell if player has smth to sell
		if (go)
		{
            int num = 0;
			int item = 0;
            
			// Select goods
            if (buyorsell == 0)
            {
				item = DrawMenu(BuyTitle, buyMenu.ToArray());
            }
            else
            {
                item = DrawMenu(SellTitle, sellMenu.ToArray());
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

                amount = SelectAmount(1,canAfford, AmountTitle);
                final = (int)selectedGood.Price * amount;
			
				// double check
				checkMenu.Add($"You will pay: {final} Ft");
                checkMenu.Add("Yes");
                checkMenu.Add("No");

                while (confirm == 0)
                {
                    confirm = DrawMenu(DoubleCheckTitle, checkMenu.ToArray());
                }

                if (confirm == 1)
				{
					// Remove the items from the inventory
					Production.GetAllGoods()[selectedGood] += amount;

					// Remove money from the treasury
					t.RemoveFunds(final); 

                    Console.Clear();
					WriteCentered($"Bought {amount} {selectedGood.Name} for {final} Ft.", ConsoleColor.Green);
                    Console.ReadKey(true);
                }
			}
		
			// if sell
			if (buyorsell == 1)
			{
                int canSell = Production.GetAllGoods()[selectedGood];

                amount = SelectAmount(1,canSell, AmountTitle);
                final = (int)(selectedGood.Price - 200) * amount; // a lil bit less cuz selling

                // double check
                checkMenu.Add($"You will get: {final} Ft");
                checkMenu.Add("Yes");
                checkMenu.Add("No");

                while (confirm == 0)
                {
                   confirm = DrawMenu(DoubleCheckTitle, checkMenu.ToArray());
                }
               
                if (confirm == 1)
				{
					// Remove the items from the inventory
					Production.GetAllGoods()[selectedGood] -= amount;

					// Add the money to the treasury
					t.AddFunds(final);

                    Console.Clear();
                    WriteCentered($"Sold {amount} {selectedGood.Name} for {final} Ft.", ConsoleColor.Green);
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

                WriteCentered(text, ConsoleColor.Red);
                Console.ReadKey(true);
            }
        }
        Console.Clear();
    }

    static int DrawMenu(string[] title, string[] choice)
    {
        

        int selected = 0;

        while (true)
        {
            Console.Clear();

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            int contentHeight = title.Length + choice.Length + 6;
            int startY = (windowHeight - contentHeight) / 2;

            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < title.Length; i++)
            {
                int x = (windowWidth - title[i].Length) / 2;
                Console.SetCursorPosition(x, startY + i);
                Console.Write(title[i]);
            }

            Console.ResetColor();

            for (int i = 0; i < choice.Length; i++)
            {
                string text = $"{choice[i]}";
                int x = (windowWidth - text.Length) / 2;
                int y = startY + title.Length + 2 + i;

                Console.SetCursorPosition(x, y);

                if (i == selected)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(text);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(text);
                    Console.ResetColor();
                }
            }


            WriteCentered("Use up and down arrows and Enter", ConsoleColor.DarkGray);


            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow)
            {
                selected = (selected - 1 + choice.Length) % choice.Length;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selected = (selected + 1) % choice.Length;
            }
            else if (key == ConsoleKey.Enter)
            {
                return selected;
            }
        }
    }


    static int SelectAmount(int min, int max, string[] title)
    {
        int amount = min;

        while (true)
        {
            Console.Clear();

            int windowWidth = Console.WindowWidth;

            int startY = 3;

            // Draw title
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < title.Length; i++)
            {
                int x = (windowWidth - title[i].Length) / 2;

                Console.SetCursorPosition(x, startY + i);
                Console.Write(title[i]);
            }

            Console.ResetColor();

            // Amount selector
            string text = $"< {amount} >";

            int x2 = (windowWidth - text.Length) / 2;
            int y2 = startY + title.Length + 3;

            Console.SetCursorPosition(x2, y2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);

            Console.ResetColor();

            WriteCentered("< > to change | Enter to confirm", ConsoleColor.DarkGray);

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.LeftArrow)
            {
                amount--;

                if (amount < min)
                    amount = min;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                amount++;

                if (amount > max)
                    amount = max;
            }
            else if (key == ConsoleKey.Enter)
            {
                return amount;
            }
        }
    }


    static void WriteCentered(string text, ConsoleColor color)
    {
        int x = (Console.WindowWidth - text.Length) / 2;
        int y = Console.WindowHeight - 2;

        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);
        Console.Write(text);
        Console.ResetColor();
    }
}
