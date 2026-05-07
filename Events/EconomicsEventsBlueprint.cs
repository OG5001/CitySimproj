using Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{

    // The Blueprint class for Natural Disasters.
    abstract class EconomicsEventsBlueprint
    {
        private string name;
        private string description;

        public string Name => name;
        public string Description => description;

        public EconomicsEventsBlueprint(string name, string description)
        {
            this.name = name;
            this.description = description; 
        }

        public virtual void StartEffect()
        {   
        }
      
    }

}