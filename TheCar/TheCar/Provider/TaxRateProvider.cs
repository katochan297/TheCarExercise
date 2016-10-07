using System;
using System.Collections.Generic;
using System.Linq;
using TheCar.Enum;

namespace TheCar.Provider
{
    internal class TaxRateProvider
    {
        private static Dictionary<Region, List<TaxRate>> _dicTaxRate;

        internal TaxRateProvider()
        {
            _dicTaxRate = new Dictionary<Region, List<TaxRate>>()
            {
                {
                    Region.Europe, new List<TaxRate>
                    {
                        new TaxRate {Min = -1, Max = 2.0f, Rate = 100},
                        new TaxRate {Min = 2.0f, Max = 5.0f, Rate = 120},
                        new TaxRate {Min = 5.0f, Max = 1000.0f, Rate = 200}
                    }
                },
                {
                    Region.USA, new List<TaxRate>
                    {
                        new TaxRate {Min = -1, Max = 2.0f, Rate = 75},
                        new TaxRate {Min = 2.0f, Max = 5.0f, Rate = 90},
                        new TaxRate {Min = 5.0f, Max = 1000.0f, Rate = 150}
                    }
                },
                {
                    Region.Japan, new List<TaxRate>
                    {
                        new TaxRate {Min = -1, Max = 2.0f, Rate = 70},
                        new TaxRate {Min = 2.0f, Max = 5.0f, Rate = 80},
                        new TaxRate {Min = 5.0f, Max = 1000.0f, Rate = 135}
                    }
                },
                {
                    Region.Other, new List<TaxRate>
                    {
                        new TaxRate {Min = -1, Max = 1000.0f, Rate = 0}
                    }
                }
            };

        }

        private float GetTaxRate(Car car)
        {
            if (_dicTaxRate.ContainsKey(car.OriginalRegion))
            {
                TaxRate taxRate =
                    _dicTaxRate[car.OriginalRegion].FirstOrDefault(i => car.Liter > i.Min && car.Liter <= i.Max && car.Liter >= 0);

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
