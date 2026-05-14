using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
    internal class MoodSystem
    {
        public Npclib.MoodState GetCurrentMood(Person person)
        {
            int happiness = person.Ps.Happiness;

            if (happiness <= 20) return Npclib.MoodState.Miserable;
            if (happiness <= 40) return Npclib.MoodState.Annoyed;
            if (happiness <= 60) return Npclib.MoodState.Neutral;
            if (happiness <= 80) return Npclib.MoodState.Content;
            return Npclib.MoodState.Ecstatic;
        }

        public string GetMoodDescription(Person person)
        {
            Npclib.MoodState state = GetCurrentMood(person);

            return state switch
            {
                Npclib.MoodState.Miserable => "is feeling terrible and wants to quit.",
                Npclib.MoodState.Annoyed => "is having a bit of a rough day.",
                Npclib.MoodState.Neutral => "is doing okay.",
                Npclib.MoodState.Content => "is quite happy with life.",
                Npclib.MoodState.Ecstatic => "is absolutely loving their life!",
                _ => "is feeling unreadable."
            };
        }
    }
}