using System.Collections.Generic;
using System.Data;
using Dapper.FastCrud;
using ProductSalesList.Models.BusinessLogics;

namespace ProductSalesList.Models.Repositories
{
    public class Repository : IRepository
    {
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

        private readonly IDbConnection _dbConnection;

        public Repository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<ProductName> GetProductNames()
        {
            return _dbConnection.Find<ProductName>();
        }

        public IEnumerable<SalesLineTotal> GetSalesLineTotal()
        {
            return _dbConnection.Find<SalesLineTotal>();
        }
    }
}
