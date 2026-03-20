using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;

namespace EsemenykezelesOOP
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
			EventManager eventManager = new EventManager();
            Database database = new Database();
            Person p1 = new Person(01, 25, true, 100);
			/*database.NPCAdd(newNPC);
            database.NPCAdd(newNPC1);
            database.NPCAdd(newNPC2);
            database.Kiiratas();
           
           database.UpdateAllNPC();
            */
			Console.WriteLine(p1);

            
		}

    }
}
