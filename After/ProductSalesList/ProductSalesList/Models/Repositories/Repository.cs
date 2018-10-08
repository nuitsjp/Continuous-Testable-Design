using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using AdventureWorksLT.Service.Api;
using AdventureWorksLT.Service.Model;
using Dapper.FastCrud;
using ProductSalesList.Models.BusinessLogics;

namespace ProductSalesList.Models.Repositories
{
    public class Repository : IRepository
    {
        private readonly IProductsApi _productsApi;
        private readonly ISalesOrderDetailsApi _salesOrderDetailsApi;

        static Repository()
        {
            OrmConfiguration
                .RegisterEntity<ProductName>()
                .SetSchemaName("Production")
                .SetTableName("Product")
                .SetProperty(x => x.ProductId)
                .SetProperty(x => x.Name);
            OrmConfiguration
                .RegisterEntity<SalesLineTotal>()
                .SetSchemaName("Sales")
                .SetTableName("SalesOrderDetail")
                .SetProperty(x => x.ProductId)
                .SetProperty(x => x.LineTotal);
        }

        public Repository(IProductsApi productsApi, ISalesOrderDetailsApi salesOrderDetailsApi)
        {
            _productsApi = productsApi;
            _salesOrderDetailsApi = salesOrderDetailsApi;
        }

        public IEnumerable<ProductName> GetProductNames()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Find<ProductName>();
            }
        }

        public IEnumerable<SalesLineTotal> GetSalesLineTotal()
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Find<SalesLineTotal>();
            }
        }

        private static IDbConnection CreateConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings["AdventureWorks2017"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = settings.ConnectionString;
            return connection;
        }
    }
}
