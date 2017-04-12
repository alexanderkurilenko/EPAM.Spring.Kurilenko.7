using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Logic
{
    public class Customer:IFormattable
    {
        #region Properties
        public string Name { get; private set;}
        public string ContactPhone { get; private set; }
        public decimal Revenue { get; private set; }
        #endregion

        #region Ctors
        public Customer()
        {
            Name = "Alex";
            ContactPhone = "+000000000";
            Revenue = 0;
        }
        public Customer(string name, string contactPhone)
            : this()
        {
            Name = name;
            ContactPhone = contactPhone;
        }
        public Customer(string name, string contactPhone, decimal revenue):this()
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }
        #endregion

        #region Methods
        public string ToString(string format, IFormatProvider formatProvider=null)
        {
            if (String.IsNullOrEmpty(format))
                format = "F";

            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "F":
                    return string.Format("Customer record: {0}, {1}, {2}", Name, ContactPhone, Revenue);
                case "N":
                    return string.Format("Customer record: {0}", Name);
                case "NP":
                    return string.Format("Customer record: {0}, {1}", Name, ContactPhone);
                case "NPR":
                    return string.Format("Customer record: {0}, {1}, {2}", Name, ContactPhone, Revenue);
                case "P":
                    return string.Format("Customer record: {0}", ContactPhone);
                case "R":
                    return string.Format("Customer record: {0}", Revenue);
            }

            throw new FormatException("Unsupported format: " + format);
        }
        #endregion
    }
}
