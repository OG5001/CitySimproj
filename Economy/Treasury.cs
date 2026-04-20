using System;
using System.Collections.Generic;
using System.Text;

namespace CitySimproj
{
    internal class Treasury
    {
        private int balance;
        private bool iscorrupt;


        public int Treasurys { get => balance; set => balance = value; }
        public bool Iscorrupt { get => iscorrupt; set => iscorrupt = value; }

        public virtual void EUMoney()
        {
            Console.Write("How much money do you need?: ");
            int cmd = Convert.ToInt32(Console.ReadLine());
            if (this.iscorrupt == false)
            {
                this.balance += cmd;
                Console.WriteLine($"The Europian Union gave {cmd} Ft to your city.");
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
            if(cmd > this.balance)
            {
                Console.WriteLine("Sorry, but your City is not wealthy enough... (Khm I do not know why)");
            }
            else
            {
                this.balance -= cmd;
                this.iscorrupt = true;
                Console.WriteLine("Congrats you have successfuly stolen from your city!!");
            }
        }

        public void Balance()
        {
            Console.WriteLine($"Balance: {balance}");
        }

        public void AddMoney(int amount)
        {
            balance += amount;
        }
    }
}
