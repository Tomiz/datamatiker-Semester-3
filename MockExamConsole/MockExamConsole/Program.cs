using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExamConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car(Car.CarColor.Black, 5, "mazda", "1111111" );

            Console.WriteLine(c1);
        }
    }
}
