using ProductSalesList.Models;
using ProductSalesList.Views;

namespace ProductSalesList.Controllers
{
    public class Controller
    {
        public void Write(string filePath)
        {
            var businessLogic = new BusinessLogic();
            var productSalesList = businessLogic.GetProductSalesList();
            using (var view = new View(filePath))
            {
                foreach (var productSales in productSalesList)
                {
                    view.Write(
                        new ProductSalesCsvRow
                        {
                            Name = productSales.Name,
                            Sales = productSales.Sales
                        });
                }
            }
        }
    }
}
