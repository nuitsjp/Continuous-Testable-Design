using System.Collections.Generic;
using ProductSalesList.Models;
using ProductSalesList.Models.BusinessLogics;

namespace ProductSalesList.Controllers
{
    public interface IView
    {
        void Display(IEnumerable<ProductSales> productSales);
    }
}