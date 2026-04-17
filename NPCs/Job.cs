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
        private int salary; //órabér/havibér/éves bér, majd eldől
        private int[] special; //ha a dolgozó npc ezeket az értékeket eléri, akkor produktívabb és boldogabb
        private int workHours; //munkanap hossza/ heti dolgozott órák, majd később eldől

        public Job(string title, int[] special, int salary=1000/*minimálnér*/, int workHours=8)
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

        private int OvertimeSalary(int hoursInOvertime)//napi/heti bér értékét adja vissza
        {
            return salary*workHours+Convert.ToInt32(hoursInOvertime * salary * 1.5);
        }
    }
}
