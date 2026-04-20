namespace Cityhall
{
    internal class Program
    {
        static void Main(string[] args)
        {
          Treasury tr = new Treasury(1000000, false);
            tr.EUMoney();
            tr.Corruptcy();
            tr.EUMoney();
        }
    }
}
