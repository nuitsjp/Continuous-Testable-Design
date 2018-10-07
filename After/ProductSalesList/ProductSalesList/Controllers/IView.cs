using System.Collections.Generic;
using ProductSalesList.Models;

namespace ProductSalesList.Controllers
{
    public interface IView
    {
        void Display(IEnumerable<ProductSales> productSales);
    }
}