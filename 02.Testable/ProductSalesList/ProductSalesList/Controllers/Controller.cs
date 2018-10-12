using System;
using ProductSalesList.Models.BusinessLogics;
using ProductSalesList.Views;

namespace ProductSalesList.Controllers
{
    public class Controller
    {
        private readonly IBusinessLogic _businessLogic;
        private readonly IView _view;

        public Controller(IBusinessLogic businessLogic, IView view)
        {
            _businessLogic = businessLogic;
            _view = view;
        }

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
