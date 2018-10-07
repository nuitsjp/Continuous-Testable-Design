using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductSalesList.Controllers;

namespace ProductSalesList
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
            controller.Write("output.csv");

            Console.WriteLine("Completed. Please pless any key.");
            Console.ReadKey();
        }
    }
}
