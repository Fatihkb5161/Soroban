using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soraban
{
    internal class SorobanNumber
    {
        public BeadColumn[] Columns = new BeadColumn[7];

        // Constructor: her elemanı başlat
        public SorobanNumber()
        {
            for (int i = 0; i < 7; i++)
            {
                Columns[i] = new BeadColumn()
                {
                    UpperBead = 0,
                    LowerBeads = 0
                };
            }
        }
        public static SorobanNumber FromInt(int num)
        {
            SorobanNumber s = new SorobanNumber();
            for (int i = 0; i < 7; i++)
            {
                int digit = num % 10;
                s.Columns[6 - i] = new BeadColumn
                {
                    UpperBead = digit / 5,
                    LowerBeads = digit % 5,
                };
                num /= 10;
            }
            return s;
        }
    }
}
