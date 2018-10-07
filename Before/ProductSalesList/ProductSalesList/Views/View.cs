using System;
using System.IO;
using CsvHelper;

namespace ProductSalesList.Views
{
    public class View : IDisposable
    {
        private readonly CsvWriter _csvWriter;
        public View(string fileName)
        {
            _csvWriter = new CsvWriter(new StreamWriter(fileName));
            _csvWriter.Configuration.HasHeaderRecord = true;
            _csvWriter.Configuration.AutoMap<ProductSalesCsvRow>();
            _csvWriter.WriteHeader<ProductSalesCsvRow>();
            _csvWriter.NextRecord();
        }
        public void Write(ProductSalesCsvRow productSalesCsvRow)
        {
            _csvWriter.WriteRecord(productSalesCsvRow);
            _csvWriter.NextRecord();
        }

        public void Dispose()
        {
            _csvWriter.Dispose();
        }
    }
}
