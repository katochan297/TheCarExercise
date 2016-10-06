using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCar.Data.Enum;

namespace TheCar.Data
{
    public class Car
    {
        public string CarName { get; set; }
        public float Liter { get; set; }
        public float OriginalPrice { get; set; }
        public Region OriginalRegion { get; set; }
    }
}
