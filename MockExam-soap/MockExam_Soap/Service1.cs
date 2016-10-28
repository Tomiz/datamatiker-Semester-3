using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MockExam_Soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        /// <summary>
        /// metode der konvertere til fehrenheit fra celcius
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public double Celcius(double c)
        {
            double f = 1.8 * c + 32;

            return f;
        }

        /// <summary>
        /// metode der konvertere til celcius fra fehrenheit
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public double Fehrenheit(double f)
        {
            double c = (f - 32) / 1.8;

            return c;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            return composite;
        }
    }
}
