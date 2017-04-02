using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesProject
{
    class Part1
    {
        public static void Main(String[] args)
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


                var list =
                from s in sales
                where s.PricePerItem > 10
                select s;

                foreach (Sale s in list)
                    Console.WriteLine(s.PricePerItem);


                var list2 =
                  sales.Where(s => s.PricePerItem > 10);

                foreach (Sale s in list2)
                    Console.WriteLine(s.PricePerItem);

            Console.WriteLine();

                list =
                     from s in sales
                     where s.Quantity == 1
                     orderby s.Quantity descending
                     select s;

                foreach (Sale s in list)
                    Console.WriteLine(s.Item);


                list2 = sales.Where(s => s.Quantity == 1).OrderByDescending(s => s.Quantity);

                foreach (Sale s in list2)
                    Console.WriteLine(s.Item);


            Console.WriteLine();

                list =
                    from s in sales
                    where s.Item == "tea" && !s.ExpeditedShipping
                    select s;

                foreach (Sale s in list)
                    Console.WriteLine(s.Item);


                list2 = sales.Where(s => s.Item == "tea" && !s.ExpeditedShipping);
        
                foreach (Sale s in list2)
                    Console.WriteLine(s.Item);

            
            Console.WriteLine();

                var stringList =
                  from s in sales
                  where s.PricePerItem * s.Quantity > 100
                  select s.Address;

                foreach (String st in stringList)
                    Console.WriteLine(st);
                    

                var stringList2 = sales.Where(s => s.PricePerItem * s.Quantity > 100).Select(s => s.Address);

                foreach (String st2 in stringList2)
                    Console.WriteLine(st2);
            

            Console.WriteLine();

                var newList =
                     from s in sales
                     where s.Customer.ToUpper().Contains("LLC")
                     orderby s.PricePerItem * s.Quantity
                     select new { Item = s.Item, TotalPrice = s.PricePerItem * s.Quantity, Shipping = s.ExpeditedShipping ? s.Address + "Expedite" : s.Address };

                foreach (var newObj in newList)
                    Console.WriteLine(newObj.Item + " " + newObj.Shipping);


                var newList2 = sales.Where(s => s.Customer.ToUpper().Contains("LLC")).OrderBy(s => s.PricePerItem * s.Quantity).Select(s => new { Item = s.Item, TotalPrice = s.PricePerItem * s.Quantity, Shipping = s.ExpeditedShipping ? s.Address + "Expedite" : s.Address });

                foreach (var newObj2 in newList2)
                    Console.WriteLine(newObj2.Item + " " + newObj2.Shipping);

            Console.ReadKey();




        }
    }
}
