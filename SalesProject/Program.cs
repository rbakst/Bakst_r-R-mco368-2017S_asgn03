using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Sale[] sales = new Sale[9]{
                (new Sale("tea", "Allc", 1.00, 5, "address", false)),
                (new Sale("Coffee", "bLLC", 10.00, 87,"address100+", true)),
                (new Sale("3", "c", 100.00, 34, "address100+",true)),
                (new Sale("Coffee", "d", 12.00, 1, "address", false)),
                (new Sale("tea", "e", 5.00, 6, "address", true)),
                (new Sale("tea", "fllc", 17.00, 5, "address", false)),
                (new Sale("7", "g", 300.00, 1, "address100+", true)),
                (new Sale("Coffee", "LLC", 8.00, 4, "address", false)),
                (new Sale("9", "i", 7.00, 23, "address100+", true))};


            double totalProf = TotalProfit(sales, s => s.Item == "Coffee", s => s.PricePerItem * s.Quantity * .8,
                (s, p) => Console.WriteLine("Coffee Item for {0} \t Total Profit: {1:C}", s.Customer, p),
                s => Console.WriteLine("Non-Coffee Item--skippping"));
            Console.WriteLine("\nTotal Profit: {0:C}", totalProf);
            Console.WriteLine();

            totalProf = TotalProfit(sales, s => s.Quantity > 1, s => s.PricePerItem * s.Quantity + (s.ExpeditedShipping ? 20 : 0), (s, p) => printShippingStatus(s, p),
                s => System.IO.File.WriteAllText(@"C:\Users\Rachel\OneDrive\Touro\Spring 2017\C#\Orders.txt", "Single Order Item " + s.Item));
            Console.WriteLine("Total Profit {0:C}", totalProf);

            Console.ReadKey();
        }

        public static double TotalProfit(Sale[] sales, Func<Sale, bool> DetermineInclude, Func<Sale, double> TotalSale, Action<Sale, double> actOnASale, Action<Sale> ActOnANonSale)
        {
            double total = 0;
            double totalSale;
            foreach (Sale s in sales)
            {
                if (DetermineInclude.Invoke(s))
                {

                    totalSale = TotalSale.Invoke(s);
                    actOnASale(s, totalSale);
                    total += totalSale;
                }
                else
                {
                    ActOnANonSale(s);
                }
            }
            return total;
        }

        public static void printShippingStatus(Sale s, Double p)
        {
            if (s.ExpeditedShipping)
            {
                Console.WriteLine("Expedited Shipping sale of {0} - extra $20 profit. Profit: {1:C}", s.Item, p);
            }

        }
    }
}
