using ProductSalesList.Models.BusinessLogics;
using ProductSalesList.Views;

namespace ProductSalesList.Controllers
{
    public class Controller
    {
        public void Execute(string fileName)
        {
            var businessLogic = new BusinessLogic();
            var productSalesList = businessLogic.GetProductSalesList();

            using (var view = new View(fileName))
            {
                foreach (var productSalese in productSalesList)
                {
                    view.WriteRecord(
                        new ProductSalesCsvRow
                        {
                            Name = productSalese.Name,
                            Sales = productSalese.Sales
                        });
                }
            }
        }
    }
}
