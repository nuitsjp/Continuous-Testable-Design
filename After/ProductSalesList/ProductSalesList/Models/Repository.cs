using System.Collections.Generic;
using System.Linq;
using AdventureWorksLT.Service.Api;

namespace ProductSalesList.Models
{
    public class Repository : IRepository
    {
        private readonly IProductsApi _productsApi;
        private readonly ISalesOrderDetailsApi _salesOrderDetailsApi;

        public Repository(IProductsApi productsApi, ISalesOrderDetailsApi salesOrderDetailsApi)
        {
            _productsApi = productsApi;
            _salesOrderDetailsApi = salesOrderDetailsApi;
        }

        public IList<ProductName> GetProductNames()
        {
            return _productsApi.ProductsGet()
                .Select(x => new ProductName{ProductId = x.ProductId, Name = x.Name})
                .ToList();
        }

        public IList<Sales> GetSales()
        {
            return _salesOrderDetailsApi.SalesOrderDetailsGet()
                .Select(x => new Sales {ProductId = x.ProductId, LineTotal = x.LineTotal})
                .ToList();
        }
    }
}
