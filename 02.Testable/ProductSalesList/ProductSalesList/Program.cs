using System;
using System.Configuration;
using System.Data.Common;
using ProductSalesList.Controllers;
using ProductSalesList.Models.BusinessLogics;
using ProductSalesList.Models.Repositories;
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
                        new Repository()),
                    new View());
            controller.Execute("output.csv");

            Console.WriteLine("Completed. Please pless any key.");
            Console.ReadKey();
        }
    }
}
