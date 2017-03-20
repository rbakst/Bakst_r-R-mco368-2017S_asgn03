using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject
{
    public class Sale
    {
        public String Item { get; set; }
        public String Customer { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }
        public String Address { get; set; }
        public bool ExpeditedShipping { get; set; }

        public Sale(String item, string customer, double price, int quant, string addr, bool expedited)
        {
            Item = item;
            Customer = customer;
            PricePerItem = price;
            Quantity = quant;
            Address = addr;
            ExpeditedShipping = expedited;
        }
    }
}
