using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public static class CustomerExtensions
    {
        public static string Print(this Customer customer, string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format))
                format = "F+";

            if (provider == null)
                provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "F+":
                    return string.Format("Customer record with adds. Name:{0}, Contact phone:{1}, Revenue:{2}", customer.Name, customer.ContactPhone, customer.Revenue);
            }

            throw new FormatException();
        }
    }
}
