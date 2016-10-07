using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCar.Service
{
    internal class TaxRate
    {
        internal float Min;
        internal float Max;
        internal float Rate;
        internal float GetRate()
        {
            return Rate / 100;
        }
    }
}
