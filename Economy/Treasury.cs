using System;
using System.Collections.Generic;
using System.Text;

namespace CitySimproj
{
    internal class Treasury
    {
        private int treasurys;
        private bool iscorrupt;

        public Treasury(int treasurys, bool iscorrupt)
        {
            this.treasurys = treasurys;
            this.iscorrupt = iscorrupt;
        }

        public int Treasurys { get => treasurys; set => treasurys = value; }
        public bool Iscorrupt { get => iscorrupt; set => iscorrupt = value; }

        public virtual void EUMoney()
        {
            Console.Write("How many money do you need?: ");
            int cmd = Convert.ToInt32(Console.ReadLine());
            if (this.iscorrupt == false)
            {
                this.treasurys += cmd;
                Console.WriteLine($"The Europian Union gived {cmd} Ft to your city.");
            }
            else
            {
                Console.WriteLine("The mayor is corrupt so the city did not get anything!");
            }
        }

        public virtual void Corruptcy()
        {
            Console.Write("How much money do you want to steal from your city?: ");
            int cmd = Convert.ToInt32((Console.ReadLine()));
            if(cmd > this.treasurys)
            {
                Console.WriteLine("Sorry, but your City is not wealthy enough... (Khm I do not know why)");
            }
            else
            {
                this.treasurys -= cmd;
                this.iscorrupt = true;
                Console.WriteLine("Congrats you are successfuly stealed from your city!!");
            }
        }
    }
}
