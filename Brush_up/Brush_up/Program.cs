using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brush_up
{
    class Program
    {
        private static int _numberOfTests = 1000;

        private static int _playerWins = 0;
        private static int _playerLoose = 0;

        static void Main(string[] args)
        {

            Console.WriteLine("The Martingale theory number of atempts: " + _numberOfTests);
            for (int i = 0; i < _numberOfTests; i++)
            {
                SimulateMartingale(1, 15000);
            }
            Console.WriteLine();
            Console.WriteLine("Wins: " + _playerWins);
            Console.WriteLine("Lose: " + _playerLoose);
        }

        private static void SimulateMartingale(int amount, int winningCondition)
        {
            Gambler gambler = new Gambler(30000);
            Groupier croupier = new Groupier(new Roulete());


        }
    }
}
