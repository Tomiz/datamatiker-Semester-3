using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapTest.ServiceReferenceTemperatur;

namespace SoapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter celcius degress");
            double celcius = Convert.ToDouble(Console.ReadLine());
            
            ServiceReferenceTemperatur.ConvertTemperatureSoapClient converter = new ServiceReferenceTemperatur.ConvertTemperatureSoapClient("ConvertTemperatureSoap");

            double fahrenheit = converter.ConvertTemp(celcius, ServiceReferenceTemperatur.TemperatureUnit.degreeCelsius, ServiceReferenceTemperatur.TemperatureUnit.degreeFahrenheit);

            //double fehrenheit = 4;

            Console.WriteLine("det svarer til: " + fahrenheit + " fehrenheit");
            Console.ReadKey();
        }
    }
}
