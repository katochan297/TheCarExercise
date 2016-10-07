﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCar.Enum;
using TheCar.Provider;

namespace TheCar.Service
{
    public class CarService
    {
        private readonly TaxRateProvider _taxProvider;

        public CarService()
        {
            _taxProvider = new TaxRateProvider();
        }

        private float CaculateImportTaxPrice(Car car)
        {
            return _taxProvider.CaculateImportTax(car);
        }


        public float CaculateEndUserPrice_USD(Car car)
        {
            //end_user_price = Original Price + Import Tax Price + VAT (VAT = (Original Price + Import Tax Price) * 12% )
            return (car.OriginalPrice + CaculateImportTaxPrice(car)) * (1 + CountryVAT.Philippines);
        }

        public float CaculateEndUserPrice_Pesos(Car car)
        {
            return CaculateEndUserPrice_USD(car) * ExchangeRate.PesosRate;
        }


    }
}