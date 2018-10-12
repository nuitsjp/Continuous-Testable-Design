using System;
using ProductSalesList.Models.BusinessLogics;
using ProductSalesList.Views;

namespace ProductSalesList.Controllers
{
    public class Controller
    {
        private readonly BusinessLogic _businessLogic = new BusinessLogic();
        private readonly View _view = new View();

        public void Execute(string fineName)
        {
            var productSalesList = _businessLogic.GetProductSalesList();

            using (_view.Open(fineName))
            {
                foreach (var productSales in productSalesList)
                {
                    _view.WriteRecord(
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
