using System.Collections.Generic;

namespace ProductSalesList.Models.BusinessLogics
{
    public interface IBusinessLogic
    {
        IEnumerable<ProductSales> GetProductSalesList();
    }
}