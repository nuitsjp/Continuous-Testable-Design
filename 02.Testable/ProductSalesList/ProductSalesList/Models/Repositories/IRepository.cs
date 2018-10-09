using System.Collections.Generic;
using System.Data;

namespace ProductSalesList.Models.Repositories
{
    public interface IRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<SalesOrderDetail> GetSalesOrderDetail();
    }
}