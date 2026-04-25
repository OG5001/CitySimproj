using Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
    internal class Database
    {
        private List<Person> npcS;
        private Dictionary<string, Building> buildingsBuilt;

        private Random random;

        public Database()
        {
            npcS = new List<Person>();
            buildingsBuilt = new Dictionary<string, Building>();
        }

        internal List<Person> NpcS { get => npcS; set => npcS = value; }
        public Dictionary<string, Building> BuildingsBuilt { get => buildingsBuilt; set => buildingsBuilt = value; }


        // Add 
        public void NPCAdd(List<Person> p)
        {
            foreach (var i in p)
            {
                npcS.Add(i);
            }
        }


        // Kiiratas
        public void Kiiratas()
        {
            
        }
    }
}