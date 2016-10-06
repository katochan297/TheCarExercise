using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCar.Data;
using TheCar.Data.Enum;

namespace TheCar.Core.Provider
{
    public class TaxRateProvider : ITaxRateProvide
    {
        private static Dictionary<Region, List<TaxRate>> _dicTaxRate;

        public TaxRateProvider()
        {
            _dicTaxRate = new Dictionary<Region, List<TaxRate>>()
            {
                {
                    Region.Europe, new List<TaxRate>
                    {
                        new TaxRate2L {Rate = 100},
                        new TaxRate2LTo5L {Rate = 120},
                        new TaxRate5L {Rate = 200}
                    }
                },
                {
                    Region.USA, new List<TaxRate>
                    {
                        new TaxRate2L {Rate = 75},
                        new TaxRate2LTo5L {Rate = 90},
                        new TaxRate5L {Rate = 150}
                    }
                },
                {
                    Region.Japan, new List<TaxRate>
                    {
                        new TaxRate2L {Rate = 70},
                        new TaxRate2LTo5L {Rate = 80},
                        new TaxRate5L {Rate = 135}
                    }
                },
                {
                    Region.Other, new List<TaxRate>
                    {
                        new TaxRateOther {Rate = 0}
                    }
                }
            };

        }

        private float GetTaxRate(Car car)
        {
            if (_dicTaxRate.ContainsKey(car.OriginalRegion))
            {
                TaxRate taxRate =
                    _dicTaxRate[car.OriginalRegion].FirstOrDefault(i => car.Liter >= i.Min && car.Liter <= i.Max);
                
                try
                {
                    return taxRate.GetRate();
                }
                catch (NullReferenceException)
                { 
                    //write log
                    throw;
                }
                               
            }

            return 0;
        }

        public float CaculateImportTax(Car car)
        {
            return car.OriginalPrice * GetTaxRate(car);
        }

    }
}
