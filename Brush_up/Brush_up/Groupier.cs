using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brush_up
{
    public class Groupier
    {
        /// <summary>
        /// Skal have skrevet metoder
        /// </summary>
        /// 
        #region Properties / fields
        private int _rouleteNumber;
        private Roulete _roulete;

        Dictionary<Gambler, int> _betOnEven = new Dictionary<Gambler, int>();
        Dictionary<Gambler, int> _betOnOdd = new Dictionary<Gambler, int>(); 
        #endregion

        #region Contructor
        public Groupier(Roulete roulete)
        {
            this._roulete = new Roulete();
        } 
        #endregion

        #region Method
        /// <summary>
        /// Initalising how much the gambler bets on Even
        /// </summary>
        /// <param name="gambler"></param>
        /// <param name="amount"></param>
        public void BetEven(Gambler gambler, int amount)
        {
            _betOnEven.Add(gambler, amount);
        }

        /// <summary>
        /// Initalising how much the gambler bets on Odd
        /// </summary>
        /// <param name="gambler"></param>
        /// <param name="amount"></param>
        public void BetOdd(Gambler gambler, int amount)
        {
            _betOnOdd.Add(gambler, amount);
        }

        /// <summary>
        /// Gets the roulete numbers
        /// </summary>
        /// <returns></returns>
        public int GetRouleteNumber()
        {
            return _rouleteNumber;
        }

        /// <summary>
        /// Gets the random spin number
        /// </summary>
        public void SpinRoulete()
        {
            _rouleteNumber = _roulete.Spin();
        }

        /// <summary>
        /// Equalizes if the gambler wins on either Even or Odd
        /// </summary>
        public void Equalize()
        {
            //If the number is even the gambler wins
            if (_rouleteNumber % 2 == 0 && _rouleteNumber != 0)
            {
                foreach (var winner in _betOnEven)
                {
                    winner.Key.ReciveCash(winner.Value * 2);
                }
            }
            //If the number is Odd the gambler wins
            if (_rouleteNumber % 2 == 1 && _rouleteNumber != 0)
            {
                foreach (var winner in _betOnOdd)
                {
                    winner.Key.ReciveCash(winner.Value * 2);
                }
            }

            //Clears the latest bet, so the game can continue
            _betOnOdd.Clear();
            _betOnEven.Clear();
        } 
        #endregion



    }
}
