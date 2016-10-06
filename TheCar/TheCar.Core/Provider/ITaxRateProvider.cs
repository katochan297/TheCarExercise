using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCar.Data;

namespace TheCar.Core.Provider
{
    public interface ITaxRateProvide
    {
        float CaculateImportTax(Car car);

    }
}
