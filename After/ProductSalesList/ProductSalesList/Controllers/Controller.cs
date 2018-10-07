using ProductSalesList.Models;
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

        public void Execute()
        {
            var productSalesList = _businessLogic.GetProductSalesList();
            _view.Display(productSalesList);
        }
    }
}
