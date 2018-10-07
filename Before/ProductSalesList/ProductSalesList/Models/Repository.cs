using System.Collections.Generic;
using AdventureWorksLT.Service.Api;
using AdventureWorksLT.Service.Model;

namespace ProductSalesList.Models
{
    public class Repository
    {
        private const string BasePath = "http://adventureworkslt.azurewebsites.net";
        private readonly IProductsApi _productsApi;
        private readonly ISalesOrderDetailsApi _salesOrderDetailsApi;

        public Repository()
        {
            _productsApi = new ProductsApi(BasePath);
            _salesOrderDetailsApi = new SalesOrderDetailsApi(BasePath);
        }

        public IList<Product> GetProducts()
        {
            return _productsApi.ProductsGet();
        }

        public IList<SalesOrderDetail> GetSalesOrderDetails()
        {
            return _salesOrderDetailsApi.SalesOrderDetailsGet();
        }
    }
}
