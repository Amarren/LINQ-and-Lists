using System;
using System.Linq;

namespace LINQ_and_Lists
{
    class Program
    {
        static void Main()
        {
            var invoices = new[]
            {
                new Invoice(83, "Electric sander", 7, 57.98M),
                new Invoice(24, "Power saw", 18, 99.99m),
                new Invoice(7, "Sledge hammer", 11, 21.50M),
                new Invoice(77, "Hammer", 76, 11.99M),
                new Invoice(39, "Lawn mower", 3, 79.50M),
                new Invoice(68, "Screwdrver", 106, 6.99M),
                new Invoice(56, "Jig saw", 21, 11.00M),
                new Invoice(3, "Wrench", 34, 7.50M)
            };

            //displays invoices sorted by part discription alphabetically
            var partDiscriptionSorted =
                from e in invoices
                orderby e.PartDescription
                select e;

            Console.WriteLine("Sorted by Part Discription");

            foreach (var element in partDiscriptionSorted)
            {
                Console.WriteLine(element);
            }

            //displays invoices sorted by price
            var priceSorted =
                from e in invoices
                orderby e.Price
                select e;

            Console.WriteLine("\nSorted by Price");

            foreach (var element in priceSorted)
            {
                Console.WriteLine($"{element}");
            }

            //displays invoices sorted by quantity
            var quantitySorted =
                from e in invoices
                orderby e.Quantity
                select new { e.PartDescription, e.Quantity };

            Console.WriteLine("\nSorted by Quantity");

            foreach (var element in quantitySorted)
            {
                Console.WriteLine($"{element}");
            }

            //display InvoiceTotal
            var invoiceTotal =
                from e in invoices
                let InvoiceTotal = e.Quantity * e.Price
                orderby InvoiceTotal
                select new { e.PartDescription, InvoiceTotal };

            Console.WriteLine("\nSorted by Invoice Total");

            foreach (var element in invoiceTotal)
            {
                Console.WriteLine($"{element}");
            }

            //display InvoiceTotals between 200 and 500
            var between200to500 = 
                from e in invoiceTotal
                where (e.InvoiceTotal >= 200M) && (e.InvoiceTotal <= 500M)
                orderby e.InvoiceTotal
                select new { e.PartDescription, e.InvoiceTotal };

            Console.WriteLine("\nInvoice Total between $200 - $500");

            foreach (var element in between200to500)
            {
                Console.WriteLine($"{element}");
            }
        }
    }
}
