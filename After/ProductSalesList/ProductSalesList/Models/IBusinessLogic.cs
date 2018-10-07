using System.Collections.Generic;

namespace ProductSalesList.Models
{
    public interface IBusinessLogic
    {
        IEnumerable<ProductSales> GetProductSalesList();
    }
}