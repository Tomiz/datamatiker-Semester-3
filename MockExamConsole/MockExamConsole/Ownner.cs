using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExamConsole
{
    public class Ownner
    {
        #region Fields / properties
        private string _adress;
        private string _name;
        private string _phone;
        #endregion

        #region Get & Sets

        /// <summary>
        /// Her sætter vi set metoden.
        /// Hvis længden er mindre end 6 giver den en ArgumentOutOfRangeException
        /// </summary>
        public string Adress
        {
            get { return _adress; }
            set
            {
                if (value.Length > 6)
                    _adress = value;
                else throw new ArgumentOutOfRangeException($"Adresse skal være på 6 eller flere tegn");

            }
        }

        /// <summary>
        /// Her sætter vi set metoden.
        /// Hvis længden er mindre end 4 giver den en ArgumentOutOfRangeException
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > 4)
                    _name = value;
                else throw new ArgumentOutOfRangeException($"Navn skal være på 4 eller flere tegn");

            }
        }

        /// <summary>
        /// her sætter vi set metode.
        /// Hvis længden er forskellig fra 8 skal den give en ArgumentOutOfRangeException
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value.Length == 8)
                    _phone = value;
                else throw new ArgumentOutOfRangeException($"Telefon nummeret skal være på 8 tegn");



            }
        }
        #endregion

        #region Contructor
        /// <summary>
        /// Her sætter vi vores contructor
        /// </summary>
        /// <param name="adress"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        public Ownner(string adress, string name, string phone)
        {
            Adress = adress;
            Name = name;
            Phone = phone;
        }
        #endregion
    }
}
