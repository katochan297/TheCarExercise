using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCar.Core.Provider
{
    internal abstract class TaxRate
    {
        internal float Min;
        internal float Max;
        internal float Rate;
        internal float GetRate()
        {
            return Rate / 100;
        }
    }
    
    internal class TaxRate2L : TaxRate
    {
        internal TaxRate2L()
        {
            Min = 0;
            Max = 2.0f;
        }
    }

    internal class TaxRate2LTo5L : TaxRate
    {
        internal TaxRate2LTo5L()
        {
            Min = 2.1f;
            Max = 5.0f;
        }
    }

    internal class TaxRate5L : TaxRate
    {
        internal TaxRate5L()
        {
            Min = 5.1f;
            Max = 1000.0f;
        }
    }

    internal class TaxRateOther : TaxRate
    {
        internal TaxRateOther()
        {
            Min = 0;
            Max = 1000.0f;
        }
    }



}
