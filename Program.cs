using CitySimproj;

namespace CitySimproj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person.NPC();
            Database database = new Database();
            database.NPCAdd(Person.NPC());
		}
    }
}
