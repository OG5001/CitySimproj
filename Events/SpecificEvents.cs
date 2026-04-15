using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
	internal class SpecificEvents
	{
        // Spamming Da Events -_-

        public class PowerOutage : GameEvent
        {

            // Constructor 
            public PowerOutage() : base("PowerOutage", 5) { }
          
            // Must have methods
            public override void ApplyEffect()
            {
                Console.WriteLine("The PowerOutage has started!");
                // THE EFFECT 
            }
            public override void RemoveEffect()
            {
                Console.WriteLine("The PowerOutage has ended!");
                // THE END OF THE EFFECT
            }
		}
        public class EconomicCrisis : GameEvent
        {

            // Constructor 
            public EconomicCrisis() : base("EconomicCrisis", 5) { }

            // Must have methods
            public override void ApplyEffect()
            {
                Console.WriteLine("The EconomicCrisis has started!");
                // THE EFFECT 
            }
            public override void RemoveEffect()
            {
                Console.WriteLine("The EconomicCrisis has ended!");
                // THE END OF THE EFFECT
            }
        }

    }
}
