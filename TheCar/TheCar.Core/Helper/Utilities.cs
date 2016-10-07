using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheCar.Core.Helper
{
    public class Utilities
    {
        public static string FormatWithCurrency(string amount)
        {
            try
            {
                double d;
                double.TryParse(amount, out d);
                var money = string.Format(new CultureInfo("en-US"), "{0:#,##0.00}", d);
                return money;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
