using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
    internal class HappinessManager
    {
        //kalkulálja ki a boldogságát az aott npcnek hogy mennyire orül a munkájának, mennyi pénze van, és milyen az egészsége
        public int JobSatisfaction(Person person)
        {
            int satisfaction = 0;
            Job job = person.Job;
            int[] npcStats = person.Ps.Special;

            for (int i = 0; i < job.Special.Length; i++)
            {
                // ha az npc statja eléri a munkához szükséges értéket, akkor növeli a boldogságot
                if (i < npcStats.Length && npcStats[i] >= job.Special[i] && job.Special[i] > 0)
                {
                    satisfaction += 5;
                }
            }
            return satisfaction;
        }

        public void UpdateHappiness(Person person)
        {
            int currentHappiness = person.Ps.Happiness;

            // életpont és boldogság viszony
            if (person.Health < 50) currentHappiness -= 5;
            if (person.Health < 20) currentHappiness -= 10;

            // sok pénz = boldogság
            if (person.Ps.NetWorth > 10000) currentHappiness += 2;

            // munkája a boldogság szempontjábol
            currentHappiness += JobSatisfaction(person);

            //hogy ne legyen több vagy kevesebb mint a határ
            if (currentHappiness > 100) currentHappiness = 100;
            if (currentHappiness < 0) currentHappiness = 0;
        }
    }
}