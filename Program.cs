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

            List<Person> list = new List<Person>();
            for (int i = 0; i <6; i+=2)
            {
                list.Add(database.NpcS[i]);
            }

            NPCEvents nPCEvents = new NPCEvents(list);
            nPCEvents.ApplyEffect();
		}
    }
}
