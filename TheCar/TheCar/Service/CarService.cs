using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCar.Enum;

namespace TheCar.Service
{

    internal class LiterCategory
    {
        internal float Min;
        internal float Max;
        internal LiterType Type;

        internal LiterType GetLiterType()
        {
            return Type;
        }

        internal bool IsLiterRight(Car car)
        {
            return car.Liter > Min && car.Liter <= Max && car.Liter >= 0;
        }
    }


    public class CarService
    {
        private readonly float[,] _taxRateTable =
        {
            {0, 0, 0},
            {1.0f, 1.2f, 2.0f},
            {0.75f, 0.9f, 1.5f},
            {0.7f, 0.8f, 1.35f}
        };
        
        private readonly List<LiterCategory> _listLiterType;

        public CarService()
        {
            _listLiterType = new List<LiterCategory>
            {
                new LiterCategory {Min = -1, Max = 2.0f, Type = LiterType.Low},
                new LiterCategory {Min = 2.0f, Max = 5.0f, Type = LiterType.Medium},
                new LiterCategory {Min = 5.0f, Max = 1000.0f, Type = LiterType.High}
            };
        }

        private float GetTaxRate(Car car)
        {
            var firstOrDefault = _listLiterType.FirstOrDefault(x => x.IsLiterRight(car));
            if (firstOrDefault != null)
            {
                var carLiterType =  firstOrDefault.GetLiterType();
                var rate = 0f;
                try
                {
                    rate = _taxRateTable[(int)car.OriginalRegion, (int)carLiterType];
                }
                catch (IndexOutOfRangeException)
                {
                    //write log
                    throw;
                }
                return rate;
            }
            
            return 0;
        }

        private float CaculateImportTaxPrice(Car car)
        {
            return car.OriginalPrice * GetTaxRate(car);
        }



        public float CaculateEndUserPrice_USD(Car car)
        {
            //end_user_price = Original Price + Import Tax Price + VAT 
            //(VAT = (Original Price + Import Tax Price) * 12% )
            return (car.OriginalPrice + CaculateImportTaxPrice(car)) * (1 + CountryVAT.Philippines);
        }

        public float CaculateEndUserPrice_Pesos(Car car)
        {
            return CaculateEndUserPrice_USD(car) * ExchangeRate.PesosRate;
        }


    }
}
