using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
    // BLUEPRINT for the events
    internal abstract class GameEvent
    {
        // Constructor to initialize the properties of the GameEvent class.
        protected GameEvent(string name, int duration) 
        {
            Name = name;
            Duration = duration;
            random = new Random();
        }

        // The private variables are created automatically by the properties, so we don't need to declare them separately.
        public string Name { get; protected set; }
        public int Duration { get; set; }
        protected Random random;


        // The abstract methods does not have a body, but they must have these properties and methods in the derived classes.
        public abstract void ApplyEffect(); // Start of the event, apply the effect to the game.
        public abstract void RemoveEffect(); // End of the event, remove the effect from the game.

    }
}
