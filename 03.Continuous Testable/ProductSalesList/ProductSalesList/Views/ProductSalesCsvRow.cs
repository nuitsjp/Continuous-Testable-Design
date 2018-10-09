using CsvHelper.Configuration.Attributes;

namespace ProductSalesList.Views
{
    public class ProductSalesCsvRow
    {
        [Name("プロダクト名")]
        [Index(0)]
        public string Name { get; set; }

        [Name("総売上")]
        [Index(1)]
        public double Sales { get; set; }
    }
}
