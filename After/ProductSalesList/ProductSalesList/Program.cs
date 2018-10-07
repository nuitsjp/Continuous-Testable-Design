using System;
using AdventureWorksLT.Service.Api;
using ProductSalesList.Controllers;
using ProductSalesList.Models;
using ProductSalesList.Views;

namespace ProductSalesList
{
    // ReSharper disable once ArrangeTypeModifiers
    class Program
    {
        private const string BasePath = "http://adventureworkslt.azurewebsites.net";
        // ReSharper disable once UnusedParameter.Local
        // ReSharper disable once ArrangeTypeMemberModifiers
        static void Main(string[] args)
        {
            var controller =
                new Controller(
                    new BusinessLogic(
                        new Repository(
                            new ProductsApi(BasePath),
                            new SalesOrderDetailsApi(BasePath))),
                    new View("output.csv"));
            controller.Execute();


            Console.WriteLine("Completed. Please pless any key.");
            Console.ReadKey();
        }
    }
}
