using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Brush_up
{
    public class Roulete
    {
        private readonly Random _random;

        public Roulete()
        {
            _random = new Random();
        }
        public int Spin()
        {
            return _random.Next(0, 36);
        }

    }
}
