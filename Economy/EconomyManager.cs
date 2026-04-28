using CitySimproj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

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
			
			Console.WriteLine("\n-- What would you like to trade? --\n");
			var goods = Production.GetAllGoods();
			int num = 0;

			foreach (var good in goods) {
				num++;
				Console.WriteLine($"{num}. {good.Key} ({good.Value})");
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
