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
            // ここでDBコネクションを作成してしまっているが、実際のプロダクションコードでは
            // お勧めできない。AOPを利用して、BusinessLogic層の上で統一的にトランザクション管理
            // するのが、個人的には良いと考えている。
            var settings = ConfigurationManager.ConnectionStrings["AdventureWorks2017"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = settings.ConnectionString;
                connection.Open();

                var controller =
                    new Controller(
                        new BusinessLogic(
                            new Repository(connection)),
                        new View("output.csv"));
                controller.Execute();
            }



            Console.WriteLine("Completed. Please pless any key.");
            Console.ReadKey();
        }
    }
}
