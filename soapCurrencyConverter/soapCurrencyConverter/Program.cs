using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using soapCurrencyConverter.ServiceReferenceCurrency;

namespace soapCurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter dkk degress");
            Currency dkk = Console.ReadLine();
            //double celcius = Convert.ToDouble(Console.ReadLine());


            //ServiceReferenceTemperatur.ConvertTemperatureSoapClient converter = new ServiceReferenceTemperatur.ConvertTemperatureSoapClient("ConvertTemperatureSoap");
            ServiceReferenceCurrency.CurrencyConvertorSoapClient convertor = new ServiceReferenceCurrency.CurrencyConvertorSoapClient("CurrencyConvertorSoap");

            //double fahrenheit = converter.ConvertTemp(celcius, ServiceReferenceTemperatur.TemperatureUnit.degreeCelsius, ServiceReferenceTemperatur.TemperatureUnit.degreeFahrenheit);
            double usd = convertor.ConversionRate(ServiceReferenceCurrency.Currency.USD, dkk);

            //double fehrenheit = 4;

            Console.WriteLine("det svarer til: " + usd + " usd");
            Console.ReadKey();
        }
    }
}
