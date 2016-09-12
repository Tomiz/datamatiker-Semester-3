using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brush_Up_calcoletor;

namespace Brush_up_part_2_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate c = new Calculate(2,3);

            c.Addition();
            

            Console.WriteLine(c);
        }
    }
}
