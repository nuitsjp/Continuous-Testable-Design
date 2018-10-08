using System.Collections.Generic;

namespace ProductSalesList.Models.BusinessLogics
{
    public interface IRepository
    {
        IEnumerable<ProductName> GetProductNames();

        IEnumerable<SalesLineTotal> GetSalesLineTotal();
    }
}