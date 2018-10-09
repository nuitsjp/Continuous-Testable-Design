using System;

namespace ProductSalesList.Views
{
public interface IView
{
    IDisposable Open(string fileName);
    void WriteRecord(ProductSalesCsvRow productSalesCsvRow);
}
}