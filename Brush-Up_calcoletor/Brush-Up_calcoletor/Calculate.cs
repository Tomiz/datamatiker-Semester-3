using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brush_Up_calcoletor
{
    public class Calculate
    {
        #region Properties
        /// <summary>
        /// Vi har en x og y værdi, som når man kører en metode som giver et svar, enter addition, subtraction, multiplaction, division
        /// </summary>
        public double x { get; set; }
        public double y { get; set; }
        public double Answer { get; set; } 
        #endregion

        #region Contructors
        /// <summary>
        /// Default contructor
        /// </summary>
        public Calculate()
        {

        }

        /// <summary>
        /// Contructor der tager imod vores x og y værdi, som er en double (komme tal)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Calculate(double x, double y)
        {
            this.x = x;
            this.y = y;
        } 
        #endregion

        #region Metoder
        /// <summary>
        /// En metode der laver addition
        /// </summary>
        /// <returns></returns>
        public void Addition()
        {
            double returnValue = x + y;

            Answer = returnValue;
        }

        /// <summary>
        /// En metode der laver subtraction
        /// </summary>
        public void Subtraction()
        {
            double returnValue = x - y;

            Answer = returnValue;
        }

        /// <summary>
        /// En metode der laver multiplication
        /// </summary>
        public void Multiplaction()
        {
            double returnValue = x * y;

            Answer = returnValue;
        }

        /// <summary>
        /// En metode der laver division
        /// </summary>
        public void Division()
        {
            double returnValue = x / y;

            Answer = returnValue;
        } 
        #endregion
    }
}
