using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExamConsole
{
    public class Car
    {
        #region Fields / proprerties
        /// <summary>
        /// Her opretter vi en enum med forskellige værdier
        /// </summary>
        public enum CarColor
        {
            Black, White, Gray, Red, Green, Blue
        }

        public CarColor Color { get; set; }

        private string _model;
        private string _regrNr;
        private int _doors;

        #endregion

        #region Get & Sets
        /// <summary>
        // Her tjekker vi på set metoden.
        // hvis value er null skal den komme med en nullReferenceException
        /// </summary>
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (value != null)
                    _model = value;
                else throw new NullReferenceException($"Model må ikke være null (tom)");
                
            }
        }

        /// <summary>
        /// her sætter vi set metode.
        /// Hvis længden er forskellig fra 7 skal den komme med en argenmentOutOfRangeException
        /// </summary>
        public string RegrNr
        {
            get { return _regrNr; }
            set
            {
                if (value.Length == 7)
                    _regrNr = value;
                else throw new ArgumentOutOfRangeException($"RegrNr skal være på 7 tegn");
                
            }
        }

        /// <summary>
        /// Her sætter vi set metode
        /// Hvis længden er mindre end 2 eller større end 5 skal den give en argenmentOutOfRangeException
        /// </summary>
        public int Doors
        {
            get { return _doors; }
            set
            {
                if (value >= 2 && value <= 5)
                {
                    _doors = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"Bilen skal have mellem 2-5 døre");
                }
                
            }
        }
        #endregion

        #region Contructor
        /// <summary>
        /// Her sætter vi vores contructor
        /// </summary>
        /// <param name="color"></param>
        /// <param name="doors"></param>
        /// <param name="model"></param>
        /// <param name="regrNr"></param>
        public Car(CarColor color, int doors, string model, string regrNr)
        {
            Color = color;
            Doors = doors;
            Model = model;
            RegrNr = regrNr;
        }
        #endregion

        public override string ToString()
        {
            return $"{nameof(_model)}: {_model}, {nameof(_regrNr)}: {_regrNr}, {nameof(Color)}: {Color}, {nameof(Doors)}: {Doors}, {nameof(Model)}: {Model}, {nameof(RegrNr)}: {RegrNr}";
        }
    }
}
