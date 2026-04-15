namespace Buildings
{
	public class Location
    {
		private Building building;

		private int x;
		private int y;

        public Location(Building building, int x, int y)
        {
            this.building = building;
            this.x = x;
            this.y = y;
        }
    }
    //Nincs használva, de a későbbiekben lehet, hogy szükség lesz rá, ezért létrehoztam egy külön osztályt a helyeknek, ahol az épületek állnak, így könnyebben kezelhető lesz a város térképe
}
