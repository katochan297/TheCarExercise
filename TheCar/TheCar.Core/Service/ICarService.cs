using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCar.Data;

namespace TheCar.Core.Service
{
    public interface ICarService
    {
        decimal CaculateEndUserPriceUSD(Car car);

        decimal CaculateEndUserPricePesos(Car car);
    }
}
