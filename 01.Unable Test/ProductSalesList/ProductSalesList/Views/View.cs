using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using ProductSalesList.Controllers;
using ProductSalesList.Models.BusinessLogics;

namespace ProductSalesList.Views
{
    public class View
    {
        private CsvWriter _csvWriter;

        public IDisposable Open(string fileName)
        {
            try
            {
                _csvWriter = new CsvWriter(new StreamWriter(fileName));
                _csvWriter.Configuration.HasHeaderRecord = true;
                _csvWriter.Configuration.AutoMap<ProductSalesCsvRow>();
                _csvWriter.WriteHeader<ProductSalesCsvRow>();
                _csvWriter.NextRecord();
                return _csvWriter;
            }
            catch (Exception)
            {
                _csvWriter?.Dispose();
                throw;
            }
        }

        public void WriteRecord(ProductSalesCsvRow productSalesCsvRow)
        {
            _csvWriter.WriteRecord(productSalesCsvRow);
            _csvWriter.NextRecord();
        }
    }
}
