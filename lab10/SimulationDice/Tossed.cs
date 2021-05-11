using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationDice
{

    public class Tossed
    {
        public Random rnd = new Random();

        double number;
        public int Throw()
        {
            number = rnd.NextDouble();
            int k = 0;

            while (number > 0)
            {
                number -= 0.16666666;
                k += 1;
            }
            return k;
        }
    }

    public class CheatTossed
    {
        double number;
        public Random rnd = new Random();
        public int Throw()
        {
            number = rnd.NextDouble();
            int k = 0;

            while (number > 0)
            {
                if (k < 4)
                    number -= 0.1;

                else
                    number -= 0.3;

                k += 1;
            }
            return k;
        }
    }

}
