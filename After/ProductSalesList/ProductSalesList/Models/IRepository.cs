using System.Collections.Generic;

namespace ProductSalesList.Models
{
    public interface IRepository
    {
        IList<ProductName> GetProductNames();

        IList<Sales> GetSales();
    }
}