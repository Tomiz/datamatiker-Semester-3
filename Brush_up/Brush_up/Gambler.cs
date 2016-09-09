using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brush_up
{
    public class Gambler
    {
        private int Cash { get; set; }

        public Gambler(int cashAmount)
        {
            Cash = cashAmount;
        }

        public void BetCash(int amountLost, Groupier croupier)
        {
            if (Cash >= amountLost)
            {
                Cash -= amountLost;
                croupier.BetEven(this, amountLost);
            }
            else
            {
                //throw excpetion OutOfCash
            }
            
        }

        public void ReciveCash(int amountRecived)
        {
            Cash += amountRecived;
        }

    }
}
