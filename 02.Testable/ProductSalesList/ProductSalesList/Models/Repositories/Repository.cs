using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Dapper.FastCrud;
using ProductSalesList.Models.BusinessLogics;

namespace ProductSalesList.Models.Repositories
{
    public class Repository : IRepository
    {
        #region static initializer
        //static Repository()
        //{
        //    OrmConfiguration
        //        .RegisterEntity<ProductName>()
        //        .SetSchemaName("Production")
        //        .SetTableName("Product")
        //        .SetProperty(x => x.ProductId)
        //        .SetProperty(x => x.Name);
        //    OrmConfiguration
        //        .RegisterEntity<SalesLineTotal>()
        //        .SetSchemaName("Sales")
        //        .SetTableName("SalesOrderDetail")
        //        .SetProperty(x => x.ProductId)
        //        .SetProperty(x => x.LineTotal);
        //}
        #endregion

        public IEnumerable<Product> GetProducts()
        {
            using (var connection = CreateConnection())
            {
                return connection.Find<Product>();
            }
        }

        public IEnumerable<SalesOrderDetail> GetSalesOrderDetail()
        {
            using (var connection = CreateConnection())
            {
                return connection.Find<SalesOrderDetail>();
            }
        }

        private static IDbConnection CreateConnection()
        {
            var settings = ConfigurationManager.ConnectionStrings["AdventureWorks2017"];
            var factory = DbProviderFactories.GetFactory(settings.ProviderName);
            var connection = factory.CreateConnection();
            try
            {
                connection.ConnectionString = settings.ConnectionString;
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
        }
    }
}
