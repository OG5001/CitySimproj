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

        public Job(string title, int[] special, int salary=1000/*minimálnér*/)
        {
            this.title = title;
            this.special = special;
            this.salary = salary;
        }

        public string Title { get => title; set => title = value; }
        public int Salary { get => salary; set => salary = value; }
        public int[] Special { get => special; set => special = value; }

    }
}
