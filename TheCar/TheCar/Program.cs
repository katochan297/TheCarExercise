using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCar.Core.Helper;
using TheCar.Core.Service;
using TheCar.Data;
using TheCar.Data.Enum;

namespace TheCar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example
            var car = new Car
            {
                CarName = "Benz G65",
                Liter = 6.0f,
                OriginalPrice = 217900f,
                OriginalRegion = Region.Europe
            };
            var svc = new CarService();
            var priceUSD = Utilities.FormatWithCurrency(svc.CaculateEndUserPrice_USD(car).ToString());
            var pricePHP = Utilities.FormatWithCurrency(svc.CaculateEndUserPrice_Pesos(car).ToString());
            Console.WriteLine("USD: " + priceUSD + "\nPesos: " + pricePHP);

            Console.ReadLine();
        }
    }
}
