using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using TheCar.Core.Helper;
using TheCar.Core.Provider;
using TheCar.Core.Service;
using TheCar.Data;
using TheCar.Data.Enum;

namespace TheCar
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            container.RegisterType<ITaxRateProvide, TaxRateProvider>();
            container.RegisterType<CarService, CarService>();

            //Example
            var car = new Car
            {
                CarName = "Benz G65",
                Liter = 6.0f,
                OriginalPrice = 217900f,
                OriginalRegion = Region.Europe
            };
            var svc = container.Resolve<CarService>();
            var priceUSD = Utilities.FormatWithCurrency(svc.CaculateEndUserPriceUSD(car).ToString());
            var pricePHP = Utilities.FormatWithCurrency(svc.CaculateEndUserPricePesos(car).ToString());
            Console.WriteLine("USD: " + priceUSD + "\nPesos: " + pricePHP);

            Console.ReadLine();
        }
    }
}
