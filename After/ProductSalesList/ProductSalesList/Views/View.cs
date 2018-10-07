using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using ProductSalesList.Models;

namespace ProductSalesList.Views
{
    public class View : IView
    {
        private readonly string _fileName;
        public View(string fileName)
        {
            _fileName = fileName;
        }
        public void Display(IEnumerable<ProductSales> productSales)
        {
            using (var csvWriter = new CsvWriter(new StreamWriter(_fileName)))
            {
                csvWriter.Configuration.HasHeaderRecord = true;
                csvWriter.Configuration.AutoMap<ProductSalesCsvRow>();
                csvWriter.WriteHeader<ProductSalesCsvRow>();
                csvWriter.NextRecord();
                csvWriter.WriteRecords(productSales.Select(x => new ProductSalesCsvRow{Name = x.Name, Sales = x.Sales}));
            }
        }
    }
}
