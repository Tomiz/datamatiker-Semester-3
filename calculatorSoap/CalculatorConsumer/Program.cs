using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorConsumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.CalculatorServiceClient calc = new ServiceReference1.CalculatorServiceClient();
            Console.WriteLine(calc.Add(3, 3));
            Console.ReadKey();

        }
    }
}
