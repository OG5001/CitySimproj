using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitySimproj
{
    internal class Job
    {
        private string title;
        private int salary; //órabér
        private int[] special; //ha a dolgozó npc ezeket az értékeket eléri, akkor produktívabb és boldogabb
        private int workHours; //heti dolgozott órák

        public Job(string title, int[] special, int salary=1000/*minimálnér*/, int workHours=40)
        {
            this.title = title;
            this.special = special;
            this.salary = salary;
            this.workHours = workHours;
        }

        public string Title { get => title; set => title = value; }
        public int Salary { get => salary; set => salary = value; }
        public int[] Special { get => special; set => special = value; }
        public int WorkHours { get => workHours; set => workHours = value; }

        public int WeeklyIncome()//heti bér értékét adja vissza, adók előtt
        {
            return salary*workHours;
        }
    }
}
