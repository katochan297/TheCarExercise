using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCar.Data.Enum
{
    public enum Region
    {
        Europe = 1,
        USA = 2,
        Japan = 3,
        Other = 4
    }

    public class CountryVAT
    {
        public static readonly float Philippines = (float)12 / 100;
    }

    public class ExchangeRate
    {
        public static readonly float PesosRate = 47f;
    }

}
