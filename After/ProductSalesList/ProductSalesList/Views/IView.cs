using System.Collections.Generic;
using ProductSalesList.Models;

namespace ProductSalesList.Views
{
    public interface IView
    {
        void Display(IEnumerable<ProductSales> productSales);
    }
}